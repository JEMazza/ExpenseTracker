
using ClosedXML.Excel;
using ExpenseServices.Data;
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
using ExpenseServices.Requests;

namespace ExpenseServices.Services {
    public class ExpenseService:BaseService {


        public ExpenseService(ExpensesUnitOfWork unit):base(unit) {
        }

        /// <summary>
        /// Get Expenses
        /// </summary>
        /// <param name="request">Object to summarize expense search</param>
        /// <returns>A collection of expenses</returns>
        public async Task<IEnumerable<ExpenseDto>> GetExpenses(ExpenseSearchRequest request,int page,int size,ExpenseOrderEnum order = ExpenseOrderEnum.OrderByDate) {
            return await _unit.Expenses.GetExpenses(request.From, request.To, request.Types,request.Places, page,size,order);
        }


        /// <summary>
        /// Get Summary of expenses (Total, Highest place expended, etc)
        /// </summary>
        /// <param name="request">Request form for filtering the summary</param>
        /// <returns>An object with the summary of expenses</returns>
        public async Task<ExpenseSummaryDto> GetExpensesSummary(ExpenseSearchRequest request) {
            return await _unit.Expenses.GetSummary(request.From, request.To, request.Types, request.Places);
        }

        /// <summary>
        /// Get Base data for updating a Form
        /// </summary>
        /// <param name="id">Expense Id</param>
        /// <returns></returns>
        public async Task<ExpenseFormDto?> PrepareExpenseForm(int id) {
            return await _unit.Expenses.GetExpense(id);
        }

        /// <summary>
        /// Adding an expense
        /// </summary>
        /// <param name="request">Request object to create an expense</param>
        /// <returns>If the operation was successful</returns>
        public async Task<bool> AddExpense(ExpenseFormRequest request) {
            using(var tran = await _unit.StartTransaction()) {
                try {
                    int placeId = await _unit.ExpensePlace.Exists(request.Place);
                    int typeId = await _unit.ExpenseTypes.Exists(request.Type);
                    Expense exp = new();
                    exp.Name = request.Name;
                    exp.Cost = request.Cost;
                    exp.Date = request.Date;
                    if (placeId > 0) { 
                        exp.PlaceId = placeId;
                    }
                    else {
                        exp.Place = new ExpensePlace { Name =  request.Place };
                    }
                    if (typeId > 0) { 
                        exp.TypeId=typeId;
                    }
                    else {
                        exp.Type = new ExpenseType { Name = request.Type };
                    }
                    await _unit.Expenses.Add(exp);
                    await _unit.Save();
                    await _unit.Commit(tran);
                    return true;
                }catch (Exception) {
                    await _unit.Rollback(tran);
                    throw;
                }
            }
        }

        /// <summary>
        /// Updating an expense
        /// </summary>
        /// <param name="id">Expense Id</param>
        /// <param name="request">Same object as Add Expense</param>
        /// <returns></returns>
        public async Task<bool> UpdateExpense(int id,ExpenseFormRequest request) {
            using (var tran = await _unit.StartTransaction()) {
                try {
                    Expense? exp = await _unit.Expenses.GetEntity(id);
                    if(exp == null) {
                        return false;
                    }
                    int placeId = await _unit.ExpensePlace.Exists(request.Place);
                    int typeId = await _unit.ExpenseTypes.Exists(request.Type);
                    exp.Name = request.Name;
                    exp.Cost = request.Cost;
                    exp.Date = request.Date;
                    if (placeId > 0) {
                        exp.PlaceId = placeId;
                    }
                    else {
                        exp.Place = new ExpensePlace { Name = request.Place };
                    }
                    if (typeId > 0) {
                        exp.TypeId = typeId;
                    }
                    else {
                        exp.Type = new ExpenseType { Name = request.Type };
                    }
                    await _unit.Save();
                    await _unit.Commit(tran);
                    return true;
                }
                catch (Exception) {
                    await _unit.Rollback(tran);
                    throw;
                }
            }
        }

        /// <summary>
        /// Remove an expense
        /// </summary>
        /// <param name="id">Expense Id to remove</param>
        /// <returns></returns>
        public async Task<bool> RemoveExpense(int id) {
            using (var tran = await _unit.StartTransaction()) {
                try {
                    Expense? exp = await _unit.Expenses.GetEntity(id);
                    if(exp == null) {
                        return false;
                    }
                    _unit.Expenses.Delete(exp);
                    await _unit.Save();
                    await _unit.Commit(tran);
                    return true;
                }catch (Exception) {
                    await _unit.Rollback(tran);
                    throw;
                }
            }
        }

