
namespace ExpenseServices.Requests {
    public class ExpenseFormRequest:IRequest {

        public required DateTime Date { get; set; }
        public required string Name { get; set; }
        public required double Cost { get; set; }
        public required string Type { get; set; }
        public required string Place {  get; set; }

        public string Valid() {
            if (Date > DateTime.Today) {
                return Resources.ErrorMessages.ExpenseFormDateError;
            }
            if (string.IsNullOrWhiteSpace(Name)) {
                return Resources.ErrorMessages.ExpenseFormNameError;
            }
            if (Cost<=0) {
                return Resources.ErrorMessages.ExpenseFormCostError;
            }
            if (string.IsNullOrWhiteSpace(Type)) {
                return Resources.ErrorMessages.ExpenseFormTypeError;
            }
            if (string.IsNullOrWhiteSpace(Place)) {
                return Resources.ErrorMessages.ExpenseFormPlaceError;
            }
            return string.Empty;
        }
        
    }
}
