using ExpenseServices.Requests;
using ExpenseServices.Services;
using ExpenseTracker.DisplayItems;
using ScottPlot;
using System.ComponentModel;
using System.Data;
using Microsoft.Extensions.Logging;
using ScottPlot.Plottables;


namespace ExpenseTracker.Forms {
    public partial class ExpenseReportForm : Form {

        private readonly ExpenseService _expServ;
        private readonly ExpensePlaceService _placeServ;
        private readonly ExpenseTypeService _typeServ;
        private readonly ReportService _reportService;
        private readonly ILogger<ExpenseReportForm> _logger;

        private int _page = 1;
        private int _total = 1;
        private int _totalPages = 1;
        private ExpenseSearchRequest _filter;

        public ExpenseReportForm(ExpenseService expServ, ExpensePlaceService placeServ, ExpenseTypeService typeServ, ReportService reportService, ILogger<ExpenseReportForm> logger) {
            _expServ = expServ;
            _placeServ = placeServ;
            _typeServ = typeServ;
            _reportService = reportService;
            _logger = logger;
            InitializeComponent();
        }

        private void ExpenseReportForm_Load(object sender, EventArgs e) {
            btnSearch.Text = Resources.MessagesResource.ExpenseLabelActionFilter;
            btnExpNext.Text = Resources.MessagesResource.ExpenseLabelActionNext;
            btnExpPrevious.Text = Resources.MessagesResource.ExpenseLabelActionPrevious;
            btnExport.Text = Resources.MessagesResource.ExpenseLabelActionExport;
            chkFrom.Text = Resources.MessagesResource.ExpenseLabelInputFrom;
            chkTo.Text = Resources.MessagesResource.ExpenseLabelInputTo;
            reportTab.TabPages[0].Text = Resources.MessagesResource.ExpenseLabel;
            reportTab.TabPages[1].Text = Resources.MessagesResource.ExpenseLabelPlace;
            reportTab.TabPages[2].Text = Resources.MessagesResource.ExpenseLabelType;
            this.Text=Resources.MessagesResource.ExpenseFormTitleListExpenses;
        }

        private void PrepareExpColumns() {
            if (dgvExpenses.Columns["Date"] != null) {
                dgvExpenses.Columns["Date"].HeaderText = Resources.MessagesResource.ExpenseLabelDate;
            }
            if (dgvExpenses.Columns["Name"] != null) {
                dgvExpenses.Columns["Name"].HeaderText = Resources.MessagesResource.ExpenseLabelName;
            }
            if (dgvExpenses.Columns["Cost"] != null) {
                dgvExpenses.Columns["Cost"].HeaderText = Resources.MessagesResource.ExpenseLabelCost;
            }
            if (dgvExpenses.Columns["Place"] != null) {
                dgvExpenses.Columns["Place"].HeaderText = Resources.MessagesResource.ExpenseLabelPlace;
            }
            if (dgvExpenses.Columns["Type"] != null) {
                dgvExpenses.Columns["Type"].HeaderText = Resources.MessagesResource.ExpenseLabelType;
            }
            dgvExpenses.AutoResizeColumns();
        }

        private void PrepareTypeAndPlaceColumns() {
            if (dgvPlaces.Columns["Name"] != null) {
                dgvPlaces.Columns["Name"].HeaderText=Resources.MessagesResource.ExpenseLabelName;
            }
            if (dgvPlaces.Columns["Total"] != null) {
                dgvPlaces.Columns["Total"].HeaderText=Resources.MessagesResource.ExpenseLabelTotal;
            }
            if (dgvPlaces.Columns["Count"] != null) {
                dgvPlaces.Columns["Count"].HeaderText = Resources.MessagesResource.ExpenseLabelCount;
            }
            if (dgvTypes.Columns["Name"] != null) {
                dgvTypes.Columns["Name"].HeaderText = Resources.MessagesResource.ExpenseLabelName;
            }
            if (dgvTypes.Columns["Total"] != null) {
                dgvTypes.Columns["Total"].HeaderText = Resources.MessagesResource.ExpenseLabelTotal;
            }
            if (dgvTypes.Columns["Count"] != null) {
                dgvTypes.Columns["Count"].HeaderText = Resources.MessagesResource.ExpenseLabelCount;
            }
            reportTab.SelectedTab = placeTab;
            dgvPlaces.AutoResizeColumns();
            reportTab.SelectedTab = typeTab;
            dgvTypes.AutoResizeColumns();
            reportTab.SelectedTab = expTab;
        }

