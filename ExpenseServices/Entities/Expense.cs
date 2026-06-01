namespace ExpenseServices.Entities {
    public class Expense {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int TypeId {  get; set; }
        public int PlaceId { get; set; }
        public virtual ExpenseType Type { get; set; }
        public virtual ExpensePlace Place { get; set; }
    }
}
