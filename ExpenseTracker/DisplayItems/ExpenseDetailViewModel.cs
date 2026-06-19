using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DisplayItems {
    internal class ExpenseDetailViewModel {

        [Browsable(false)]
        public required int Id { get;set; }
        
        [Display(Name = "ExpenseLabelDate", ResourceType = typeof(Resources.MessagesResource))]
        public required string Date { get; set; }
        [Display(Name = "ExpenseLabelName", ResourceType = typeof(Resources.MessagesResource))]
        public required string Name { get;set; }
        [Display(Name = "ExpenseLabelCost", ResourceType = typeof(Resources.MessagesResource))]
        public required string Cost { get; set; }
        [Display(Name = "ExpenseLabelPlace", ResourceType = typeof(Resources.MessagesResource))]
        public required string Place {  get;set; }
        [Display(Name = "ExpenseLabelType", ResourceType = typeof(Resources.MessagesResource))]
        public required string Type { get;set; }
    }
}
