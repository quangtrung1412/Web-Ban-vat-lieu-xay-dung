using System.Security.Cryptography.X509Certificates;

namespace App.Ordering.OrderingApi;
public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public string ProductCode {get;set;}
    public string OderCode {get;set;}
    public long NumberProduct {get;set;}
    public long  TotalPrice {get;set;}
    public long Sale {get;set;}
}