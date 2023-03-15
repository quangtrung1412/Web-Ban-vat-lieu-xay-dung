using App.Producting.Api.Core.Data.Entities;
using App.Shared.Entities;

namespace App.Producting.Producting.Api.Core.Data;

public class ProductMemoryContext
{
    public Dictionary<string,Product> Products = new Dictionary<string, Product>();
    public Dictionary<int,Category> Categories = new Dictionary<int, Category>();
    public Dictionary<int,TradeMark> TradeMarks = new Dictionary<int, TradeMark>();  
    public static string GetProductKey(string productCode)=> $"{productCode}";
}