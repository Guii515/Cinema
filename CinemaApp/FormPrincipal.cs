using CinemaApp.Cadastros;
using CinemaApp.Infra;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;

namespace CinemaApp
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirCadastro<TCadastro>() where TCadastro : Form
        {
            var aberto = MdiChildren.OfType<TCadastro>().FirstOrDefault();
            if (aberto is not null && !aberto.IsDisposed)
            {
                aberto.Activate();
                return;
            }

            var cadastro = ConfigureDI.ServiceProvider.GetService<TCadastro>();
            if (cadastro is null)
            {
                MessageBox.Show($"Não foi possível abrir {typeof(TCadastro).Name}.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cadastro.MdiParent = this;
            cadastro.Show();
        }

        private void gêneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCadastro<CadastroGenero>();
        }

        private void filmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCadastro<CadastroFilme>();
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCadastro<CadastroSala>();
        }

        private void sessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCadastro<CadastroSessao>();
        }

        private void ingressoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCadastro<CadastroIngresso>();
        }
    }
}