        /// <summary>
        /// Export expenses based on the filter to a spreadsheet
        /// </summary>
        /// <param name="request">The expense filter </param>
        /// <returns></returns>
        public async Task<MemoryStream> ExportExpenses(ExpenseSearchRequest request) {
            try {
                var stream = new MemoryStream();
                IEnumerable<ExpenseDto> expList;
                using (var book = new XLWorkbook()) {
                    var summary = await _unit.Expenses.GetSummary(request.From,request.To,request.Types,request.Places);
                    var expenseSheet = book.AddWorksheet("Gasto");
                    expenseSheet.Cell(1, 1).Value = "Fecha";
                    expenseSheet.Cell(1, 2).Value = "Nombre";
                    expenseSheet.Cell(1, 3).Value = "Costo";
                    expenseSheet.Cell(1, 4).Value = "Lugar";
                    expenseSheet.Cell(1, 5).Value = "Tipo";
                    int row = 2;
                    int pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(summary.Expenses) / 10000));
                    for (int page = 1; page <=pages; page++) {
                        expList = await _unit.Expenses.GetExpenses(request.From, request.To, request.Types, request.Places, page, 10000);
                        foreach (ExpenseDto exp in expList) {
                            expenseSheet.Cell(row, 1).Value = exp.Date;
                            expenseSheet.Cell(row, 2).Value = exp.Name;
                            expenseSheet.Cell(row, 3).Value = $"${exp.Price:N2}";
                            expenseSheet.Cell(row, 4).Value = exp.Place;
                            expenseSheet.Cell(row, 5).Value = exp.Type;
                            expenseSheet.Range(row,1,row,5).Style.Fill.BackgroundColor = (row%2 == 0)? XLColor.LightBlue:XLColor.White;
                            row++;
                        }
                    }
                    expenseSheet.Range(1,1,1,5).Style.Font.Bold=true;
                    expenseSheet.Range(1, 1, 1, 5).Style.Fill.BackgroundColor = XLColor.White;
                    expenseSheet.Columns(1, 1).Width = 16;
                    expenseSheet.Columns(2, 2).Width = 30;
                    expenseSheet.Columns(3, 3).Width = 22;
                    expenseSheet.Columns(4, 4).Width = 35;
                    expenseSheet.Columns(5, 5).Width = 36;
                    var summarySheet = book.AddWorksheet("Summary");
                    summarySheet.Cell(1, 1).Value = "Summary";
                    summarySheet.Cell(1, 1).Style.Font.Bold = true;
                    summarySheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    summarySheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.White;
                    summarySheet.Range(1, 1, 1, 2).Merge();
                    summarySheet.Cell(2, 1).Value = "Total";
                    summarySheet.Cell(2, 2).Value = $"${summary.Total.ToString()}";
                    summarySheet.Range(2, 1, 2, 2).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    summarySheet.Cell(3, 1).Value = "Lugar con mayor gasto";
                    summarySheet.Cell(3, 2).Value = summary.highestPlace;
                    summarySheet.Range(3, 1, 3, 2).Style.Fill.BackgroundColor = XLColor.White;
                    summarySheet.Cell(4, 1).Value = "Tipo con mayor gasto";
                    summarySheet.Cell(4, 2).Value = summary.highestType;
                    summarySheet.Range(4, 1, 4, 2).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    summarySheet.Columns(1, 2).AdjustToContents();
                    book.SaveAs(stream);
                }
                stream.Position= 0;
                return stream;
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Gets the count for the expenses based on the filter
        /// </summary>
        /// <param name="request">The expense filter</param>
        /// <returns>The ammount of expenses</returns>
        public async Task<int> GetExpensesCount(ExpenseSearchRequest request) {
            return await _unit.Expenses.GetExpenseCount(request.From, request.To,request.Types,request.Places);
        }

        /// <summary>
        /// Returns the top 5 dates of total expense
        /// </summary>
        /// <param name="request">The expense filter</param>
        /// <returns>A collection of name and total expense dates, up to 10 results</returns>
        public async Task<IEnumerable<ExpenseChartDto>> GetTop5Expenses(ExpenseSearchRequest request) {
            return await _unit.Expenses.GetTop5Dates(request.From,request.To,request.Types,request.Places);
        }
    }
}
