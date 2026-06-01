namespace ExpenseTracker.Forms {
    partial class ExpenseListForm {
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            lblPlace = new Label();
            chkListPlace = new CheckedListBox();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            lblType = new Label();
            chkListType = new CheckedListBox();
            chkTo = new CheckBox();
            chkFrom = new CheckBox();
            expenseDtoBindingSource = new BindingSource(components);
            lblPages = new Label();
            btnPrevious = new Button();
            btnNext = new Button();
            gBoxSummary = new GroupBox();
            lblTypeVal = new Label();
            lblPlaceVal = new Label();
            lblExpensesVal = new Label();
            lblTotalValue = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblTotal = new Label();
            dgvExpenses = new DataGridView();
            btnExport = new Button();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expenseDtoBindingSource).BeginInit();
            gBoxSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1024, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(78, 25);
            agregarToolStripMenuItem.Text = "Agregar";
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(lblPlace);
            groupBox1.Controls.Add(chkListPlace);
            groupBox1.Controls.Add(dtpTo);
            groupBox1.Controls.Add(dtpFrom);
            groupBox1.Controls.Add(lblType);
            groupBox1.Controls.Add(chkListType);
            groupBox1.Controls.Add(chkTo);
            groupBox1.Controls.Add(chkFrom);
            groupBox1.Location = new Point(11, 32);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(796, 272);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Busqueda";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(702, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(89, 237);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Location = new Point(364, 85);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(50, 21);
            lblPlace.TabIndex = 7;
            lblPlace.Text = "Lugar";
            // 
            // chkListPlace
            // 
            chkListPlace.FormattingEnabled = true;
            chkListPlace.HorizontalScrollbar = true;
            chkListPlace.Location = new Point(420, 85);
            chkListPlace.Name = "chkListPlace";
            chkListPlace.Size = new Size(276, 172);
            chkListPlace.TabIndex = 6;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(438, 28);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(129, 29);
            dtpTo.TabIndex = 5;
            dtpTo.Visible = false;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(83, 27);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(122, 29);
            dtpFrom.TabIndex = 1;
            dtpFrom.Visible = false;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(5, 85);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 21);
            lblType.TabIndex = 3;
            lblType.Text = "Tipo";
            // 
            // chkListType
            // 
            chkListType.FormattingEnabled = true;
            chkListType.Location = new Point(51, 85);
            chkListType.Name = "chkListType";
            chkListType.Size = new Size(283, 172);
            chkListType.TabIndex = 2;
            // 
            // chkTo
            // 
            chkTo.AutoSize = true;
            chkTo.Location = new Point(364, 31);
            chkTo.Name = "chkTo";
            chkTo.Size = new Size(68, 25);
            chkTo.TabIndex = 1;
            chkTo.Text = "Hasta";
            chkTo.UseVisualStyleBackColor = true;
            chkTo.CheckedChanged += chkTo_CheckedChanged;
            // 
            // chkFrom
            // 
            chkFrom.AutoSize = true;
            chkFrom.Location = new Point(5, 31);
            chkFrom.Name = "chkFrom";
            chkFrom.Size = new Size(72, 25);
            chkFrom.TabIndex = 0;
            chkFrom.Text = "Desde";
            chkFrom.UseVisualStyleBackColor = true;
            chkFrom.CheckedChanged += cBoxFrom_CheckedChanged;
            // 
            // expenseDtoBindingSource
            // 
            expenseDtoBindingSource.DataSource = typeof(ExpenseServices.DTOs.ExpenseDto);
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(812, 481);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(103, 21);
            lblPages.TabIndex = 3;
            lblPages.Text = "Pagina X de Y";
            lblPages.Visible = false;
            // 
            // btnPrevious
            // 
            btnPrevious.Enabled = false;
            btnPrevious.Location = new Point(812, 521);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(112, 38);
            btnPrevious.TabIndex = 9;
            btnPrevious.Text = "Anterior";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Visible = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(812, 580);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 38);
            btnNext.TabIndex = 10;
            btnNext.Text = "Siguiente";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Visible = false;
            btnNext.Click += btnNext_Click;
            // 
            // gBoxSummary
            // 
            gBoxSummary.Controls.Add(lblTypeVal);
            gBoxSummary.Controls.Add(lblPlaceVal);
            gBoxSummary.Controls.Add(lblExpensesVal);
            gBoxSummary.Controls.Add(lblTotalValue);
            gBoxSummary.Controls.Add(label3);
            gBoxSummary.Controls.Add(label2);
            gBoxSummary.Controls.Add(label1);
            gBoxSummary.Controls.Add(lblTotal);
            gBoxSummary.Location = new Point(812, 32);
            gBoxSummary.Name = "gBoxSummary";
            gBoxSummary.Size = new Size(200, 312);
            gBoxSummary.TabIndex = 11;
            gBoxSummary.TabStop = false;
            gBoxSummary.Text = "Resumen";
            gBoxSummary.Visible = false;
            // 
            // lblTypeVal
            // 
            lblTypeVal.AutoSize = true;
            lblTypeVal.Location = new Point(11, 251);
            lblTypeVal.Name = "lblTypeVal";
            lblTypeVal.Size = new Size(19, 21);
            lblTypeVal.TabIndex = 7;
            lblTypeVal.Text = "0";
            // 
            // lblPlaceVal
            // 
            lblPlaceVal.AutoEllipsis = true;
            lblPlaceVal.AutoSize = true;
            lblPlaceVal.Location = new Point(11, 165);
            lblPlaceVal.Name = "lblPlaceVal";
            lblPlaceVal.Size = new Size(19, 21);
            lblPlaceVal.TabIndex = 6;
            lblPlaceVal.Text = "0";
            // 
            // lblExpensesVal
            // 
            lblExpensesVal.AutoSize = true;
            lblExpensesVal.Location = new Point(77, 85);
            lblExpensesVal.Name = "lblExpensesVal";
            lblExpensesVal.Size = new Size(19, 21);
            lblExpensesVal.TabIndex = 5;
            lblExpensesVal.Text = "0";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(76, 40);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(49, 21);
            lblTotalValue.TabIndex = 4;
            lblTotalValue.Text = "$0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 219);
            label3.Name = "label3";
            label3.Size = new Size(158, 21);
            label3.TabIndex = 3;
            label3.Text = "Tipo con mas gastos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 128);
            label2.Name = "label2";
            label2.Size = new Size(168, 21);
            label2.TabIndex = 2;
            label2.Text = "Lugar con mas gastos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 85);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 1;
            label1.Text = "Gastos:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(11, 40);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 21);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total:";
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Location = new Point(11, 310);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.ShowEditingIcon = false;
            dgvExpenses.ShowRowErrors = false;
            dgvExpenses.Size = new Size(791, 308);
            dgvExpenses.TabIndex = 2;
            dgvExpenses.CellClick += dgvExpenses_CellClick;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(812, 365);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(192, 53);
            btnExport.TabIndex = 12;
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Visible = false;
            btnExport.Click += btnExport_Click;
            // 
            // ExpenseListForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 630);
            Controls.Add(btnExport);
            Controls.Add(gBoxSummary);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(lblPages);
            Controls.Add(dgvExpenses);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "ExpenseListForm";
            Text = "Lista de gastos";
            Load += ExpenseListForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)expenseDtoBindingSource).EndInit();
            gBoxSummary.ResumeLayout(false);
            gBoxSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private GroupBox groupBox1;
        private Label lblType;
        private CheckedListBox chkListType;
        private CheckBox chkTo;
        private CheckBox chkFrom;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Button btnSearch;
        private Label lblPlace;
        private CheckedListBox chkListPlace;
        private Label lblPages;
        private Button btnPrevious;
        private Button btnNext;
        private GroupBox gBoxSummary;
        private BindingSource expenseDtoBindingSource;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblTotal;
        private DataGridView dgvExpenses;
        private Label lblTypeVal;
        private Label lblPlaceVal;
        private Label lblExpensesVal;
        private Label lblTotalValue;
        private Button btnExport;
    }
}