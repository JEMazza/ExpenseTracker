using System.ComponentModel;

namespace ExpenseTracker.DisplayItems {
    internal class ExpenseDetailViewModel {

        [Browsable(false)]
        public required int Id { get;set; }
        [DisplayName("Fecha")]
        public required string Date { get; set; }
        [DisplayName("Nombre")]
        public required string Name { get;set; }
        [DisplayName("Costo")]
        public required string Cost { get; set; }
        [DisplayName("Lugar")]
        public required string Place {  get;set; }
        [DisplayName("Tipo")]
        public required string Type { get;set; }
    }
}
