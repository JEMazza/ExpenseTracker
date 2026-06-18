using DocumentFormat.OpenXml.Wordprocessing;
using ExpenseTracker.DisplayItems;
using System.Configuration;
using System.Drawing.Printing;

namespace ExpenseTracker.Forms {
    public partial class SettingsForm : Form {

        private int _oldPageValue;
        private string _oldLang;
        private bool _ready = false;
        public bool LanguageChanged = false;

        public SettingsForm() {
            InitializeComponent();
        }

        private void RefreshSettingValues() {
            _oldLang = ConfigurationManager.AppSettings["Language"]?.ToString();
            decimal pageSize;
            if (!decimal.TryParse(ConfigurationManager.AppSettings["PageSize"], out pageSize)) {
                throw new Exception("PAGE SIZE PROPERTY NOT FOUND");
            }
            _oldPageValue = Convert.ToInt32(pageSize);

        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            RefreshSettingValues();
            cmbLanguage.Items.Add(new LanguageViewModel("es", Resources.MessagesResource.ExpenseLabelLanguageSpanish));
            cmbLanguage.Items.Add(new LanguageViewModel("en", Resources.MessagesResource.ExpenseLabelLanguageEnglish));
            cmbLanguage.ValueMember = "Ticker";
            cmbLanguage.DisplayMember = "Name";
            cmbLanguage.SelectedIndex = _oldLang == "es" ? 0 : 1;
            numPage.Maximum = int.MaxValue;
            decimal pageSize;
            if (!decimal.TryParse(ConfigurationManager.AppSettings["PageSize"], out pageSize)) {
                throw new Exception("PAGE SIZE PROPERTY NOT FOUND");
            }
            lblLanguage.Text = Resources.MessagesResource.ExpenseLabelLanguage;
            lblPageSize.Text = Resources.MessagesResource.ExpenseLabelPageSize;
            btnBack.Text = Resources.MessagesResource.ExpenseLabelActionBack;
            numPage.Value = _oldPageValue;
            this.Text = Resources.MessagesResource.ExpenseFormTitleSettings;
            _ready = true;

        }

        private void btnBack_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(numPage.Value < 1) {
                MessageBox.Show(Resources.MessagesResource.ExpenseMessagePageSizeError, Resources.MessagesResource.ExpenseMessageBoxTitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int oldPageSize;
            if (!int.TryParse(config.AppSettings.Settings["PageSize"].Value, out oldPageSize)) {
                throw new Exception("PAGE SIZE PROPERTY NOT FOUND");
            }
            bool pageChange = false;
            bool langChange = false;
            DialogResult pageConfirm;
            int pageSize = Convert.ToInt32(Math.Floor(numPage.Value));
            if (pageSize != oldPageSize) {
                if (pageSize < 15) {
                    pageConfirm = MessageBox.Show(String.Format(Resources.MessagesResource.ExpenseMessagePageChangeWarningUnder10, pageSize), Resources.MessagesResource.ExpenseMessageBoxTitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    pageChange = pageConfirm == DialogResult.Yes;
                }
                else if (pageSize > 100) {
                    pageConfirm = MessageBox.Show(String.Format(Resources.MessagesResource.ExpenseMessagePageChangeWarningOver100, pageSize), Resources.MessagesResource.ExpenseMessageBoxTitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    pageChange = pageConfirm == DialogResult.Yes;
                }
                else {
                    pageChange = true;
                }
                config.AppSettings.Settings["PageSize"].Value = pageSize.ToString();
            }
            var selectedLang = cmbLanguage.SelectedItem as LanguageViewModel;
            if(selectedLang.Ticker != _oldLang) {
                config.AppSettings.Settings["Language"].Value = selectedLang.Ticker;
                langChange = true;
                LanguageChanged = true;
            }
            if (pageChange || langChange) {
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageSettingsChangeSuccess, Resources.MessagesResource.ExpenseMessageBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnSave.Visible = false;
            btnSave.Enabled = false;
        }

        private void numPage_ValueChanged(object sender, EventArgs e) {
            if (_ready) {
                btnSave.Enabled = numPage.Value != _oldPageValue;
                btnSave.Visible = numPage.Value != _oldPageValue;
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            if (_ready) {
                var lang = cmbLanguage.SelectedItem as LanguageViewModel;
                btnSave.Visible = lang.Ticker != _oldLang;
                btnSave.Enabled = lang.Ticker != _oldLang;
            }
        }
    }
}
