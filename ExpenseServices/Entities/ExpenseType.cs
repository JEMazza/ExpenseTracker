
namespace ExpenseServices.Entities {
    public class ExpenseType {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
