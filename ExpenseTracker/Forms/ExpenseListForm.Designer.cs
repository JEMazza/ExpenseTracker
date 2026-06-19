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
            addToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            gBoxFilter = new GroupBox();
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
            lblTypeWithMostExpenses = new Label();
            lblPlaceWithMostExpenses = new Label();
            lblExpense = new Label();
            lblTotal = new Label();
            dgvExpenses = new DataGridView();
            btnExport = new Button();
            menuStrip1.SuspendLayout();
            gBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expenseDtoBindingSource).BeginInit();
            gBoxSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, closeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1024, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(78, 25);
            addToolStripMenuItem.Text = "Agregar";
            addToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(66, 25);
            closeToolStripMenuItem.Text = "Cerrar";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // gBoxFilter
            // 
            gBoxFilter.Controls.Add(btnSearch);
            gBoxFilter.Controls.Add(lblPlace);
            gBoxFilter.Controls.Add(chkListPlace);
            gBoxFilter.Controls.Add(dtpTo);
            gBoxFilter.Controls.Add(dtpFrom);
            gBoxFilter.Controls.Add(lblType);
            gBoxFilter.Controls.Add(chkListType);
            gBoxFilter.Controls.Add(chkTo);
            gBoxFilter.Controls.Add(chkFrom);
            gBoxFilter.Location = new Point(11, 32);
            gBoxFilter.Margin = new Padding(2, 3, 2, 3);
            gBoxFilter.Name = "gBoxFilter";
            gBoxFilter.Padding = new Padding(2, 3, 2, 3);
            gBoxFilter.Size = new Size(796, 272);
            gBoxFilter.TabIndex = 3;
            gBoxFilter.TabStop = false;
            gBoxFilter.Text = "Busqueda";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(702, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(89, 237);
            btnSearch.TabIndex = 7;
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
            dtpTo.TabIndex = 4;
            dtpTo.Visible = false;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(83, 27);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(122, 29);
            dtpFrom.TabIndex = 2;
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
            chkListType.TabIndex = 5;
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
            gBoxSummary.Controls.Add(lblTypeWithMostExpenses);
            gBoxSummary.Controls.Add(lblPlaceWithMostExpenses);
            gBoxSummary.Controls.Add(lblExpense);
            gBoxSummary.Controls.Add(lblTotal);
            gBoxSummary.Location = new Point(812, 32);
            gBoxSummary.Name = "gBoxSummary";
            gBoxSummary.Size = new Size(200, 318);
            gBoxSummary.TabIndex = 11;
            gBoxSummary.TabStop = false;
            gBoxSummary.Text = "Resumen";
            gBoxSummary.Visible = false;
            // 
            // lblTypeVal
            // 
            lblTypeVal.AutoEllipsis = true;
            lblTypeVal.AutoSize = true;
            lblTypeVal.Location = new Point(3, 261);
            lblTypeVal.Name = "lblTypeVal";
            lblTypeVal.Size = new Size(19, 21);
            lblTypeVal.TabIndex = 7;
            lblTypeVal.Text = "0";
            lblTypeVal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPlaceVal
            // 
            lblPlaceVal.AutoEllipsis = true;
            lblPlaceVal.AutoSize = true;
            lblPlaceVal.Location = new Point(2, 164);
            lblPlaceVal.Name = "lblPlaceVal";
            lblPlaceVal.Size = new Size(19, 21);
            lblPlaceVal.TabIndex = 6;
            lblPlaceVal.Text = "0";
            lblPlaceVal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblExpensesVal
            // 
            lblExpensesVal.AutoSize = true;
            lblExpensesVal.Location = new Point(73, 85);
            lblExpensesVal.Name = "lblExpensesVal";
            lblExpensesVal.Size = new Size(19, 21);
            lblExpensesVal.TabIndex = 5;
            lblExpensesVal.Text = "0";
            lblExpensesVal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(56, 40);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(49, 21);
            lblTotalValue.TabIndex = 4;
            lblTotalValue.Text = "$0.00";
            lblTotalValue.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTypeWithMostExpenses
            // 
            lblTypeWithMostExpenses.AutoSize = true;
            lblTypeWithMostExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTypeWithMostExpenses.Location = new Point(0, 230);
            lblTypeWithMostExpenses.Name = "lblTypeWithMostExpenses";
            lblTypeWithMostExpenses.Size = new Size(158, 21);
            lblTypeWithMostExpenses.TabIndex = 3;
            lblTypeWithMostExpenses.Text = "Tipo con mas gastos";
            // 
            // lblPlaceWithMostExpenses
            // 
            lblPlaceWithMostExpenses.AutoSize = true;
            lblPlaceWithMostExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPlaceWithMostExpenses.Location = new Point(0, 128);
            lblPlaceWithMostExpenses.Name = "lblPlaceWithMostExpenses";
            lblPlaceWithMostExpenses.Size = new Size(168, 21);
            lblPlaceWithMostExpenses.TabIndex = 2;
            lblPlaceWithMostExpenses.Text = "Lugar con mas gastos";
            // 
            // lblExpense
            // 
            lblExpense.AutoSize = true;
            lblExpense.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblExpense.Location = new Point(0, 85);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(63, 21);
            lblExpense.TabIndex = 1;
            lblExpense.Text = "Gastos:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(0, 40);
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
            btnExport.TabIndex = 8;
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
            Controls.Add(gBoxFilter);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "ExpenseListForm";
            Text = "Lista de gastos";
            Load += ExpenseListForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gBoxFilter.ResumeLayout(false);
            gBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)expenseDtoBindingSource).EndInit();
            gBoxSummary.ResumeLayout(false);
            gBoxSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private GroupBox gBoxFilter;
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
        private Label lblTypeWithMostExpenses;
        private Label lblPlaceWithMostExpenses;
        private Label lblExpense;
        private Label lblTotal;
        private DataGridView dgvExpenses;
        private Label lblTypeVal;
        private Label lblPlaceVal;
        private Label lblExpensesVal;
        private Label lblTotalValue;
        private Button btnExport;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}