namespace CinemaApp.Cadastros
{
    partial class CadastroSessao
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
            cboFilme = new ReaLTaiizor.Controls.MaterialComboBox();
            cboSala = new ReaLTaiizor.Controls.MaterialComboBox();
            lblData = new ReaLTaiizor.Controls.MaterialLabel();
            dtpData = new DateTimePicker();
            lblHora = new ReaLTaiizor.Controls.MaterialLabel();
            dtpHora = new DateTimePicker();
            lblPreco = new ReaLTaiizor.Controls.MaterialLabel();
            nudPreco = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(nudPreco)).BeginInit();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            SuspendLayout();
            tabPageCadastro.Controls.Add(nudPreco);
            tabPageCadastro.Controls.Add(lblPreco);
            tabPageCadastro.Controls.Add(dtpHora);
            tabPageCadastro.Controls.Add(lblHora);
            tabPageCadastro.Controls.Add(dtpData);
            tabPageCadastro.Controls.Add(lblData);
            tabPageCadastro.Controls.Add(cboSala);
            tabPageCadastro.Controls.Add(cboFilme);
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Size = new Size(546, 262);
            tabPageCadastro.Controls.SetChildIndex(btnCancelar, 0);
            tabPageCadastro.Controls.SetChildIndex(btnSalvar, 0);
            tabPageCadastro.Controls.SetChildIndex(txtId, 0);
            tabPageCadastro.Controls.SetChildIndex(cboFilme, 0);
            tabPageCadastro.Controls.SetChildIndex(cboSala, 0);
            tabPageCadastro.Controls.SetChildIndex(lblData, 0);
            tabPageCadastro.Controls.SetChildIndex(dtpData, 0);
            tabPageCadastro.Controls.SetChildIndex(lblHora, 0);
            tabPageCadastro.Controls.SetChildIndex(dtpHora, 0);
            tabPageCadastro.Controls.SetChildIndex(lblPreco, 0);
            tabPageCadastro.Controls.SetChildIndex(nudPreco, 0);
            tabControlCadastro.Size = new Size(554, 290);
            btnSalvar.Location = new Point(463, 217);
            btnCancelar.Location = new Point(359, 217);
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
            cboFilme.AutoResize = false;
            cboFilme.BackColor = Color.FromArgb(255, 255, 255);
            cboFilme.Depth = 0;
            cboFilme.DrawMode = DrawMode.OwnerDrawVariable;
            cboFilme.DropDownHeight = 174;
            cboFilme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilme.DropDownWidth = 121;
            cboFilme.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboFilme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboFilme.FormattingEnabled = true;
            cboFilme.Hint = "Filme";
            cboFilme.IntegralHeight = false;
            cboFilme.ItemHeight = 43;
            cboFilme.Location = new Point(18, 68);
            cboFilme.MaxDropDownItems = 4;
            cboFilme.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboFilme.Name = "cboFilme";
            cboFilme.Size = new Size(510, 49);
            cboFilme.StartIndex = 0;
            cboFilme.TabIndex = 3;
            cboSala.AutoResize = false;
            cboSala.BackColor = Color.FromArgb(255, 255, 255);
            cboSala.Depth = 0;
            cboSala.DrawMode = DrawMode.OwnerDrawVariable;
            cboSala.DropDownHeight = 174;
            cboSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSala.DropDownWidth = 121;
            cboSala.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboSala.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboSala.FormattingEnabled = true;
            cboSala.Hint = "Número da sala";
            cboSala.IntegralHeight = false;
            cboSala.ItemHeight = 43;
            cboSala.Location = new Point(18, 124);
            cboSala.MaxDropDownItems = 4;
            cboSala.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboSala.Name = "cboSala";
            cboSala.Size = new Size(150, 49);
            cboSala.StartIndex = 0;
            cboSala.TabIndex = 4;
            lblData.AutoSize = true;
            lblData.Depth = 0;
            lblData.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblData.Location = new Point(176, 126);
            lblData.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblData.Name = "lblData";
            lblData.Size = new Size(40, 19);
            lblData.TabIndex = 5;
            lblData.Text = "Data";
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(176, 150);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(130, 23);
            dtpData.TabIndex = 6;
            lblHora.AutoSize = true;
            lblHora.Depth = 0;
            lblHora.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblHora.Location = new Point(314, 126);
            lblHora.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(60, 19);
            lblHora.TabIndex = 7;
            lblHora.Text = "Horário";
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.ShowUpDown = true;
            dtpHora.Location = new Point(314, 150);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(90, 23);
            dtpHora.TabIndex = 8;
            lblPreco.AutoSize = true;
            lblPreco.Depth = 0;
            lblPreco.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPreco.Location = new Point(412, 126);
            lblPreco.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(80, 19);
            lblPreco.TabIndex = 9;
            lblPreco.Text = "Preço (R$)";
            nudPreco.DecimalPlaces = 2;
            nudPreco.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
            nudPreco.Location = new Point(412, 150);
            nudPreco.Maximum = new decimal(new int[] { 100000, 0, 0, 131072 });
            nudPreco.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(116, 23);
            nudPreco.TabIndex = 10;
            nudPreco.Value = new decimal(new int[] { 2000, 0, 0, 131072 });
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 357);
            Location = new Point(0, 0);
            Name = "CadastroSessao";
            Text = "Cadastro de Sessões";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(nudPreco)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
        private ReaLTaiizor.Controls.MaterialComboBox cboFilme;
        private ReaLTaiizor.Controls.MaterialComboBox cboSala;
        private ReaLTaiizor.Controls.MaterialLabel lblData;
        private DateTimePicker dtpData;
        private ReaLTaiizor.Controls.MaterialLabel lblHora;
        private DateTimePicker dtpHora;
        private ReaLTaiizor.Controls.MaterialLabel lblPreco;
        private NumericUpDown nudPreco;
    }
}
