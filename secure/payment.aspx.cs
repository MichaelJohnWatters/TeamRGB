using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Confirms user has enter card info
    /// places the order and runs inserts to the database.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnConfirmPayment_Click(object sender, EventArgs e)
    {

        //Create Card Info Session Varible
        Session["cardInfo"] = new CardInfo(txtCardNumber.Text, txtCardSecurityNum.Text);

        Invoice invoice = (Invoice)Session["invoice"];
        Order order = invoice.Order;
        ArrayList currentCart = (ArrayList)Session["ShoppingBasket"];

        //Update database with new Order.
        try
        {
            string orderID = order.insertNewOrder(order.CustomerID, order.DeliveryCost,order.Del);

            //add orderID to invoice.
            invoice.OrderID = orderID;
            Session["invoice"] = invoice;

            //Add Each orderline of the order to the database.
            foreach (Orderline orderline in order.OrderLines)
            {
                //add orderline to database
                orderline.insertNewOrderline(Convert.ToInt32(orderID), orderline.Product.ProductID, orderline.Quantity);

                //Update Stock
                Product.updateStock(currentCart);
            }//foreach
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
            Response.Redirect("~/error.aspx");
        }

        //remove ShoppingBasket
        Session.Remove("ShoppingBasket");

        //Open the invoice details page and pass across query string
        Response.Redirect("~/secure/invoice.aspx");

    }//btnConfirmPayment_Click

}//namespace