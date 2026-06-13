namespace ExpenseTracker.Forms {
    partial class ExpenseReportForm {
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
            gBoxSearch = new GroupBox();
            btnSearch = new Button();
            dtpTo = new DateTimePicker();
            chkTo = new CheckBox();
            dtpFrom = new DateTimePicker();
            chkFrom = new CheckBox();
            reportTab = new TabControl();
            expTab = new TabPage();
            expenseTop10Plot = new ScottPlot.WinForms.FormsPlot();
            lblExpPage = new Label();
            btnExpPrevious = new Button();
            btnExpNext = new Button();
            dgvExpenses = new DataGridView();
            placeTab = new TabPage();
            placeGroupPlot = new ScottPlot.WinForms.FormsPlot();
            dgvPlaces = new DataGridView();
            typeTab = new TabPage();
            typeGroupPlot = new ScottPlot.WinForms.FormsPlot();
            dgvTypes = new DataGridView();
            btnExport = new Button();
            gBoxSearch.SuspendLayout();
            reportTab.SuspendLayout();
            expTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            placeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlaces).BeginInit();
            typeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTypes).BeginInit();
            SuspendLayout();
            // 
            // gBoxSearch
            // 
            gBoxSearch.Controls.Add(btnSearch);
            gBoxSearch.Controls.Add(dtpTo);
            gBoxSearch.Controls.Add(chkTo);
            gBoxSearch.Controls.Add(dtpFrom);
            gBoxSearch.Controls.Add(chkFrom);
            gBoxSearch.Location = new Point(12, 13);
            gBoxSearch.Margin = new Padding(3, 4, 3, 4);
            gBoxSearch.Name = "gBoxSearch";
            gBoxSearch.Padding = new Padding(3, 4, 3, 4);
            gBoxSearch.Size = new Size(394, 115);
            gBoxSearch.TabIndex = 0;
            gBoxSearch.TabStop = false;
            gBoxSearch.Text = "Filtro";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(241, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 74);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(114, 71);
            dtpTo.Margin = new Padding(3, 4, 3, 4);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(121, 29);
            dtpTo.TabIndex = 3;
            dtpTo.Visible = false;
            // 
            // chkTo
            // 
            chkTo.AutoSize = true;
            chkTo.Location = new Point(6, 74);
            chkTo.Margin = new Padding(3, 4, 3, 4);
            chkTo.Name = "chkTo";
            chkTo.Size = new Size(68, 25);
            chkTo.TabIndex = 2;
            chkTo.Text = "Hasta";
            chkTo.UseVisualStyleBackColor = true;
            chkTo.CheckedChanged += chkTo_CheckedChanged;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(114, 27);
            dtpFrom.Margin = new Padding(3, 4, 3, 4);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(121, 29);
            dtpFrom.TabIndex = 1;
            dtpFrom.Visible = false;
            // 
            // chkFrom
            // 
            chkFrom.AutoSize = true;
            chkFrom.Location = new Point(6, 30);
            chkFrom.Margin = new Padding(3, 4, 3, 4);
            chkFrom.Name = "chkFrom";
            chkFrom.Size = new Size(72, 25);
            chkFrom.TabIndex = 0;
            chkFrom.Text = "Desde";
            chkFrom.UseVisualStyleBackColor = true;
            chkFrom.CheckedChanged += chkFrom_CheckedChanged;
            // 
            // reportTab
            // 
            reportTab.Controls.Add(expTab);
            reportTab.Controls.Add(placeTab);
            reportTab.Controls.Add(typeTab);
            reportTab.Location = new Point(12, 135);
            reportTab.Name = "reportTab";
            reportTab.SelectedIndex = 0;
            reportTab.Size = new Size(1110, 589);
            reportTab.TabIndex = 2;
            reportTab.Visible = false;
            // 
            // expTab
            // 
            expTab.Controls.Add(expenseTop10Plot);
            expTab.Controls.Add(lblExpPage);
            expTab.Controls.Add(btnExpPrevious);
            expTab.Controls.Add(btnExpNext);
            expTab.Controls.Add(dgvExpenses);
            expTab.Location = new Point(4, 30);
            expTab.Name = "expTab";
            expTab.Padding = new Padding(3);
            expTab.Size = new Size(1102, 555);
            expTab.TabIndex = 0;
            expTab.Text = "Gastos";
            expTab.UseVisualStyleBackColor = true;
            // 
            // expenseTop10Plot
            // 
            expenseTop10Plot.Location = new Point(771, 6);
            expenseTop10Plot.Name = "expenseTop10Plot";
            expenseTop10Plot.Size = new Size(325, 452);
            expenseTop10Plot.TabIndex = 4;
            // 
            // lblExpPage
            // 
            lblExpPage.AutoSize = true;
            lblExpPage.Location = new Point(773, 461);
            lblExpPage.Name = "lblExpPage";
            lblExpPage.Size = new Size(103, 21);
            lblExpPage.TabIndex = 3;
            lblExpPage.Text = "Pagina X de Y";
            // 
            // btnExpPrevious
            // 
            btnExpPrevious.Location = new Point(773, 498);
            btnExpPrevious.Name = "btnExpPrevious";
            btnExpPrevious.Size = new Size(125, 51);
            btnExpPrevious.TabIndex = 2;
            btnExpPrevious.Text = "Anterior";
            btnExpPrevious.UseVisualStyleBackColor = true;
            btnExpPrevious.Click += btnExpPrevious_Click;
            // 
            // btnExpNext
            // 
            btnExpNext.Location = new Point(960, 498);
            btnExpNext.Name = "btnExpNext";
            btnExpNext.Size = new Size(136, 51);
            btnExpNext.TabIndex = 1;
            btnExpNext.Text = "Siguiente";
            btnExpNext.UseVisualStyleBackColor = true;
            btnExpNext.Click += btnExpNext_Click;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeColumns = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Location = new Point(6, 6);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.Size = new Size(761, 543);
            dgvExpenses.TabIndex = 0;
            dgvExpenses.TabStop = false;
            // 
            // placeTab
            // 
            placeTab.Controls.Add(placeGroupPlot);
            placeTab.Controls.Add(dgvPlaces);
            placeTab.Location = new Point(4, 24);
            placeTab.Name = "placeTab";
            placeTab.Padding = new Padding(3);
            placeTab.Size = new Size(1102, 561);
            placeTab.TabIndex = 1;
            placeTab.Text = "Lugares";
            placeTab.UseVisualStyleBackColor = true;
            // 
            // placeGroupPlot
            // 
            placeGroupPlot.Location = new Point(665, 6);
            placeGroupPlot.Name = "placeGroupPlot";
            placeGroupPlot.Size = new Size(431, 543);
            placeGroupPlot.TabIndex = 4;
            // 
            // dgvPlaces
            // 
            dgvPlaces.AllowUserToAddRows = false;
            dgvPlaces.AllowUserToDeleteRows = false;
            dgvPlaces.AllowUserToResizeColumns = false;
            dgvPlaces.AllowUserToResizeRows = false;
            dgvPlaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlaces.Location = new Point(6, 6);
            dgvPlaces.MultiSelect = false;
            dgvPlaces.Name = "dgvPlaces";
            dgvPlaces.RowHeadersVisible = false;
            dgvPlaces.Size = new Size(653, 543);
            dgvPlaces.TabIndex = 3;
            dgvPlaces.TabStop = false;
            // 
            // typeTab
            // 
            typeTab.Controls.Add(typeGroupPlot);
            typeTab.Controls.Add(dgvTypes);
            typeTab.Location = new Point(4, 24);
            typeTab.Name = "typeTab";
            typeTab.Size = new Size(1102, 561);
            typeTab.TabIndex = 2;
            typeTab.Text = "Tipo";
            typeTab.UseVisualStyleBackColor = true;
            // 
            // typeGroupPlot
            // 
            typeGroupPlot.Location = new Point(668, 6);
            typeGroupPlot.Name = "typeGroupPlot";
            typeGroupPlot.Size = new Size(431, 543);
            typeGroupPlot.TabIndex = 5;
            // 
            // dgvTypes
            // 
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.AllowUserToResizeColumns = false;
            dgvTypes.AllowUserToResizeRows = false;
            dgvTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypes.Location = new Point(6, 6);
            dgvTypes.MultiSelect = false;
            dgvTypes.Name = "dgvTypes";
            dgvTypes.RowHeadersVisible = false;
            dgvTypes.ShowEditingIcon = false;
            dgvTypes.ShowRowErrors = false;
            dgvTypes.Size = new Size(656, 543);
            dgvTypes.TabIndex = 5;
            dgvTypes.TabStop = false;
            // 
            // btnExport
            // 
            btnExport.Enabled = false;
            btnExport.Location = new Point(427, 43);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(153, 73);
            btnExport.TabIndex = 3;
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Visible = false;
            btnExport.Click += btnExport_Click;
            // 
            // ExpenseReportForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 729);
            Controls.Add(btnExport);
            Controls.Add(reportTab);
            Controls.Add(gBoxSearch);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ExpenseReportForm";
            Text = "ExpenseReportForm";
            Load += ExpenseReportForm_Load;
            gBoxSearch.ResumeLayout(false);
            gBoxSearch.PerformLayout();
            reportTab.ResumeLayout(false);
            expTab.ResumeLayout(false);
            expTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            placeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlaces).EndInit();
            typeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTypes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gBoxSearch;
        private DateTimePicker dtpFrom;
        private CheckBox chkFrom;
        private Button btnSearch;
        private DateTimePicker dtpTo;
        private CheckBox chkTo;
        private TabControl reportTab;
        private TabPage expTab;
        private TabPage placeTab;
        private TabPage typeTab;
        private Button btnExpPrevious;
        private Button btnExpNext;
        private DataGridView dgvExpenses;
        private Label lblExpPage;
        private DataGridView dgvPlaces;
        private DataGridView dgvTypes;
        private ScottPlot.WinForms.FormsPlot placeGroupPlot;
        private ScottPlot.WinForms.FormsPlot expenseTop10Plot;
        private ScottPlot.WinForms.FormsPlot typeGroupPlot;
        private Button btnExport;
    }
}