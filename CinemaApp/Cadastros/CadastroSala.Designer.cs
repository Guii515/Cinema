namespace CinemaApp.Cadastros
{
    partial class CadastroSala
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            lblNumero = new ReaLTaiizor.Controls.MaterialLabel();
            nudNumero = new NumericUpDown();
            lblFileiras = new ReaLTaiizor.Controls.MaterialLabel();
            nudFileiras = new NumericUpDown();
            lblAssentos = new ReaLTaiizor.Controls.MaterialLabel();
            nudAssentos = new NumericUpDown();
            lblCapacidade = new ReaLTaiizor.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(nudNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(nudFileiras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(nudAssentos)).BeginInit();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            SuspendLayout();
            tabPageCadastro.Controls.Add(lblCapacidade);
            tabPageCadastro.Controls.Add(nudAssentos);
            tabPageCadastro.Controls.Add(lblAssentos);
            tabPageCadastro.Controls.Add(nudFileiras);
            tabPageCadastro.Controls.Add(lblFileiras);
            tabPageCadastro.Controls.Add(nudNumero);
            tabPageCadastro.Controls.Add(lblNumero);
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Size = new Size(440, 230);
            tabPageCadastro.Controls.SetChildIndex(btnCancelar, 0);
            tabPageCadastro.Controls.SetChildIndex(btnSalvar, 0);
            tabPageCadastro.Controls.SetChildIndex(txtId, 0);
            tabPageCadastro.Controls.SetChildIndex(lblNumero, 0);
            tabPageCadastro.Controls.SetChildIndex(nudNumero, 0);
            tabPageCadastro.Controls.SetChildIndex(lblFileiras, 0);
            tabPageCadastro.Controls.SetChildIndex(nudFileiras, 0);
            tabPageCadastro.Controls.SetChildIndex(lblAssentos, 0);
            tabPageCadastro.Controls.SetChildIndex(nudAssentos, 0);
            tabPageCadastro.Controls.SetChildIndex(lblCapacidade, 0);
            tabControlCadastro.Size = new Size(448, 258);
            btnSalvar.Location = new Point(357, 185);
            btnCancelar.Location = new Point(253, 185);
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(18, 14);
            txtId.MaxLength = 32767;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = false;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(78, 48);
            txtId.TabIndex = 2;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            lblNumero.AutoSize = true;
            lblNumero.Depth = 0;
            lblNumero.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNumero.Location = new Point(18, 76);
            lblNumero.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(110, 19);
            lblNumero.TabIndex = 3;
            lblNumero.Text = "Número da sala";
            nudNumero.Location = new Point(18, 100);
            nudNumero.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudNumero.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumero.Name = "nudNumero";
            nudNumero.Size = new Size(120, 23);
            nudNumero.TabIndex = 4;
            nudNumero.Value = new decimal(new int[] { 1, 0, 0, 0 });
            lblFileiras.AutoSize = true;
            lblFileiras.Depth = 0;
            lblFileiras.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFileiras.Location = new Point(154, 76);
            lblFileiras.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblFileiras.Name = "lblFileiras";
            lblFileiras.Size = new Size(60, 19);
            lblFileiras.TabIndex = 5;
            lblFileiras.Text = "Fileiras";
            nudFileiras.Location = new Point(154, 100);
            nudFileiras.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudFileiras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFileiras.Name = "nudFileiras";
            nudFileiras.Size = new Size(120, 23);
            nudFileiras.TabIndex = 6;
            nudFileiras.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudFileiras.ValueChanged += AtualizaCapacidade;
            lblAssentos.AutoSize = true;
            lblAssentos.Depth = 0;
            lblAssentos.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAssentos.Location = new Point(290, 76);
            lblAssentos.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAssentos.Name = "lblAssentos";
            lblAssentos.Size = new Size(130, 19);
            lblAssentos.TabIndex = 7;
            lblAssentos.Text = "Assentos por fileira";
            nudAssentos.Location = new Point(290, 100);
            nudAssentos.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudAssentos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAssentos.Name = "nudAssentos";
            nudAssentos.Size = new Size(120, 23);
            nudAssentos.TabIndex = 8;
            nudAssentos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudAssentos.ValueChanged += AtualizaCapacidade;
            lblCapacidade.AutoSize = true;
            lblCapacidade.Depth = 0;
            lblCapacidade.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCapacidade.Location = new Point(18, 148);
            lblCapacidade.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(180, 19);
            lblCapacidade.TabIndex = 9;
            lblCapacidade.Text = "Capacidade: 1 lugar(es)";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 325);
            Location = new Point(0, 0);
            Name = "CadastroSala";
            Text = "Cadastro de Salas";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(nudNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(nudFileiras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(nudAssentos)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
        private ReaLTaiizor.Controls.MaterialLabel lblNumero;
        private NumericUpDown nudNumero;
        private ReaLTaiizor.Controls.MaterialLabel lblFileiras;
        private NumericUpDown nudFileiras;
        private ReaLTaiizor.Controls.MaterialLabel lblAssentos;
        private NumericUpDown nudAssentos;
        private ReaLTaiizor.Controls.MaterialLabel lblCapacidade;
    }
}
