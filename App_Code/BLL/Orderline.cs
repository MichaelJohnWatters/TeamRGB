using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters, Lukas Audi
/// create 5/11/2018
/// Class represents a single line within a order.
/// 
/// this class represents a Orderline that is contained within an order.
/// </summary>
public class Orderline
{
    public int OrderLineID { get; set; }
    public int OrderID { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }

    //Partial Constructor
    public Orderline( Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }//Orderline

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// Controller Method.
    /// This Method inserts a new Orderline of an order in the database.
    /// </summary>
    /// <param name="orderID"></param>
    /// <param name="productID"></param>
    /// <param name="quantity"></param>
    public void insertNewOrderline(int orderID, int productID, int quantity)
    {
        DataAccess.insertOrderline(orderID, productID, quantity);
    }//insertNewOrderline

    /// <summary>
    /// Author Lukas Audi
    /// 5/1/2019
    /// This method returns all the orders lines for specif customers order ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DataSet getOrderLinesForCustomer(int id)
    {
        return DataAccess.getOrderLines(id);
    }//getSingleOrder
}//class