using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_invoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["invoice"] != null)
                {
                    Invoice invoice = (Invoice)Session["invoice"];
                    lblOrderID.Text = "Order ID: " + invoice.OrderID;
                    lblDate.Text = "Date/time Placed: " + invoice.Order.DatePlaced.ToString();
                    double finalPrice = 0;
                    lblItems.Text += "<hr>";
                    foreach (Orderline line in invoice.Order.OrderLines)
                    {
                        lblItems.Text
                            += "Name: " + line.Product.ProductName
                            + "<br> Type: " + line.Product.TypeName
                            + "<br> Quantity: " + line.Quantity
                        + "<br> Combined Price: $" + (finalPrice = (line.Quantity * line.Product.Price)).ToString("##.00")
                        + "<hr>";
                    }//foreach
                    lblItems.Text += "<br>Final Cost(with delivery charge) : $" + invoice.Order.DeliveryCost.ToString("##.00");
                    lblDel.Text = "<br>Delivery Cost : $" + invoice.Order.Del.ToString("##.00");
                    Session.Remove("ShoppingCart");
                }//if

            }//if
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//Page_Load

    protected void btnCompleted_Click(object sender, EventArgs e)
    {
        //remove invoice Session Varible
        Session.Remove("invoice");
        Session.Remove("cardInfo");

        //return to index
        Response.Redirect("~/index.aspx");

    }//btnCompleted_Click

}//namespace