        private void UpdateExpViews() {
            lblExpPage.Text = String.Format(Resources.MessagesResource.ExpenseLabelPages, _page, _totalPages);
            dgvExpenses.AutoResizeColumns();
        }

        private void chkFrom_CheckedChanged(object sender, EventArgs e) {
            dtpFrom.Visible = chkFrom.Checked;
            dtpFrom.Enabled = chkFrom.Checked;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e) {
            dtpTo.Visible = chkTo.Checked;
            dtpTo.Enabled = chkTo.Checked;

        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            var request = new ExpenseSearchRequest() {
                From = chkFrom.Checked ? dtpFrom.Value.Date : null,
                To = chkTo.Checked ? dtpTo.Value.Date : null
            };
            string msg = request.Valid();
            if (!string.IsNullOrWhiteSpace(msg)) {
                MessageBox.Show(msg, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _filter = request;
            try {
                placeGroupPlot.Plot.Clear();
                typeGroupPlot.Plot.Clear();
                expenseTop5Plot.Plot.Clear();
                _page = 1;
                _totalPages = 1;
                btnSearch.Enabled = false;
                btnExpPrevious.Enabled = false;
                btnExpPrevious.Visible = false;
                btnExpNext.Visible = false;
                btnExpNext.Enabled = false;
                btnExport.Visible = false;
                btnExport.Enabled = false;
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                _total = await _expServ.GetExpensesCount(request);
                var exp = await _expServ.GetExpenses(request, _page, 25);
                var types = await _typeServ.GetTypesSummary(request.From, request.To);
                var places = await _placeServ.GetPlaceSummary(request.From, request.To);
                var expChart = (await _expServ.GetTop5Expenses(request));
                _totalPages = decimal.ToInt32(Math.Ceiling((decimal)_total / 25));
                dgvExpenses.DataSource = new BindingList<ExpenseDetailViewModel>(exp.Select(e => new ExpenseDetailViewModel {
                    Id = e.Id,
                    Date = e.Date,
                    Place = e.Place,
                    Type = e.Type,
                    Name = e.Name,
                    Cost = $"${e.Price:N2}"
                }).ToList());
                dgvTypes.DataSource = new BindingList<ExpenseReportViewModels>(types.Select(et => new ExpenseReportViewModels { Count = et.Count.ToString(), Name = et.Name, Total = $"${et.Total:N2}" }).ToList());
                dgvPlaces.DataSource = new BindingList<ExpenseReportViewModels>(places.Select(et => new ExpenseReportViewModels { Count = et.Count.ToString(), Name = et.Name, Total = $"${et.Total:N2}" }).ToList());
                int i = 0;
                var palette = new ScottPlot.Palettes.Category10();
                var typeData = new List<PieSlice>();
                foreach (var type in types.Take(9)) {
                    typeData.Add(new() {
                        Value = type.Total,
                        FillColor = palette.GetColor(i++),
                        LegendText = type.Name,
                    });
                }
                if (types.Count() > 9) {
                    typeData.Add(new() {
                        Value = types.Skip(9).Sum(t => t.Total),
                        LegendText = "Others",
                        FillColor = ScottPlot.Color.Gray(1),
                    });
                }
                i = 0;
                var placeData = new List<PieSlice>();
                foreach (var place in places.Take(9)) {
                    placeData.Add(new() {
                        Value = place.Total,
                        FillColor = palette.GetColor(i++),
                        LegendText = place.Name,
                    });
                }
                if (places.Count() > 9) {
                    placeData.Add(new() {
                        Value = places.Skip(9).Sum(p => p.Total),
                        FillColor = ScottPlot.Color.Gray(3),
                        LegendText = "Others",
                    });
                }
                i = 1;
                var expData = new List<Bar>();
                foreach (var expD in expChart) {
                    BarPlot barplot = expenseTop5Plot.Plot.Add.Bar(new Bar {
                        Value = expD.Total,
                        FillColor = palette.GetColor(i),
                        Position = i
                    });
                    barplot.LegendText = expD.Date;
                    i += 2;
                }
                placeGroupPlot.Plot.Add.Pie(placeData);
                placeGroupPlot.Plot.HideAxesAndGrid();
                placeGroupPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
                placeGroupPlot.Enabled = false;
                placeGroupPlot.Refresh();
                typeGroupPlot.Plot.Add.Pie(typeData);
                typeGroupPlot.Plot.HideAxesAndGrid();
                typeGroupPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
                typeGroupPlot.Refresh();
                typeGroupPlot.Enabled = false;
                var barPlot = expenseTop5Plot.Plot.Add.Bars(expData.ToArray());                               
                if (expChart.Any()) {
                    expenseTop5Plot.Plot.Axes.SetLimitsX(0, i+7);
                    expenseTop5Plot.Plot.Axes.SetLimitsY(0, expChart.Max(ec => ec.Total) + 450);
                    expenseTop5Plot.Plot.ShowLegend(Alignment.LowerRight);
                }
                expenseTop5Plot.Refresh();
                expenseTop5Plot.Plot.HideGrid();
                expenseTop5Plot.Enabled = false;
                reportTab.Visible = true;                
                UpdateExpViews();
                PrepareExpColumns();
                PrepareTypeAndPlaceColumns();
                btnExpNext.Visible = _total > 25;
                btnExpNext.Enabled = _total > 25;
                btnExport.Visible = true;
                btnExport.Enabled = true;
                this.Refresh();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error when generating the expense report");
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                btnSearch.Enabled = true;
            }
        }

        private async void btnExpNext_Click(object sender, EventArgs e) {
            try {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                _page++;
                var exp = await _expServ.GetExpenses(_filter, _page, 25);
                dgvExpenses.DataSource = new BindingList<ExpenseDetailViewModel>(exp.Select(e => new ExpenseDetailViewModel {
                    Id = e.Id,
                    Date = e.Date,
                    Place = e.Place,
                    Type = e.Type,
                    Name = e.Name,
                    Cost = $"${e.Price}"
                }).ToList());
                btnExpPrevious.Visible = true;
                btnExpPrevious.Enabled = true;
                UpdateExpViews();
            }
            catch (Exception ex) {
                _page--;
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                btnExpNext.Enabled = (_page * 25 < _total);
                btnExpNext.Visible = (_page * 25 < _total);
            }
        }

        private async void btnExpPrevious_Click(object sender, EventArgs e) {
            try {
                _page--;
                var exp = await _expServ.GetExpenses(_filter, _page, 25);
                dgvExpenses.DataSource = new BindingList<ExpenseDetailViewModel>(exp.Select(e => new ExpenseDetailViewModel {
                    Id = e.Id,
                    Date = e.Date,
                    Place = e.Place,
                    Type = e.Type,
                    Name = e.Name,
                    Cost = $"${e.Price}"
                }).ToList());
                UpdateExpViews();
                btnExpNext.Visible = true;
                btnExpNext.Enabled = true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error when generating obtaning expenses in report");
                _page++;
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                btnExpPrevious.Enabled = (_page != 1);
                btnExpPrevious.Visible = (_page != 1);
            }

        }

        private async void btnExport_Click(object sender, EventArgs e) {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            bool reenableNext = false;
            bool reenablePrevious = false;
            try {
                btnSearch.Enabled = false;
                btnExport.Enabled = false;
                if (btnExpNext.Visible) {
                    btnExpNext.Enabled = false;
                    reenableNext = true;
                }
                if (btnExpPrevious.Visible) {
                    btnExpPrevious.Enabled = false;
                    reenablePrevious = true;
                }
                string fileName = String.Format(Resources.MessagesResource.ExpenseFileNameReport, DateTime.Now.ToString("yyyyMMdd-HHmmss"));
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "*.xls | *.xlsx";
                saveDialog.Title = Resources.MessagesResource.ExpenseExportFileDialogTitle;
                saveDialog.FileName = fileName;
                var saveResult = saveDialog.ShowDialog();
                if (saveResult == DialogResult.OK) {
                    UseWaitCursor = true;
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                    using (var file = new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write)) {
                        using (var data = await _reportService.GenerateReport(_filter)) {
                            await data.CopyToAsync(file);
                        }
                    }
                    MessageBox.Show(Resources.MessagesResource.ExpenseMessageReportExportSuccess, Resources.MessagesResource.ExpenseMessageBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error when exporting the expenses report");
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                UseWaitCursor = false;
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                if (reenableNext) {
                    btnExpNext.Enabled = true;
                }
                if (reenablePrevious) {
                    btnExpPrevious.Enabled = true;
                }
                btnSearch.Enabled = true;
                btnExport.Enabled = true;
            }
        }

    }
}
