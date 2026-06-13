using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DisplayItems {
    public class ExpenseReportViewModels {

        [Display(Name = "ExpenseLabelName", ResourceType = typeof(Resources.MessagesResource))]
        public required string Name { get; set; }

        [Display(Name = "ExpenseLabelTotal", ResourceType = typeof(Resources.MessagesResource))]
        public required string Total { get; set; }

        [Display(Name = "ExpenseLabelCount", ResourceType = typeof(Resources.MessagesResource))]
        public required string Count { get; set; }
    }
}
