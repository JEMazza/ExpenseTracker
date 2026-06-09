using ExpenseServices.DTOs;
using ExpenseServices.Requests;
using ExpenseServices.Services;

namespace ExpenseTracker.Forms {
    public partial class ExpenseDataForm : Form {

        private readonly ExpenseService _service;
        private readonly ExpenseTypeService _typeService;
        private readonly ExpensePlaceService _placeService;
        public bool refresh = false;
        private int _id = -1;

        public ExpenseDataForm(ExpenseService service,ExpenseTypeService typeService, ExpensePlaceService placeService) {
            _service = service;
            _typeService = typeService;
            _placeService = placeService;
            InitializeComponent();
        }

        public void LoadId(int id) {
            _id = id;
        }

        private async Task PrepareForm() {
            dtpDate.Value = DateTime.Today;
            tBoxName.Text = string.Empty;
            numCost.Value = 0.0m;
            await LoadCombos();
        }

        private async Task LoadCombos() {
            var types = await _typeService.GetTypes();
            var places = await _placeService.GetPlaces();
            cmbPlace.Items.Clear();
            cmbType.Items.Clear();
            cmbPlace.Items.AddRange(places.ToArray());
            cmbType.Items.AddRange(types.ToArray());
        }


        private async void ExpenseDataForm_Load(object sender, EventArgs e) {
            this.Text = _id!=-1?Resources.MessagesResource.ExpenseUpdateFormTitle: Resources.MessagesResource.ExpenseNewFormTitle;
            cmbPlace.ValueMember = "Id";
            cmbPlace.DisplayMember = "Name";
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "Name";
            await PrepareForm();
            if (_id != -1) {
                ExpenseFormDto? formData = await _service.PrepareExpenseForm(_id);
                if (formData == null) {
                    MessageBox.Show("El gasto no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                btnAction.Text = Resources.MessagesResource.ExpenseModifyActionLabel;
                tBoxName.Text = formData.Name;
                numCost.Value = Convert.ToDecimal(formData.Price);
                dtpDate.Value = formData.Date;
                cmbPlace.SelectedItem = cmbPlace.Items.Cast<ExpensePlaceDto>().FirstOrDefault(et => et.Id == formData.Place);
                cmbType.SelectedItem = cmbType.Items.Cast<ExpenseTypeDto>().FirstOrDefault(et => et.Id == formData.Type);
            }
            else {
                btnAction.Text = Resources.MessagesResource.ExpenseDeleteActionLabel;
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private async void btnAction_Click(object sender, EventArgs e) {
            btnAction.Enabled = false;
            btnBack.Enabled = false;
            Cursor.Current= Cursors.WaitCursor;
            try {
                ExpenseFormRequest request = new() {
                    Name = tBoxName.Text,
                    Cost = decimal.ToDouble(numCost.Value),
                    Date = dtpDate.Value.Date,
                    Place = cmbPlace.Text.Trim(),
                    Type = cmbType.Text.Trim(),
                };
                string msg = request.Valid();
                if (!string.IsNullOrEmpty(msg)) {
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(_id != -1) {
                    await _service.UpdateExpense(_id, request);
                    msg = "Gasto actualizado correctamente";
                    MessageBox.Show("Gasto actualizado correctamente", "Exito", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    refresh = true;
                    this.Close();
                }
                else {
                    await _service.AddExpense(request);
                    refresh = true;
                    var more = MessageBox.Show("Gasto agregado correctamente. \n ¿Desea añadir otro?", "Exito", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (more == DialogResult.Yes) {
                        await PrepareForm();
                    }
                    else if (more == DialogResult.No) {
                        this.Close();
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show("An error occured: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                btnAction.Enabled = true;
                btnBack.Enabled = true;

            }
        }
    }
}
