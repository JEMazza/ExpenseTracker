using ExpenseServices.DTOs;
using ExpenseServices.Requests;
using ExpenseServices.Services;
using ExpenseTracker.DisplayItems;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

namespace ExpenseTracker.Forms {
    public partial class ExpenseListForm : Form {

        private readonly ExpenseService _service;
        private readonly ExpensePlaceService _placeService;
        private readonly ExpenseTypeService _typeService;
        private bool _searched = false;
        private int _page = 1;
        private int _pages = 1;
        private int _size = 25;
        private ExpenseSearchRequest? _filter = null;
        private int _total = 0;
        private int sortIndex = -1;
        private bool _asc = true;

        public ExpenseListForm(ExpenseService service, ExpensePlaceService placeService, ExpenseTypeService typeService) {
            _service = service;
            _placeService = placeService;
            _typeService = typeService;
            InitializeComponent();
        }

        private void PrepareColumns() {
            if (dgvExpenses.Columns["UpdateExp"] == null) {
                dgvExpenses.Columns.Add(new DataGridViewButtonColumn() {
                    Name = "UpdateExp",
                    HeaderText = Resources.MessagesResource.ExpenseLabelTableAction,
                    Text = Resources.MessagesResource.ExpenseLabelActionModify,
                    UseColumnTextForButtonValue = true,
                });
            }
            if (dgvExpenses.Columns["RemoveExp"] == null) {
                dgvExpenses.Columns.Add(new DataGridViewButtonColumn() {
                    Name = "RemoveExp",
                    HeaderText = string.Empty,
                    Text = Resources.MessagesResource.ExpenseLabelActionDelete,
                    UseColumnTextForButtonValue = true,
                });
            }

        }

        private async Task LoadLists() {
            var typeChecked = chkListType.CheckedItems.OfType<ExpenseTypeDto>().Select(et => et.Id).ToHashSet();
            var placeChecked = chkListPlace.CheckedItems.OfType<ExpensePlaceDto>().Select(ep => ep.Id).ToHashSet();
            var places = await _placeService.GetPlaces();
            var types = await _typeService.GetTypes();
            chkListType.BeginUpdate();
            chkListPlace.BeginUpdate();
            chkListType.Items.Clear();
            chkListPlace.Items.Clear();
            chkListType.Items.AddRange(types.ToArray());
            chkListPlace.Items.AddRange(places.ToArray());
            if (typeChecked.Any()) {
                chkListType.Items.OfType<ExpenseTypeDto>().Where(et => typeChecked.Contains(et.Id)).ToList().ForEach(etc => {
                    var type = chkListType.Items.IndexOf(etc);
                    chkListType.SetItemChecked(type, true);
                });
            }
            if (placeChecked.Any()) {
                chkListPlace.Items.OfType<ExpensePlaceDto>().Where(ep => placeChecked.Contains(ep.Id)).ToList().ForEach(epc => {
                    var place = chkListPlace.Items.IndexOf(epc);
                    chkListPlace.SetItemChecked(place, true);
                });
            }
            chkListType.EndUpdate();
            chkListPlace.EndUpdate();
        }

