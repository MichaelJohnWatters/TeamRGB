using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// Create 7/11/2018
/// 
/// This is a CartItem it represents a virtual item.
/// 
/// </summary>
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    //Empty Constructor
    public CartItem()
    {

    }
    //full Constructor
    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }//CartItem
}//class