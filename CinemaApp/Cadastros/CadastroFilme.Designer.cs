namespace CinemaApp.Cadastros
{
    partial class CadastroFilme
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
            txtNome = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cboClassificacao = new ReaLTaiizor.Controls.MaterialComboBox();
            cboGenero = new ReaLTaiizor.Controls.MaterialComboBox();
            lblDuracao = new ReaLTaiizor.Controls.MaterialLabel();
            nudDuracao = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(nudDuracao)).BeginInit();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            SuspendLayout();
            tabPageCadastro.Controls.Add(nudDuracao);
            tabPageCadastro.Controls.Add(lblDuracao);
            tabPageCadastro.Controls.Add(cboGenero);
            tabPageCadastro.Controls.Add(cboClassificacao);
            tabPageCadastro.Controls.Add(txtNome);
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Size = new Size(546, 262);
            tabPageCadastro.Controls.SetChildIndex(btnCancelar, 0);
            tabPageCadastro.Controls.SetChildIndex(btnSalvar, 0);
            tabPageCadastro.Controls.SetChildIndex(txtId, 0);
            tabPageCadastro.Controls.SetChildIndex(txtNome, 0);
            tabPageCadastro.Controls.SetChildIndex(cboClassificacao, 0);
            tabPageCadastro.Controls.SetChildIndex(cboGenero, 0);
            tabPageCadastro.Controls.SetChildIndex(lblDuracao, 0);
            tabPageCadastro.Controls.SetChildIndex(nudDuracao, 0);
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
            txtNome.AnimateReadOnly = false;
            txtNome.AutoCompleteMode = AutoCompleteMode.None;
            txtNome.AutoCompleteSource = AutoCompleteSource.None;
            txtNome.BackgroundImageLayout = ImageLayout.None;
            txtNome.CharacterCasing = CharacterCasing.Normal;
            txtNome.Depth = 0;
            txtNome.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNome.HideSelection = true;
            txtNome.Hint = "Nome do filme";
            txtNome.LeadingIcon = null;
            txtNome.Location = new Point(18, 68);
            txtNome.MaxLength = 32767;
            txtNome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtNome.Name = "txtNome";
            txtNome.PasswordChar = '\0';
            txtNome.PrefixSuffixText = null;
            txtNome.ReadOnly = false;
            txtNome.RightToLeft = RightToLeft.No;
            txtNome.SelectedText = "";
            txtNome.SelectionLength = 0;
            txtNome.SelectionStart = 0;
            txtNome.ShortcutsEnabled = true;
            txtNome.Size = new Size(510, 48);
            txtNome.TabIndex = 3;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            cboClassificacao.AutoResize = false;
            cboClassificacao.BackColor = Color.FromArgb(255, 255, 255);
            cboClassificacao.Depth = 0;
            cboClassificacao.DrawMode = DrawMode.OwnerDrawVariable;
            cboClassificacao.DropDownHeight = 174;
            cboClassificacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClassificacao.DropDownWidth = 121;
            cboClassificacao.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboClassificacao.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboClassificacao.FormattingEnabled = true;
            cboClassificacao.Hint = "Classificação";
            cboClassificacao.IntegralHeight = false;
            cboClassificacao.ItemHeight = 43;
            cboClassificacao.Location = new Point(18, 124);
            cboClassificacao.MaxDropDownItems = 4;
            cboClassificacao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboClassificacao.Name = "cboClassificacao";
            cboClassificacao.Size = new Size(150, 49);
            cboClassificacao.StartIndex = 0;
            cboClassificacao.TabIndex = 4;
            cboGenero.AutoResize = false;
            cboGenero.BackColor = Color.FromArgb(255, 255, 255);
            cboGenero.Depth = 0;
            cboGenero.DrawMode = DrawMode.OwnerDrawVariable;
            cboGenero.DropDownHeight = 174;
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.DropDownWidth = 121;
            cboGenero.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboGenero.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboGenero.FormattingEnabled = true;
            cboGenero.Hint = "Gênero";
            cboGenero.IntegralHeight = false;
            cboGenero.ItemHeight = 43;
            cboGenero.Location = new Point(176, 124);
            cboGenero.MaxDropDownItems = 4;
            cboGenero.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(230, 49);
            cboGenero.StartIndex = 0;
            cboGenero.TabIndex = 5;
            lblDuracao.AutoSize = true;
            lblDuracao.Depth = 0;
            lblDuracao.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDuracao.Location = new Point(414, 126);
            lblDuracao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblDuracao.Name = "lblDuracao";
            lblDuracao.Size = new Size(100, 19);
            lblDuracao.TabIndex = 6;
            lblDuracao.Text = "Duração (min)";
            nudDuracao.Location = new Point(414, 150);
            nudDuracao.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudDuracao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuracao.Name = "nudDuracao";
            nudDuracao.Size = new Size(114, 23);
            nudDuracao.TabIndex = 7;
            nudDuracao.Value = new decimal(new int[] { 120, 0, 0, 0 });
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 357);
            Location = new Point(0, 0);
            Name = "CadastroFilme";
            Text = "Cadastro de Filmes";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(nudDuracao)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtNome;
        private ReaLTaiizor.Controls.MaterialComboBox cboClassificacao;
        private ReaLTaiizor.Controls.MaterialComboBox cboGenero;
        private ReaLTaiizor.Controls.MaterialLabel lblDuracao;
        private NumericUpDown nudDuracao;
    }
}
