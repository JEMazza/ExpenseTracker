namespace ExpenseServices.DTOs {
    public record ExpensePlaceDto(int Id, string Name) {
        public override string ToString() => Name;
    }

    public record ExpensePlaceGroupDto(string Name, int Count, double Total);
}
