using System.ComponentModel;

public enum ExpenseOrderEnum {
    [Description("Fecha (Asc)")]
    OrderByDate,
    [Description("Fecha (Desc)")]
    OrderByDateDesc,
    [Description("Costo (Asc)")]
    OrderByCost,
    [Description("Costo (Desc)")]
    OrderByCostDesc,
    [Description("Nombre (Asc)")]
    OrderByName,
    [Description("Nombre (Desc)")]
    OrderByNameDesc,
}