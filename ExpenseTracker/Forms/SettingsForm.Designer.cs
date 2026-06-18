namespace ExpenseTracker.Forms {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lblLanguage = new Label();
            cmbLanguage = new ComboBox();
            lblPageSize = new Label();
            numPage = new NumericUpDown();
            btnSave = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)numPage).BeginInit();
            SuspendLayout();
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(13, 21);
            lblLanguage.Margin = new Padding(4, 0, 4, 0);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(58, 21);
            lblLanguage.TabIndex = 0;
            lblLanguage.Text = "Idioma";
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(162, 18);
            cmbLanguage.Margin = new Padding(4);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(247, 29);
            cmbLanguage.TabIndex = 1;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // lblPageSize
            // 
            lblPageSize.AutoSize = true;
            lblPageSize.Location = new Point(13, 76);
            lblPageSize.Margin = new Padding(4, 0, 4, 0);
            lblPageSize.Name = "lblPageSize";
            lblPageSize.Size = new Size(136, 21);
            lblPageSize.TabIndex = 0;
            lblPageSize.Text = "Gastos por pagina";
            // 
            // numPage
            // 
            numPage.Location = new Point(162, 74);
            numPage.Margin = new Padding(4);
            numPage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPage.Name = "numPage";
            numPage.Size = new Size(247, 29);
            numPage.TabIndex = 2;
            numPage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPage.ValueChanged += numPage_ValueChanged;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(300, 157);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 59);
            btnSave.TabIndex = 3;
            btnSave.Text = "Guardar";
            btnSave.UseCompatibleTextRendering = true;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(13, 157);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(109, 59);
            btnBack.TabIndex = 4;
            btnBack.Text = "Volver";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 229);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(numPage);
            Controls.Add(lblPageSize);
            Controls.Add(cmbLanguage);
            Controls.Add(lblLanguage);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)numPage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLanguage;
        private ComboBox cmbLanguage;
        private Label lblPageSize;
        private NumericUpDown numPage;
        private Button btnSave;
        private Button btnBack;
    }
}