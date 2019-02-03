using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// 5/1/2019
/// 
/// This Class Represents an Order within the Site.
/// A single order can contain mutiple orderlines.
/// 
/// </summary>
public class Order
{
    //we shouldn't be able to modify IDs from within the program so only getters are needed for IDs
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime DatePlaced { get; set; }
    public double DeliveryCost { get; set; }
    public double Del { get; set;}
    public Orderline[] OrderLines { get; set; }

    //Empty Constructor
    public Order()
    {

    }
    //Partial Constructor
    public Order(int customerID, double deliveryCost, Orderline[] orderlines)
    {
        this.CustomerID = customerID;
        this.DeliveryCost = deliveryCost;
        this.OrderLines = orderlines;
    }//constructor

    /// <summary>
    /// Controller Method.
    /// This Method inserts a new Order in the database.
    /// </summary>
    /// <param name="customerID"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    public string insertNewOrder(int customerID, double price, double del)
    {
       return DataAccess.insertOrder(customerID, price, del);
    }//insertNewOrder

    /// <summary>
    /// Author Michael Watters
    /// created 5/1/2019
    /// 
    /// Controller Method
    /// This Method Displays all the orders that exist in the database.
    /// </summary>
    /// <returns></returns>
    public static DataSet displayAllOrders()
    {
        return DataAccess.displayAllOrders();
    }//displayAllOrders

    /// <summary>
    /// Author Michael Watters
    /// created 5/1/2019
    /// This Method gets all the orders by a specfic ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DataSet getAllOrdersCustomer(int id)
    {
        return DataAccess.getOrdersForCustomer(id);
    }//getAllOrdersCustomer

    /// <summary>
    /// Author Michael Watters
    /// created 5/1/2019
    /// 
    /// This method gets the delivery cost from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static double getDel(int id) {
        return DataAccess.getOrderDel(id);
    }//getDel
}//class