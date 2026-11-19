using System.ComponentModel;
using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroIngresso : CadastroBase
    {
        private static readonly string[] _formasPagamento = { "Dinheiro", "Cartão de crédito", "Cartão de débito", "Pix" };

        private readonly IBaseService<Ingresso> _ingressoService;
        private readonly IBaseService<IngressoItem> _itemService;
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Sessao> _sessaoService;
        private readonly IBaseService<Sala> _salaService;

        private List<Filme> _filmes = new();
        private List<Sessao> _sessoes = new();
        private BindingList<IngressoItem> _itens = new();
        private int? _sessaoPreservada;
        private bool _carregando;

        private sealed record Estado(
            string Documento,
            string FormaPagamento,
            Sessao? Sessao,
            decimal ValorTotal,
            List<IngressoItem> Itens);

        public CadastroIngresso(
            IBaseService<Ingresso> ingressoService,
            IBaseService<IngressoItem> itemService,
            IBaseService<Filme> filmeService,
            IBaseService<Sessao> sessaoService,
            IBaseService<Sala> salaService)
        {
            _ingressoService = ingressoService;
            _itemService = itemService;
            _filmeService = filmeService;
            _sessaoService = sessaoService;
            _salaService = salaService;

            InitializeComponent();
            cboFormaPagamento.Items.AddRange(_formasPagamento);
            ConfiguraGridItens();
            CarregaDados();
            cboFormaPagamento.SelectedIndex = -1;
            ReiniciaItens();
            AtualizaInfoSessao();
        }

        private Sessao? SessaoSelecionada => cboSessao.SelectedItem as Sessao;

        private void ConfiguraGridItens()
        {
            gridItens.AutoGenerateColumns = false;
            gridItens.Columns.Clear();
            gridItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFileira",
                DataPropertyName = nameof(IngressoItem.Fileira),
                HeaderText = "Fileira",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            gridItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAssento",
                DataPropertyName = nameof(IngressoItem.Assento),
                HeaderText = "Assento",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            gridItens.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colMeia",
                DataPropertyName = nameof(IngressoItem.MeiaEntrada),
                HeaderText = "Meia-entrada",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            gridItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colValor",
                HeaderText = "Valor",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CarregaRelacionados()
        {
            _filmeService.ReadAll<Filme>().ToList();
            _salaService.ReadAll<Sala>().ToList();
            _sessaoService.ReadAll<Sessao>().ToList();
            _itemService.ReadAll<IngressoItem>().ToList();
        }

        private void CarregaDados()
        {
            CarregaRelacionados();
            _filmes = _filmeService.ReadAll<Filme>().OrderBy(f => f.Nome).ToList();
            _sessoes = _sessaoService.ReadAll<Sessao>().ToList();

            _carregando = true;
            cboFilme.DataSource = null;
            cboFilme.DisplayMember = nameof(Filme.Nome);
            cboFilme.ValueMember = nameof(Filme.Id);
            cboFilme.DataSource = _filmes;
            cboFilme.SelectedIndex = -1;
            cboSessao.DataSource = null;
            _carregando = false;
        }

        private void CarregaSessoes(Filme? filme)
        {
            var agora = DateTime.Now;
            var lista = filme is null
                ? new List<Sessao>()
                : _sessoes
                    .Where(s => s.Filme?.Id == filme.Id && (s.Data > agora || s.Id == _sessaoPreservada))
                    .OrderBy(s => s.Data)
                    .ToList();

            _carregando = true;
            cboSessao.DataSource = null;
            cboSessao.DataSource = lista;
            cboSessao.SelectedIndex = -1;
            _carregando = false;
            AtualizaInfoSessao();
        }

        private void ReiniciaItens()
        {
            _itens = new BindingList<IngressoItem>();
            _itens.ListChanged += (_, _) => AtualizaTotal();
            gridItens.DataSource = _itens;
            AtualizaTotal();
        }

        private void AtualizaInfoSessao()
        {
            if (SessaoSelecionada is not Sessao sessao)
            {
                lblInfoSessao.Text = "Selecione um filme e uma sessão";
                return;
            }

            lblInfoSessao.Text =
                $"Classificação: {sessao.Filme?.Classificacao} | Sala {sessao.Sala?.Numero} | {sessao.Sala?.Capacidade} lugares";
        }

        private void AtualizaTotal()
        {
            var preco = SessaoSelecionada?.Preco ?? 0m;
            var total = _itens.Sum(i => i.MeiaEntrada ? preco / 2 : preco);
            lblTotal.Text = $"Total: {total:C2}";
            gridItens.Invalidate();
        }

        private void cboFilme_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_carregando)
                return;

            if (_itens.Count > 0)
                ReiniciaItens();

            CarregaSessoes(cboFilme.SelectedItem as Filme);
        }

        private void cboSessao_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_carregando)
                return;

            if (_itens.Count > 0)
                ReiniciaItens();

            AtualizaInfoSessao();
            AtualizaTotal();
        }

        private void cboSessao_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Sessao sessao)
                e.Value = $"{sessao.Data:dd/MM HH:mm} - Sala {sessao.Sala?.Numero} - {sessao.Preco:C2}";
        }

        private void gridItens_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (gridItens.IsCurrentCellDirty)
                gridItens.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void gridItens_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                AtualizaTotal();
        }

        private void gridItens_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || gridItens.Columns[e.ColumnIndex].Name != "colValor")
                return;

            if (gridItens.Rows[e.RowIndex].DataBoundItem is not IngressoItem item)
                return;

            var preco = SessaoSelecionada?.Preco ?? 0m;
            e.Value = (item.MeiaEntrada ? preco / 2 : preco).ToString("C2");
            e.FormattingApplied = true;
        }

        private void gridItens_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private HashSet<(int, int)> AssentosOcupados(Sessao sessao)
        {
            CarregaRelacionados();
            var ocupados = new HashSet<(int, int)>();

            foreach (var ingresso in _ingressoService.ReadAll<Ingresso>())
            {
                if (ingresso.Sessao?.Id != sessao.Id)
                    continue;
                if (IsEditMode && ingresso.Id.ToString() == txtId.Text)
                    continue;

                foreach (var item in ingresso.IngressoItens ?? new List<IngressoItem>())
                    ocupados.Add((item.Fileira, item.Assento));
            }

            foreach (var item in _itens)
                ocupados.Add((item.Fileira, item.Assento));

            return ocupados;
        }

        private void btnEscolherAssentos_Click(object? sender, EventArgs e)
        {
            if (SessaoSelecionada is not Sessao sessao)
            {
                MessageBox.Show("Escolha o filme e a sessão antes de selecionar os assentos.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sala = sessao.Sala;
            if (sala is null || sala.Fileiras <= 0 || sala.Assentos <= 0)
            {
                MessageBox.Show("A sala desta sessão não tem fileiras e assentos definidos.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var selecao = new SelecaoAssentosForm(sala, AssentosOcupados(sessao));
                if (selecao.ShowDialog(this) != DialogResult.OK)
                    return;

                foreach (var (fileira, assento) in selecao.Escolhidos)
                    _itens.Add(new IngressoItem { Fileira = fileira, Assento = assento });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverAssento_Click(object? sender, EventArgs e)
        {
            if (gridItens.SelectedRows.Count == 0 ||
                gridItens.SelectedRows[0].DataBoundItem is not IngressoItem item)
            {
                MessageBox.Show("Selecione um assento da lista para remover.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _itens.Remove(item);
        }

        private static Estado Capturar(Ingresso ingresso)
        {
            return new Estado(
                ingresso.Documento,
                ingresso.FormaPagamento,
                ingresso.Sessao,
                ingresso.ValorTotal,
                ingresso.IngressoItens?.ToList() ?? new List<IngressoItem>());
        }

        private static void Restaurar(Ingresso ingresso, Estado estado)
        {
            ingresso.Documento = estado.Documento;
            ingresso.FormaPagamento = estado.FormaPagamento;
            ingresso.Sessao = estado.Sessao;
            ingresso.ValorTotal = estado.ValorTotal;

            if (ingresso.IngressoItens is List<IngressoItem> lista)
            {
                lista.Clear();
                lista.AddRange(estado.Itens);
            }
        }

        private void PreencheObjeto(Ingresso ingresso)
        {
            gridItens.EndEdit();

            var preco = SessaoSelecionada?.Preco ?? 0m;

            ingresso.Documento = txtDocumento.Text.Trim();
            ingresso.FormaPagamento = cboFormaPagamento.SelectedItem?.ToString() ?? string.Empty;
            ingresso.Sessao = SessaoSelecionada;
            ingresso.ValorTotal = _itens.Sum(i => i.MeiaEntrada ? preco / 2 : preco);

            if (ingresso.Id == 0)
                ingresso.DataCompra = DateTime.Now;

            var atuais = ingresso.IngressoItens ?? new List<IngressoItem>();
            foreach (var item in atuais.Where(i => !_itens.Contains(i)).ToList())
                atuais.Remove(item);
            foreach (var item in _itens.Where(i => !atuais.Contains(i)).ToList())
                atuais.Add(item);
            ingresso.IngressoItens = atuais;
        }

        protected override void Novo()
        {
            base.Novo();
            _sessaoPreservada = null;
            CarregaDados();
            cboFormaPagamento.SelectedIndex = -1;
            ReiniciaItens();
            AtualizaInfoSessao();
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var ingresso = _ingressoService.ReadById<Ingresso>(Convert.ToInt32(txtId.Text));
                    var original = Capturar(ingresso);
                    try
                    {
                        PreencheObjeto(ingresso);
                        _ingressoService.Update<Ingresso, Ingresso, IngressoValidator>(ingresso);
                    }
                    catch
                    {
                        Restaurar(ingresso, original);
                        throw;
                    }
                }
                else
                {
                    var ingresso = new Ingresso();
                    PreencheObjeto(ingresso);
                    _ingressoService.Create<Ingresso, Ingresso, IngressoValidator>(ingresso);
                }
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _ingressoService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            CarregaRelacionados();

            dataGridViewConsulta.DataSource = _ingressoService.ReadAll<IngressoViewModel>()
                .OrderByDescending(i => i.DataCompra)
                .ToList();

            dataGridViewConsulta.Preencher(nameof(IngressoViewModel.NomeFilme));
            dataGridViewConsulta.Titulo(nameof(IngressoViewModel.NomeFilme), "Filme");
            dataGridViewConsulta.Titulo(nameof(IngressoViewModel.DataSessao), "Sessão");
            dataGridViewConsulta.Titulo(nameof(IngressoViewModel.ValorTotal), "Valor total");
            dataGridViewConsulta.Titulo(nameof(IngressoViewModel.FormaPagamento), "Pagamento");
            dataGridViewConsulta.Titulo(nameof(IngressoViewModel.DataCompra), "Compra");
            dataGridViewConsulta.Formato(nameof(IngressoViewModel.DataSessao), "dd/MM/yyyy HH:mm");
            dataGridViewConsulta.Formato(nameof(IngressoViewModel.DataCompra), "dd/MM/yyyy HH:mm");
            dataGridViewConsulta.Formato(nameof(IngressoViewModel.ValorTotal), "C2");
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            CarregaDados();
            var ingresso = _ingressoService.ReadById<Ingresso>(Convert.ToInt32(row.Cells["Id"].Value));

            txtId.Text = ingresso.Id.ToString();
            txtDocumento.Text = ingresso.Documento;
            cboFormaPagamento.SelectedItem = ingresso.FormaPagamento;

            _sessaoPreservada = ingresso.Sessao?.Id;

            _carregando = true;
            cboFilme.SelectedItem = _filmes.FirstOrDefault(f => f.Id == ingresso.Sessao?.Filme?.Id);
            _carregando = false;

            CarregaSessoes(cboFilme.SelectedItem as Filme);

            _carregando = true;
            cboSessao.SelectedItem = (cboSessao.DataSource as List<Sessao>)?
                .FirstOrDefault(s => s.Id == ingresso.Sessao?.Id);
            _carregando = false;

            ReiniciaItens();
            foreach (var item in ingresso.IngressoItens ?? new List<IngressoItem>())
                _itens.Add(item);

            AtualizaInfoSessao();
            AtualizaTotal();
        }
    }
}
