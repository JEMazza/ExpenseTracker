using ExpenseTracker.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

namespace ExpenseTracker{
    public partial class MainForm : Form {

        private string _oldLang;

        public MainForm() {
            _oldLang = ConfigurationManager.AppSettings["Language"]?.ToString();
            InitializeComponent();
        }


        private void agregarToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var scope = Program.Services.CreateScope()) {
                using (var form = scope.ServiceProvider.GetRequiredService<ExpenseDataForm>()) {
                    form.ShowDialog();
                }
            }
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var scope = Program.Services.CreateScope()) {
                using (var form = scope.ServiceProvider.GetRequiredService<ExpenseListForm>()) {
                    form.ShowDialog();
                }
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var scope = Program.Services.CreateScope()) {
                using (var form = scope.ServiceProvider.GetRequiredService<ExpenseReportForm>()) {
                    form.ShowDialog();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Text = Resources.MessagesResource.ExpenseFormTitleMainMenu;
            expenseToolStripMenuItem.Text = Resources.MessagesResource.ExpenseLabel;
            expenseListToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelExpenseList;
            expenseAddToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelExpenseAdd;
            reportsToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelReports;
            closeToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelClose;
            settingsToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelSettings;
            lblLanguagePending.Text = Resources.MessagesResource.ExpenseMessageLanguageChanged;
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "Nightly";
            lblVersion.Text = String.Format(Resources.MessagesResource.ExpenseLabelVersion, version);
         }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var scope = Program.Services.CreateScope()) {
                using (var form = scope.ServiceProvider.GetRequiredService<SettingsForm>()) {
                    form.ShowDialog();
                    if (form.LanguageChanged) {
                        lblLanguagePending.Visible = _oldLang != ConfigurationManager.AppSettings["Language"]?.ToString();
                    }
                }
            }
        }

    }
}
