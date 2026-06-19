namespace ExpenseServices.DTOs {
    public record ExpenseDto (int Id,string Name, string Date, double Price, string Type,string Place);
    
    public record ExpenseSummaryDto(double Total, int Expenses, string highestPlace, string highestType);
    public record ExpenseFormDto(int Id, string Name, DateTime Date, double Price, int Type, int Place);
    public record ExpenseChartDto(string Date, double Total);

}
