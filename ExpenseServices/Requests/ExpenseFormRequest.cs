
namespace ExpenseServices.Requests {
    public class ExpenseFormRequest:IRequest {

        public required DateTime Date { get; set; }
        public required string Name { get; set; }
        public required double Cost { get; set; }
        public required string Type { get; set; }
        public required string Place {  get; set; }

        public string Valid() {
            if (Date > DateTime.Today) {
                return "No puede cargarse un gasto a futuro";
            }
            if (string.IsNullOrWhiteSpace(Name)) {
                return "Ingrese el nombre del gasto";
            }
            if (Cost<=0) {
                return "No puede existir un gasto menor a 0";
            }
            if (string.IsNullOrWhiteSpace(Type)) {
                return "Ingrese el tipo de gasto";
            }
            if (string.IsNullOrWhiteSpace(Place)) {
                return "Ingrese el lugar de gasto";
            }
            return string.Empty;
        }
        
    }
}
