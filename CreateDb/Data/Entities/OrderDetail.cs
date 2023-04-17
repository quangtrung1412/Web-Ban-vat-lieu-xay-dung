namespace CreateDb.Data.Entities;
public class OrderDetail
{
    public string OrderDetailCode { get; set; }
    public string OrderCode {get;set;}
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public long RetailPrice { get; set; }
    public Unit Unit { get; set; }
    public long NumberProduct { get; set; }
    public long TotalPrice { get; set; }
    public long Sale { get; set; }
}