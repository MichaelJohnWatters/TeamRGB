using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_checkOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ShoppingBasket"] == null)
        {
            //JAVASCRIPT MESSAGE CANNT CHECKOUT WITH NO ITEMS IN CART.
            Response.Redirect("~/shop.aspx");
        }//if
        try
        {
            // if is postback
            if (!IsPostBack)
            {
                ddlDelivery.Items.Add("Standard (no charge)");
                ddlDelivery.Items.Add("Next day ($10.00)");
                ddlDelivery.Items.Add("Two days ($5.00)");
            }

            //create objects from session varibles
            Customer customer = (Customer)Session["customer"];
            ArrayList cartItems = (ArrayList)Session["ShoppingBasket"];

            lblDetails.Text = "Name:    " + customer.FirstName + " " + customer.SecondName + "<br/>"
                + "Address:    " + customer.Address + "<br/>"
                + "Country:    " + customer.Country + "<br/>"
                + "PostCode:    " + customer.PostCode;

            //calculate and build output
            string output = "";
            double total = 0;
            foreach (CartItem item in cartItems)
            {
                double lineCost = item.Quantity * item.Product.Price;
                total += lineCost;
                output += item.Product.ProductName + " Quantity: " + item.Quantity + " Price $: " + lineCost.ToString("##.00") + "<br/>";
            }

            //output to labels
            lblItems.Text = output;
            lblBasketCost.Text = total.ToString("##.00");
            lblHiddenCost.Text = total.ToString("##.00");
            lblTotal.Text = total.ToString("##.00");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }//catch
    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Remove session varibles if users desides to cancel an order.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //JAVASCRIPT MESSAGE ARE YOU SURE YOU WANT TO DO THIS.
        Session.Remove("ShoppingBasket");
        Response.Redirect("~/index.aspx");
    }//btnCancel_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// creates an invoice and an order used to shown on the invoice page.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInvoice_Click(object sender, EventArgs e)
    {

        Customer customer = (Customer)Session["customer"];
        ArrayList currentCart = (ArrayList)Session["ShoppingBasket"];
        Orderline[] orderlines = new Orderline[currentCart.Count];

        //Add an orderlines to orderlines array
        for (int i = 0; i < orderlines.Length; i++)
        {
            CartItem tempCartItem = (CartItem)currentCart[i];
            Orderline line = new Orderline(tempCartItem.Product, tempCartItem.Quantity);
            orderlines[i] = line;
        }//for

        double price = Convert.ToDouble(lblHiddenCost.Text) + Convert.ToDouble(lblDelCost.Text);

        Order order = new Order(customer.CustomerID, price, orderlines);
        order.Del = Convert.ToInt32(lblDelCost.Text);
        order.DatePlaced = DateTime.Now;

        //Create Invoice Session Varible
        Session["invoice"] = new Invoice(order);

        //Direct to payment screen
        Response.Redirect("~/secure/payment.aspx");

    }//btnInvoice_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// set and calculate delivery cost.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDelivery_SelectedIndexChanged(object sender, EventArgs e)
    {
        double totalCost = 0;

        switch (ddlDelivery.SelectedIndex)
        {
            case 0:
                lblTotal.Text = lblBasketCost.Text;
                lblDelCost.Text = "0";
                break;
            case 1:
                totalCost = Convert.ToDouble(lblHiddenCost.Text) + 10;
                lblTotal.Text = totalCost.ToString("##.00");
                lblDelCost.Text = "10";
                break;
            case 2:
                totalCost = Convert.ToDouble(lblHiddenCost.Text) + 5;
                lblTotal.Text = totalCost.ToString("##.00");
                lblDelCost.Text = "5";
                break;
        }//switch

    }//ddlDelivery_SelectedIndexChanged

}//namespace