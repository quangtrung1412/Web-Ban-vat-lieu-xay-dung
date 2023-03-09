namespace App.Shared.Entities;
public class Product
{
    //mã sản phẩm
    public string ProductCode { get; set; }
    //Tên Sản phẩm
    public string ProductName { get; set; }
    //Ảnh
    public string Image {get;set;}
    //giá gốc
    public decimal Cost {get;set;}
    //giá bán lẻ
    public long RetailPrice {get;set;}
    //Tồn Kho 
    public long Inventory {get;set;}
    //Đơn vị 
    public Unit Unit {get;set;}
    //trạng thái 
    public bool Status {get;set;}
    //mã Danh sách sản phẩm 
    public int CategoryId{get;set;}
    //Mã Thương hiệu
    public int TradeMarkId {get;set;}
}