namespace ExpenseServices.DTOs {
    public record ExpenseTypeDto(int Id, string Name) {
        public override string ToString() => Name;
    };
}
