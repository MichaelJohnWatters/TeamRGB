using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// Create 7/11/2018
/// Invoice Object holds an order object, used in the invoice screen.
/// </summary>
public class Invoice
{
    public Order Order { get; set; }
    public string OrderID { get; set; }

    /// <summary>
    /// this invoice holds an order.
    /// </summary>
    /// <param name="order"></param>
    public Invoice(Order order)
    {
        Order = order;
    }//Invoice
}//class