using ExpenseServices.Services;
using ExpenseTracker.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public partial class MainForm : Form {
        public MainForm() {
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

        private async void reportesToolStripMenuItem_Click(object sender, EventArgs e) {
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
            
        }
    }
}
