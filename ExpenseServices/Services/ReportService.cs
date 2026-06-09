using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using ExpenseServices.Data;
using ExpenseServices.DTOs;
using ExpenseServices.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseServices.Services {
    public class ReportService : BaseService {
        public ReportService(ExpensesUnitOfWork unit) : base(unit) {
        }

        public async Task<MemoryStream> GenerateReport(ExpenseSearchRequest filter) {
            MemoryStream report = new MemoryStream();
            IEnumerable<ExpenseDto> expenses;
            IEnumerable<ExpensePlaceGroupDto> expensePlaces = await _unit.ExpensePlace.GetPlacesGroup(filter.From,filter.To);
            IEnumerable<ExpenseTypeGroupDto> expenseTypes = await _unit.ExpenseTypes.GetTypesGroup(filter.From,filter.To);
            var summary = await _unit.Expenses.GetSummary(filter.From, filter.To, filter.Types, filter.Places);
            using (var book = new XLWorkbook()) {
                var expSheet = book.AddWorksheet("Expenses");
                expSheet.Cell(1, 1).Value = "Fecha";
                expSheet.Cell(1, 2).Value = "Nombre";
                expSheet.Cell(1, 3).Value = "Costo";
                expSheet.Cell(1, 4).Value = "Lugar";
                expSheet.Cell(1, 5).Value = "Tipo";
                int row = 2;
                int pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(summary.Expenses) / 10000));
                for (int page = 1; page <= pages; page++) {
                    expenses = await _unit.Expenses.GetExpenses(filter.From, filter.To, filter.Types, filter.Places, page, 10000);
                    foreach(ExpenseDto exp in expenses) {
                        expSheet.Cell(row, 1).Value = exp.Date;
                        expSheet.Cell(row, 2).Value = exp.Name;
                        expSheet.Cell(row, 3).Value = $"${exp.Price:N2}";
                        expSheet.Cell(row, 4).Value = exp.Place;
                        expSheet.Cell(row, 5).Value = exp.Type;
                        expSheet.Range(row, 1, row, 5).Style.Fill.BackgroundColor = (row % 2 == 0) ? XLColor.LightBlue : XLColor.White;
                        row++;
                    }
                }
                expSheet.Range(1, 1, 1, 5).Style.Font.Bold = true;
                expSheet.Range(1, 1, 1, 5).Style.Fill.BackgroundColor = XLColor.White;
                expSheet.Columns(1, 1).Width = 16;
                expSheet.Columns(2, 2).Width = 30;
                expSheet.Columns(3, 3).Width = 22;
                expSheet.Columns(4, 4).Width = 35;
                expSheet.Columns(5, 5).Width = 36;
                var placeSheet = book.AddWorksheet("Places");
                placeSheet.Cell(1, 1).Value = "Name";
                placeSheet.Cell(1, 2).Value = "Total";
                placeSheet.Cell(1, 3).Value = "Count";
                row = 2;
                foreach(ExpensePlaceGroupDto place in expensePlaces) {
                    placeSheet.Cell(row, 1).Value = place.Name;
                    placeSheet.Cell(row, 2).Value = $"{place.Total}";
                    placeSheet.Cell(row, 3).Value = place.Count;
                    placeSheet.Range(row, 1, row, 3).Style.Fill.BackgroundColor = (row % 2 == 0) ? XLColor.LightBlue : XLColor.White;
                    row++;
                }
                placeSheet.Columns(1, 1).Width = 30;
                placeSheet.Columns(2, 2).Width = 15;
                placeSheet.Columns(3, 3).Width = 10;
                var typeSheet = book.AddWorksheet("Types");
                typeSheet.Cell(1, 1).Value = "Name";
                typeSheet.Cell(1, 2).Value = "Total";
                typeSheet.Cell(1, 3).Value = "Count";
                row = 2;
                foreach (ExpenseTypeGroupDto place in expenseTypes) {
                    typeSheet.Cell(row, 1).Value = place.Name;
                    typeSheet.Cell(row, 2).Value = $"{place.Total}";
                    typeSheet.Cell(row, 3).Value = place.Count;
                    typeSheet.Range(row, 1, row, 3).Style.Fill.BackgroundColor = (row % 2 == 0) ? XLColor.LightBlue : XLColor.White;
                    row++;
                }
                typeSheet.Columns(1, 1).Width = 30;
                typeSheet.Columns(2, 2).Width = 15;
                typeSheet.Columns(3, 3).Width = 10;
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
                book.SaveAs(report);
            }
            report.Position = 0;
            return report;
        }
    }
}
