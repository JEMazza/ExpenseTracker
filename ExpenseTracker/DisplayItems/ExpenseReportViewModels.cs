using System.ComponentModel;

namespace ExpenseTracker.DisplayItems {
    public class ExpenseReportViewModels {

        [DisplayName("Nombre")]
        public required string Name { get; set; }

        [DisplayName("Total")]
        public required double Total { get; set; }
        [DisplayName("Cantidad")]
        public required int Count { get; set; }
    }
}
