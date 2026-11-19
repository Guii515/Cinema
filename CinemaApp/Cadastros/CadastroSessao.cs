using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroSessao : CadastroBase
    {
        private readonly IBaseService<Sessao> _sessaoService;
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Sala> _salaService;
        private List<Filme> _filmes = new();
        private List<Sala> _salas = new();

        public CadastroSessao(
            IBaseService<Sessao> sessaoService,
            IBaseService<Filme> filmeService,
            IBaseService<Sala> salaService)
        {
            _sessaoService = sessaoService;
            _filmeService = filmeService;
            _salaService = salaService;
            InitializeComponent();
            CarregaCombos();
            ReiniciaCampos();
        }

        private void CarregaCombos()
        {
            _filmes = _filmeService.ReadAll<Filme>().OrderBy(f => f.Nome).ToList();
            cboFilme.DataSource = null;
            cboFilme.DisplayMember = nameof(Filme.Nome);
            cboFilme.ValueMember = nameof(Filme.Id);
            cboFilme.DataSource = _filmes;
            cboFilme.SelectedIndex = -1;

            _salas = _salaService.ReadAll<Sala>().OrderBy(s => s.Numero).ToList();
            cboSala.DataSource = null;
            cboSala.DisplayMember = nameof(Sala.Numero);
            cboSala.ValueMember = nameof(Sala.Id);
            cboSala.DataSource = _salas;
            cboSala.SelectedIndex = -1;
        }

        private void ReiniciaCampos()
        {
            cboFilme.SelectedIndex = -1;
            cboSala.SelectedIndex = -1;
            dtpData.Value = DateTime.Today.AddDays(1);
            dtpHora.Value = DateTime.Today.AddHours(20);
            nudPreco.Value = 20;
        }

        private void PreencheObjeto(Sessao sessao)
        {
            sessao.Filme = cboFilme.SelectedItem as Filme;
            sessao.Sala = cboSala.SelectedItem as Sala;
            sessao.Data = dtpData.Value.Date + dtpHora.Value.TimeOfDay;
            sessao.Preco = nudPreco.Value;
        }

        protected override void Novo()
        {
            base.Novo();
            CarregaCombos();
            ReiniciaCampos();
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var sessao = _sessaoService.ReadById<Sessao>(Convert.ToInt32(txtId.Text));
                    var original = (sessao.Filme, sessao.Sala, sessao.Data, sessao.Preco);
                    try
                    {
                        PreencheObjeto(sessao);
                        _sessaoService.Update<Sessao, Sessao, SessaoValidator>(sessao);
                    }
                    catch
                    {
                        (sessao.Filme, sessao.Sala, sessao.Data, sessao.Preco) = original;
                        throw;
                    }
                }
                else
                {
                    var sessao = new Sessao();
                    PreencheObjeto(sessao);
                    _sessaoService.Create<Sessao, Sessao, SessaoValidator>(sessao);
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
                _sessaoService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            _filmeService.ReadAll<Filme>().ToList();
            _salaService.ReadAll<Sala>().ToList();

            dataGridViewConsulta.DataSource = _sessaoService.ReadAll<SessaoViewModel>()
                .OrderBy(s => s.Data)
                .ToList();

            dataGridViewConsulta.Preencher(nameof(SessaoViewModel.NomeFilme));
            dataGridViewConsulta.Titulo(nameof(SessaoViewModel.NomeFilme), "Filme");
            dataGridViewConsulta.Titulo(nameof(SessaoViewModel.NumeroSala), "Sala");
            dataGridViewConsulta.Titulo(nameof(SessaoViewModel.Data), "Data e hora");
            dataGridViewConsulta.Titulo(nameof(SessaoViewModel.Preco), "Preço");
            dataGridViewConsulta.Formato(nameof(SessaoViewModel.Data), "dd/MM/yyyy HH:mm");
            dataGridViewConsulta.Formato(nameof(SessaoViewModel.Preco), "C2");
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var sessao = _sessaoService.ReadById<Sessao>(Convert.ToInt32(row.Cells["Id"].Value));
            CarregaCombos();

            txtId.Text = sessao.Id.ToString();
            cboFilme.SelectedItem = _filmes.FirstOrDefault(f => f.Id == sessao.Filme?.Id);
            cboSala.SelectedItem = _salas.FirstOrDefault(s => s.Id == sessao.Sala?.Id);
            dtpData.Value = sessao.Data.Date;
            dtpHora.Value = DateTime.Today.Add(sessao.Data.TimeOfDay);
            nudPreco.Value = Math.Clamp(sessao.Preco, nudPreco.Minimum, nudPreco.Maximum);
        }
    }
}
