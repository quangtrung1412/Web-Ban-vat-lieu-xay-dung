using App.Producting.Api.Core.Data.Entities;
using App.Shared.Entities;

namespace App.Producting.Producting.Api.Core.Data;

public class ProductMemoryContext
{
    public Dictionary<string,Product> Products = new Dictionary<string, Product>();
    public Dictionary<string,Category> Categories = new Dictionary<string, Category>();
    public Dictionary<string,TradeMark> TradeMarks = new Dictionary<string, TradeMark>();  
    public static string GetProductKey(string productCode)=> $"{productCode}";
}