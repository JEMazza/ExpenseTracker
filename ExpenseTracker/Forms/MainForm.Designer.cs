namespace ExpenseTracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            mainMenuStrip = new MenuStrip();
            expenseToolStripMenuItem = new ToolStripMenuItem();
            expenseListToolStripMenuItem = new ToolStripMenuItem();
            expenseAddToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            lblLanguagePending = new Label();
            lblVersion = new Label();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { expenseToolStripMenuItem, reportsToolStripMenuItem, settingsToolStripMenuItem, closeToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(900, 29);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // expenseToolStripMenuItem
            // 
            expenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expenseListToolStripMenuItem, expenseAddToolStripMenuItem });
            expenseToolStripMenuItem.Name = "expenseToolStripMenuItem";
            expenseToolStripMenuItem.Size = new Size(69, 25);
            expenseToolStripMenuItem.Text = "Gastos";
            // 
            // expenseListToolStripMenuItem
            // 
            expenseListToolStripMenuItem.Name = "expenseListToolStripMenuItem";
            expenseListToolStripMenuItem.Size = new Size(136, 26);
            expenseListToolStripMenuItem.Text = "Lista";
            expenseListToolStripMenuItem.Click += listaToolStripMenuItem_Click;
            // 
            // expenseAddToolStripMenuItem
            // 
            expenseAddToolStripMenuItem.Name = "expenseAddToolStripMenuItem";
            expenseAddToolStripMenuItem.Size = new Size(136, 26);
            expenseAddToolStripMenuItem.Text = "Agregar";
            expenseAddToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(84, 25);
            reportsToolStripMenuItem.Text = "Reportes";
            reportsToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(120, 25);
            settingsToolStripMenuItem.Text = "Configuración";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(66, 25);
            closeToolStripMenuItem.Text = "Cerrar";
            closeToolStripMenuItem.Click += cerrarToolStripMenuItem_Click;
            // 
            // lblLanguagePending
            // 
            lblLanguagePending.AutoSize = true;
            lblLanguagePending.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLanguagePending.ForeColor = Color.Red;
            lblLanguagePending.Location = new Point(12, 56);
            lblLanguagePending.Name = "lblLanguagePending";
            lblLanguagePending.Size = new Size(114, 30);
            lblLanguagePending.TabIndex = 1;
            lblLanguagePending.Text = "Pendiente";
            lblLanguagePending.Visible = false;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersion.Location = new Point(12, 398);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(64, 21);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 428);
            Controls.Add(lblVersion);
            Controls.Add(lblLanguagePending);
            Controls.Add(mainMenuStrip);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Menu Principal";
            Load += MainForm_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem expenseToolStripMenuItem;
        private ToolStripMenuItem expenseListToolStripMenuItem;
        private ToolStripMenuItem expenseAddToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label lblLanguagePending;
        private Label lblVersion;
    }
}
