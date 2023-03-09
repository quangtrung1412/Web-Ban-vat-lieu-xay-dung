namespace App.Ordering.OrderingApi;

public class Order
{
 public string OrderCode {get;set;}
 public DateTime OrderDate {get;set;}
 public DateTime DeliveryDate {get;set;}
 public long TotalMoney {get;set;}
 public string Email {get;set;}
 public string Phone {get;set;}
 public string Address {get;set;}
 public string Seller {get;set;}
 public long Payed {get;set;}
 public long Sale {get;set;}
 public string Status {get;set;}
}