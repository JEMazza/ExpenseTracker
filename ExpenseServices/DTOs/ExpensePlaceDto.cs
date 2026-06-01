namespace ExpenseServices.DTOs {
    public record ExpensePlaceDto(int Id, string Name) {
        public override string ToString() => Name;
    }
}
