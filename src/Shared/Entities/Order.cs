namespace App.Shared.Entities;

public class Order
{
 public string OrderCode {get;set;}
 public DateTime OrderDate {get;set;}
 public DateTime DeliveryDate {get;set;}
 public long TotalPrice {get;set;}
 public string Email {get;set;}
 public string Phone {get;set;}
 public string Address {get;set;}
 public string Seller {get;set;}
 public long Paid {get;set;}
 public long Sale {get;set;}
 public OrderingStatus Status {get;set;}
}