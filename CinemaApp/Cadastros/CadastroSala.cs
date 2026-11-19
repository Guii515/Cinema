using CinemaApp.Base;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroSala : CadastroBase
    {
        private readonly IBaseService<Sala> _salaService;

        public CadastroSala(IBaseService<Sala> salaService)
        {
            _salaService = salaService;
            InitializeComponent();
            AtualizaCapacidade(this, EventArgs.Empty);
        }

        private void AtualizaCapacidade(object? sender, EventArgs e)
        {
            var total = (int)(nudFileiras.Value * nudAssentos.Value);
            lblCapacidade.Text = $"Capacidade: {total} lugares";
        }

        private static void Ajusta(NumericUpDown campo, int valor)
        {
            campo.Value = Math.Clamp(valor, (int)campo.Minimum, (int)campo.Maximum);
        }

        private void PreencheObjeto(Sala sala)
        {
            sala.Numero = (int)nudNumero.Value;
            sala.Fileiras = (int)nudFileiras.Value;
            sala.Assentos = (int)nudAssentos.Value;
            sala.Capacidade = sala.Fileiras * sala.Assentos;
        }

        protected override void Novo()
        {
            base.Novo();
            Ajusta(nudNumero, 1);
            Ajusta(nudFileiras, 1);
            Ajusta(nudAssentos, 1);
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var sala = _salaService.ReadById<Sala>(Convert.ToInt32(txtId.Text));
                    var original = (sala.Numero, sala.Fileiras, sala.Assentos, sala.Capacidade);
                    try
                    {
                        PreencheObjeto(sala);
                        _salaService.Update<Sala, Sala, SalaValidator>(sala);
                    }
                    catch
                    {
                        (sala.Numero, sala.Fileiras, sala.Assentos, sala.Capacidade) = original;
                        throw;
                    }
                }
                else
                {
                    var sala = new Sala();
                    PreencheObjeto(sala);
                    _salaService.Create<Sala, Sala, SalaValidator>(sala);
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
                _salaService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _salaService.ReadAll<Sala>()
                .OrderBy(s => s.Numero)
                .ToList();

            dataGridViewConsulta.Titulo(nameof(Sala.Numero), "Número");
            dataGridViewConsulta.Titulo(nameof(Sala.Capacidade), "Capacidade");
            dataGridViewConsulta.Titulo(nameof(Sala.Fileiras), "Fileiras");
            dataGridViewConsulta.Titulo(nameof(Sala.Assentos), "Assentos por fileira");
            dataGridViewConsulta.Preencher(nameof(Sala.Assentos));
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var sala = _salaService.ReadById<Sala>(Convert.ToInt32(row.Cells["Id"].Value));

            txtId.Text = sala.Id.ToString();
            Ajusta(nudNumero, sala.Numero);
            Ajusta(nudFileiras, sala.Fileiras);
            Ajusta(nudAssentos, sala.Assentos);
        }
    }
}