        private ExpenseSearchRequest? PrepareFilter() {
            var filter = new ExpenseSearchRequest() {
                From = chkFrom.Checked ? dtpFrom.Value.Date : null,
                To = chkTo.Checked ? dtpTo.Value.Date : null,
                Places = chkListPlace.CheckedItems.Count > 0 ? chkListPlace.CheckedItems.OfType<ExpensePlaceDto>().Select(ep => ep.Id).ToArray() : [],
                Types = chkListType.CheckedItems.Count > 0 ? chkListType.CheckedItems.OfType<ExpenseTypeDto>().Select(et => et.Id).ToArray() : []
            };
            string msg = filter.Valid();
            if (!string.IsNullOrEmpty(msg)) {
                MessageBox.Show(msg, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return filter;
        }

        private void UpdatePages() {
            lblPages.Text = String.Format(Resources.MessagesResource.ExpenseLabelPages, _page, _pages);
        }

        private async Task<bool> LoadExpenses(ExpenseOrderEnum order = ExpenseOrderEnum.OrderByDate) {
            lblPages.Visible = false;
            if (!_searched) {
                _filter = PrepareFilter();
                _searched = true;
            }
            if (_filter == null) {
                return false;
            }
            var res = await _service.GetExpenses(_filter, _page, _size, order);
            dgvExpenses.DataSource = new BindingList<ExpenseDetailViewModel>(res.Select(e => new ExpenseDetailViewModel {
                Id = e.Id,
                Date = e.Date,
                Place = e.Place,
                Type = e.Type,
                Name = e.Name,
                Cost = $"${e.Price:N2}"
            }).ToList());
            PrepareColumns();
            dgvExpenses.AutoResizeColumns();
            lblPages.Visible = true;
            return true;
        }

        private async Task LoadSummary() {
            var summary = await _service.GetExpensesSummary(_filter);
            lblExpensesVal.Text = summary.Expenses.ToString();
            lblTotalValue.Text = $"${summary.Total:N2}";
            lblPlaceVal.Text = summary.highestPlace;
            lblTypeVal.Text = summary.highestType;
            _total = summary.Expenses;
            _pages = decimal.ToInt32(Math.Ceiling((Convert.ToDecimal(summary.Expenses) / _size)));
            if (summary.Expenses >= _size) {
                btnNext.Visible = true;
                btnNext.Enabled = true;
            }
            gBoxSummary.Visible = true;
        }

        private async void ExpenseListForm_Load(object sender, EventArgs e) {
            this.Text = Resources.MessagesResource.ExpenseFormTitleListExpenses;
            addToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelExpenseAdd;
            closeToolStripMenuItem.Text = Resources.MessagesResource.ExpenseMenuLabelClose;
            gBoxFilter.Text = Resources.MessagesResource.ExpenseGroupBoxFilterTitle;
            gBoxSummary.Text = Resources.MessagesResource.ExpenseLabelSummary;
            chkFrom.Text = Resources.MessagesResource.ExpenseLabelInputFrom;
            chkTo.Text = Resources.MessagesResource.ExpenseLabelInputTo;
            lblType.Text = Resources.MessagesResource.ExpenseLabelType;
            lblPlace.Text = Resources.MessagesResource.ExpenseLabelPlace;
            lblTotal.Text = Resources.MessagesResource.ExpenseLabelTotal;
            lblExpense.Text = Resources.MessagesResource.ExpenseLabelExpenses;
            lblPlaceWithMostExpenses.Text = Resources.MessagesResource.ExpenseLabelPlaceWithMostExpenses;
            lblTypeWithMostExpenses.Text = Resources.MessagesResource.ExpenseLabelTypeWithMostExpenses;
            btnNext.Text = Resources.MessagesResource.ExpenseLabelActionNext;
            btnPrevious.Text = Resources.MessagesResource.ExpenseLabelActionPrevious;
            btnExport.Text = Resources.MessagesResource.ExpenseLabelActionExport;
            btnSearch.Text = Resources.MessagesResource.ExpenseLabelActionFilter;
            await LoadLists();
        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
            _searched = false;
            try {
                sortIndex = -1;
                btnSearch.Enabled = false;
                btnNext.Visible = false;
                btnPrevious.Visible = false;
                btnExport.Visible = false;
                btnExport.Enabled = false;
                _page = 1;
                _size = 25;
                bool loaded = await LoadExpenses();
                if (!loaded) {
                    return;
                }
                await LoadSummary();
                UpdatePages();
                btnExport.Visible = true;
                btnExport.Enabled = true;

            }
            catch (Exception ex) {
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                btnSearch.Enabled = true;
                UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }

        }

        private void cBoxFrom_CheckedChanged(object sender, EventArgs e) {
            dtpFrom.Visible = chkFrom.Checked;
            dtpFrom.Enabled = chkFrom.Checked;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e) {
            dtpTo.Visible = chkTo.Checked;
            dtpTo.Visible = chkTo.Checked;
        }

        private async void agregarToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var scope = Program.Services.CreateScope()) {
                using (var form = scope.ServiceProvider.GetRequiredService<ExpenseDataForm>()) {
                    form.ShowDialog();
                    if (_searched && form.refresh && _filter != null) {
                        await LoadExpenses();
                        await LoadSummary();
                    }
                }
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e) {
            UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
            try {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                _page--;
                await LoadExpenses();
                UpdatePages();
            }
            catch (Exception ex) {
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                btnNext.Enabled = true;
                btnNext.Visible = true;
                btnPrevious.Enabled = _page != 1;
                btnPrevious.Visible = _page != 1;
                UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e) {
            try {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                _page++;
                await LoadExpenses();
                UpdatePages();
            }
            catch (Exception ex) {
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                btnPrevious.Enabled = true;
                btnPrevious.Visible = true;
                if (_total <= _page * _size) {
                    btnNext.Enabled = false;
                    btnNext.Visible = false;
                }
                else {
                    btnNext.Enabled = true;
                    btnNext.Visible = true;
                }
            }
        }

        private async void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1 && dgvExpenses.Columns[e.ColumnIndex].Index < 5) {
                //Order
                int newSort = e.ColumnIndex;
                if (newSort != sortIndex) {
                    sortIndex = newSort;
                    _asc = true;
                }
                else {
                    _asc = !_asc;
                }
                ExpenseOrderEnum order = ExpenseOrderEnum.OrderByDate;
                switch (sortIndex) {
                    case 2:
                        order = _asc ? ExpenseOrderEnum.OrderByDate : ExpenseOrderEnum.OrderByDateDesc;
                        break;
                    case 3:
                        order = _asc ? ExpenseOrderEnum.OrderByName : ExpenseOrderEnum.OrderByNameDesc;
                        break;
                    case 4:
                        order = _asc ? ExpenseOrderEnum.OrderByCost : ExpenseOrderEnum.OrderByCostDesc;
                        break;
                }
                await LoadExpenses(order);
            }
            else if (e.RowIndex >= 0) {
                //Update
                if (dgvExpenses.Columns[e.ColumnIndex].Name == "UpdateExp") {
                    var exp = dgvExpenses.Rows[e.RowIndex].DataBoundItem as ExpenseDetailViewModel;
                    using (var scope = Program.Services.CreateScope()) {
                        using (var form = scope.ServiceProvider.GetRequiredService<ExpenseDataForm>()) {
                            form.LoadId(exp.Id);
                            form.ShowDialog();
                            if (form.refresh) {
                                await LoadExpenses();
                            }
                        }
                    }
                }
                //Remove
                else if (dgvExpenses.Columns[e.ColumnIndex].Name == "RemoveExp") {
                    var exp = dgvExpenses.Rows[e.RowIndex].DataBoundItem as ExpenseDetailViewModel;
                    var confirm = MessageBox.Show(Resources.MessagesResource.ExpenseMessageDeleteWarning, Resources.MessagesResource.ExpenseMessageBoxTitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes) {
                        try {
                            dgvExpenses.Enabled = false;
                            btnSearch.Enabled = false;
                            btnNext.Enabled = false;
                            btnPrevious.Enabled = false;
                            bool removed = await _service.RemoveExpense(exp.Id);
                            if (removed) {
                                MessageBox.Show(Resources.MessagesResource.ExpenseMessageBoxTitleWarning, Resources.MessagesResource.ExpenseMessageBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                int oldPages = _pages;
                                await LoadSummary();
                                if (_pages < oldPages) {
                                    _page--;
                                }
                                await LoadExpenses();
                            }
                            else {
                                MessageBox.Show(Resources.MessagesResource.ExpenseMessageExpenseNotFound, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally {
                            dgvExpenses.Enabled = true;
                            btnSearch.Enabled = true;
                            btnNext.Enabled = _pages >= 1 && _page < _pages;
                            btnPrevious.Enabled = _pages >= 1 && _page > 1;
                        }
                    }
                }
            }
        }

        private async void btnExport_Click(object sender, EventArgs e) {
            btnSearch.Enabled = false;
            btnExport.Enabled = false;
            bool reenableNext = false;
            bool reenablePrevious = false;
            if (btnNext.Visible) {
                btnNext.Enabled = false;
                reenableNext = true;
            }
            if (btnPrevious.Visible) {
                btnPrevious.Enabled = false;
                reenablePrevious = true;
            }
            try {
                string fileName = Resources.MessagesResource.ExpenseLabel + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "*.xls | *.xlsx";
                saveDialog.Title = Resources.MessagesResource.ExpenseExportFileDialogTitle;
                saveDialog.FileName = fileName;
                var saveResult = saveDialog.ShowDialog();
                if (saveResult == DialogResult.OK) {
                    UseWaitCursor = true;
                    Cursor.Current = Cursors.WaitCursor;
                    using (var file = new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write)) {
                        using (var data = await _service.ExportExpenses(_filter)) {
                            await data.CopyToAsync(file);
                        }
                    }
                    MessageBox.Show(Resources.MessagesResource.ExpenseMessageExportSuccess, Resources.MessagesResource.ExpenseMessageBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
                if (reenableNext) {
                    btnNext.Enabled = true;
                }
                if (reenablePrevious) {
                    btnPrevious.Enabled = true;
                }
                btnSearch.Enabled = true;
                btnExport.Enabled = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
