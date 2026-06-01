
namespace ExpenseServices.Entities {
    public class ExpensePlace {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; } 
    }
}
