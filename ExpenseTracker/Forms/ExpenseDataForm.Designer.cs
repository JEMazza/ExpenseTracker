namespace ExpenseTracker.Forms {
    partial class ExpenseDataForm {
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
            lblName = new Label();
            tBoxName = new TextBox();
            lblDate = new Label();
            lblCost = new Label();
            lblType = new Label();
            lblPlace = new Label();
            dtpDate = new DateTimePicker();
            numCost = new NumericUpDown();
            cmbType = new ComboBox();
            btnAction = new Button();
            btnBack = new Button();
            cmbPlace = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(13, 78);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre";
            // 
            // tBoxName
            // 
            tBoxName.Location = new Point(101, 78);
            tBoxName.Margin = new Padding(2, 3, 2, 3);
            tBoxName.Name = "tBoxName";
            tBoxName.Size = new Size(330, 29);
            tBoxName.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(13, 24);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(50, 21);
            lblDate.TabIndex = 2;
            lblDate.Text = "Fecha";
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(13, 129);
            lblCost.Margin = new Padding(4, 0, 4, 0);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(50, 21);
            lblCost.TabIndex = 4;
            lblCost.Text = "Costo";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(13, 179);
            lblType.Margin = new Padding(4, 0, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 21);
            lblType.TabIndex = 6;
            lblType.Text = "Tipo";
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Location = new Point(13, 237);
            lblPlace.Margin = new Padding(4, 0, 4, 0);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(50, 21);
            lblPlace.TabIndex = 8;
            lblPlace.Text = "Lugar";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(101, 24);
            dtpDate.Margin = new Padding(2, 3, 2, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(105, 29);
            dtpDate.TabIndex = 0;
            // 
            // numCost
            // 
            numCost.DecimalPlaces = 2;
            numCost.Location = new Point(101, 129);
            numCost.Margin = new Padding(2, 3, 2, 3);
            numCost.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(329, 29);
            numCost.TabIndex = 2;
            // 
            // cmbType
            // 
            cmbType.DisplayMember = "Id";
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(101, 176);
            cmbType.Margin = new Padding(2, 3, 2, 3);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(330, 29);
            cmbType.TabIndex = 3;
            cmbType.ValueMember = "Id";
            // 
            // btnAction
            // 
            btnAction.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAction.Location = new Point(272, 312);
            btnAction.Margin = new Padding(2, 3, 2, 3);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(187, 70);
            btnAction.TabIndex = 5;
            btnAction.Text = "Accion";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(11, 312);
            btnBack.Margin = new Padding(2, 3, 2, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(187, 70);
            btnBack.TabIndex = 6;
            btnBack.Text = "Volver";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbPlace
            // 
            cmbPlace.DisplayMember = "Id";
            cmbPlace.FormattingEnabled = true;
            cmbPlace.Location = new Point(101, 233);
            cmbPlace.Margin = new Padding(2, 3, 2, 3);
            cmbPlace.Name = "cmbPlace";
            cmbPlace.Size = new Size(330, 29);
            cmbPlace.TabIndex = 4;
            cmbPlace.ValueMember = "Id";
            // 
            // ExpenseDataForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 402);
            Controls.Add(cmbPlace);
            Controls.Add(btnBack);
            Controls.Add(btnAction);
            Controls.Add(cmbType);
            Controls.Add(numCost);
            Controls.Add(dtpDate);
            Controls.Add(lblPlace);
            Controls.Add(lblType);
            Controls.Add(lblCost);
            Controls.Add(lblDate);
            Controls.Add(tBoxName);
            Controls.Add(lblName);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "ExpenseDataForm";
            Text = "ExpenseDataForm";
            Load += ExpenseDataForm_Load;
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox tBoxName;
        private Label lblDate;
        private Label lblCost;
        private Label lblType;
        private Label lblPlace;
        private DateTimePicker dtpDate;
        private NumericUpDown numCost;
        private ComboBox cmbType;
        private Button btnAction;
        private Button btnBack;
        private ComboBox cmbPlace;
    }
}