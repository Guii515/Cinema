using CinemaDomain;

namespace CinemaApp.Cadastros
{
    public class SelecaoAssentosForm : Form
    {
        private const int LarguraAssento = 42;
        private const int AlturaAssento = 32;
        private const int Espaco = 6;
        private const int Margem = 14;
        private const int LarguraRotulo = 38;

        private readonly Sala _sala;
        private readonly ISet<(int, int)> _ocupados;
        private readonly List<(int Fileira, int Assento)> _marcados = new();
        private readonly Panel _mapa = new();
        private readonly Button _btnConfirmar = new();
        private readonly Button _btnCancelar = new();

        public IReadOnlyList<(int Fileira, int Assento)> Escolhidos =>
            _marcados.OrderBy(m => m.Fileira).ThenBy(m => m.Assento).ToList();

        public SelecaoAssentosForm(Sala sala, ISet<(int, int)> ocupados)
        {
            _sala = sala;
            _ocupados = ocupados;

            Text = $"Sala {sala.Numero} - escolha dos assentos";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            var larguraMapa = Margem * 2 + LarguraRotulo + sala.Assentos * (LarguraAssento + Espaco);
            var alturaMapa = Margem * 2 + sala.Fileiras * (AlturaAssento + Espaco);
            ClientSize = new Size(
                Math.Clamp(larguraMapa + 20, 460, 1000),
                Math.Clamp(alturaMapa + 100, 320, 700));

            MontaTela();
            DesenhaAssentos();
        }

        private void MontaTela()
        {
            var tela = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Text = "T E L A",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.DimGray,
                ForeColor = Color.White,
                Font = new Font(Font, FontStyle.Bold)
            };

            _mapa.Dock = DockStyle.Fill;
            _mapa.AutoScroll = true;

            var rodape = new Panel { Dock = DockStyle.Bottom, Height = 56 };

            var legenda = new Label
            {
                AutoSize = true,
                Location = new Point(Margem, 20),
                Text = "Verde: livre   Azul: escolhido   Cinza: ocupado"
            };

            _btnConfirmar.Text = "Confirmar";
            _btnConfirmar.Size = new Size(96, 32);
            _btnConfirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnConfirmar.Location = new Point(ClientSize.Width - 96 - Margem, 12);
            _btnConfirmar.DialogResult = DialogResult.OK;
            _btnConfirmar.Enabled = false;

            _btnCancelar.Text = "Cancelar";
            _btnCancelar.Size = new Size(96, 32);
            _btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancelar.Location = new Point(_btnConfirmar.Left - 96 - 8, 12);
            _btnCancelar.DialogResult = DialogResult.Cancel;

            rodape.Controls.Add(legenda);
            rodape.Controls.Add(_btnConfirmar);
            rodape.Controls.Add(_btnCancelar);

            Controls.Add(_mapa);
            Controls.Add(tela);
            Controls.Add(rodape);

            AcceptButton = _btnConfirmar;
            CancelButton = _btnCancelar;
        }

        private void DesenhaAssentos()
        {
            for (var fileira = 1; fileira <= _sala.Fileiras; fileira++)
            {
                var topo = Margem + (fileira - 1) * (AlturaAssento + Espaco);

                _mapa.Controls.Add(new Label
                {
                    Text = $"F{fileira}",
                    Location = new Point(Margem, topo),
                    Size = new Size(LarguraRotulo - 4, AlturaAssento),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font(Font, FontStyle.Bold)
                });

                for (var assento = 1; assento <= _sala.Assentos; assento++)
                {
                    var esquerda = Margem + LarguraRotulo + (assento - 1) * (LarguraAssento + Espaco);
                    var ocupado = _ocupados.Contains((fileira, assento));

                    var caixa = new CheckBox
                    {
                        Appearance = Appearance.Button,
                        TextAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                        Text = assento.ToString(),
                        Size = new Size(LarguraAssento, AlturaAssento),
                        Location = new Point(esquerda, topo),
                        Tag = (fileira, assento),
                        Enabled = !ocupado,
                        BackColor = ocupado ? Color.Silver : Color.LightGreen
                    };

                    if (!ocupado)
                        caixa.CheckedChanged += Assento_CheckedChanged;

                    _mapa.Controls.Add(caixa);
                }
            }
        }

        private void Assento_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox caixa || caixa.Tag is not ValueTuple<int, int> posicao)
                return;

            var item = (Fileira: posicao.Item1, Assento: posicao.Item2);

            if (caixa.Checked)
            {
                _marcados.Add(item);
                caixa.BackColor = Color.LightSkyBlue;
            }
            else
            {
                _marcados.Remove(item);
                caixa.BackColor = Color.LightGreen;
            }

            _btnConfirmar.Enabled = _marcados.Count > 0;
        }
    }
}
