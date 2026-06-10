using ExpenseServices.Requests;
using ExpenseServices.Services;
using ExpenseTracker.DisplayItems;
using ScottPlot;
using ScottPlot.Plottables;
using System.ComponentModel;
using System.Data;

namespace ExpenseTracker.Forms {
    public partial class ExpenseReportForm : Form {

        private readonly ExpenseService _expServ;
        private readonly ExpensePlaceService _placeServ;
        private readonly ExpenseTypeService _typeServ;
        private readonly ReportService _reportService;

        private int _page = 1;
        private int _total = 1;
        private int _totalPages = 1;
        private ExpenseSearchRequest _filter;

        public ExpenseReportForm(ExpenseService expServ, ExpensePlaceService placeServ, ExpenseTypeService typeServ, ReportService reportService) {
            _expServ = expServ;
            _placeServ = placeServ;
            _typeServ = typeServ;
            _reportService = reportService;
            InitializeComponent();
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
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _filter = request;
            try {
                placeGroupPlot.Plot.Clear();
                typeGroupPlot.Plot.Clear();
                expenseTop10Plot.Plot.Clear();
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
                var expChart = (await _expServ.GetTop5Expenses(request)).Reverse();
                _totalPages = decimal.ToInt32(Math.Ceiling((decimal)_total / 25));
                dgvExpenses.DataSource = new BindingList<ExpenseDetailViewModel>(exp.Select(e => new ExpenseDetailViewModel {
                    Id = e.Id,
                    Date = e.Date,
                    Place = e.Place,
                    Type = e.Type,
                    Name = e.Name,
                    Cost = $"${e.Price}"
                }).ToList());
                dgvTypes.DataSource = new BindingList<ExpenseReportViewModels>(types.Select(et => new ExpenseReportViewModels { Count = et.Count, Name = et.Name, Total = et.Total }).ToList());
                dgvPlaces.DataSource = new BindingList<ExpenseReportViewModels>(places.Select(et => new ExpenseReportViewModels { Count = et.Count, Name = et.Name, Total = et.Total }).ToList());
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
                        FillColor = ScottPlot.Colors.Gray,
                        LegendText = "Others",
                    });
                }
                i = 1;
                var expData = new List<Bar>();
                foreach (var expD in expChart) {
                    expData.Add(new Bar {
                        Value = expD.Total,
                        FillColor = ScottPlot.Colors.Blue,
                        Label = expD.Date,
                        Position = i
                    });
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
                var barPlot = expenseTop10Plot.Plot.Add.Bars(expData.ToArray());
                barPlot.Horizontal = true;
                expenseTop10Plot.Plot.Axes.SetLimitsX(0, expChart.Max(ec => ec.Total) + 350);
                expenseTop10Plot.Plot.Axes.SetLimitsY(0, i - 1);
                expenseTop10Plot.Refresh();
                expenseTop10Plot.Enabled = false;
                UpdateExpViews();
                dgvTypes.AutoResizeColumns();
                dgvPlaces.AutoResizeColumns();
                dgvExpenses.Refresh();
                dgvPlaces.Refresh();
                dgvTypes.Refresh();
                btnExpNext.Visible = _total > 25;
                btnExpNext.Enabled = _total > 25;
                reportTab.Visible = true;
                reportTab.Refresh();
                btnExport.Visible = true;
                btnExport.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _page++;
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnSearch.Visible = false;
                btnSearch.Enabled = false;
                if (btnExpNext.Visible) {
                    btnExpNext.Enabled = false;
                    reenableNext = true;
                }
                if (btnExpPrevious.Visible) {
                    btnExpPrevious.Enabled = false;
                    reenablePrevious = true;
                }
                string fileName = "ReporteGastos_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "*.xls | *.xlsx";
                saveDialog.Title = "Elija el lugar de exportacion";
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
                    MessageBox.Show("Gastos exportados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) {
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally {
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
                btnSearch.Visible = true;
                btnSearch.Enabled = true;
            }
        }
    }
}
