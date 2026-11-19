using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroFilme : CadastroBase
    {
        private static readonly string[] _classificacoes = { "Livre", "10 anos", "12 anos", "14 anos", "16 anos", "18 anos" };

        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Genero> _generoService;
        private List<Genero> _generos = new();

        public CadastroFilme(IBaseService<Filme> filmeService, IBaseService<Genero> generoService)
        {
            _filmeService = filmeService;
            _generoService = generoService;
            InitializeComponent();
            cboClassificacao.Items.AddRange(_classificacoes);
            CarregaGeneros();
            ReiniciaCampos();
        }

        private void CarregaGeneros()
        {
            _generos = _generoService.ReadAll<Genero>().OrderBy(g => g.Nome).ToList();
            cboGenero.DataSource = null;
            cboGenero.DisplayMember = nameof(Genero.Nome);
            cboGenero.ValueMember = nameof(Genero.Id);
            cboGenero.DataSource = _generos;
            cboGenero.SelectedIndex = -1;
        }

        private void ReiniciaCampos()
        {
            cboClassificacao.SelectedIndex = -1;
            cboGenero.SelectedIndex = -1;
            nudDuracao.Value = 120;
        }

        private void PreencheObjeto(Filme filme)
        {
            filme.Nome = txtNome.Text.Trim();
            filme.Classificacao = cboClassificacao.SelectedItem?.ToString() ?? string.Empty;
            filme.Genero = cboGenero.SelectedItem as Genero;
            filme.Duracao = (int)nudDuracao.Value;
        }

        protected override void Novo()
        {
            base.Novo();
            CarregaGeneros();
            ReiniciaCampos();
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var filme = _filmeService.ReadById<Filme>(Convert.ToInt32(txtId.Text));
                    var original = (filme.Nome, filme.Classificacao, filme.Genero, filme.Duracao);
                    try
                    {
                        PreencheObjeto(filme);
                        _filmeService.Update<Filme, Filme, FilmeValidator>(filme);
                    }
                    catch
                    {
                        (filme.Nome, filme.Classificacao, filme.Genero, filme.Duracao) = original;
                        throw;
                    }
                }
                else
                {
                    var filme = new Filme();
                    PreencheObjeto(filme);
                    _filmeService.Create<Filme, Filme, FilmeValidator>(filme);
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
                _filmeService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _filmeService.ReadAll<FilmeViewModel>()
                .OrderBy(f => f.Nome)
                .ToList();

            dataGridViewConsulta.Preencher(nameof(FilmeViewModel.Nome));
            dataGridViewConsulta.Titulo(nameof(FilmeViewModel.Classificacao), "Classificação");
            dataGridViewConsulta.Titulo(nameof(FilmeViewModel.NomeGenero), "Gênero");
            dataGridViewConsulta.Titulo(nameof(FilmeViewModel.Duracao), "Duração (min)");
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var filme = _filmeService.ReadById<Filme>(Convert.ToInt32(row.Cells["Id"].Value));
            CarregaGeneros();

            txtId.Text = filme.Id.ToString();
            txtNome.Text = filme.Nome;
            cboClassificacao.SelectedItem = filme.Classificacao;
            cboGenero.SelectedItem = _generos.FirstOrDefault(g => g.Id == filme.Genero?.Id);
            nudDuracao.Value = Math.Clamp(filme.Duracao, (int)nudDuracao.Minimum, (int)nudDuracao.Maximum);
        }
    }
}
