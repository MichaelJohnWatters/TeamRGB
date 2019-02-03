using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        displayCart();
    }//Page_Load
    public void displayCart()
    {
        try
        {
            this.pnlOrders.Controls.Clear();

            if (Session["ShoppingBasket"] != null)
            {
                ArrayList arrCart = (ArrayList)Session["ShoppingBasket"];
                double totalCost = 0;
                // go through each item in the cart (ArrayList) and add the details
                for (int loop = 0; loop < arrCart.Count; loop++)
                {
                    StringBuilder sb = new StringBuilder();

                    CartItem cartItem = (CartItem)arrCart[loop];

                    //Createing Label and buttons which are add depending on the number of items in cart.
                    Label itemLabel = new Label();
                    Button remove = new Button();
                    remove.Width = 80;
                    remove.Text = "Remove";
                    remove.ID = loop.ToString();
                    remove.CssClass = "btn-remove";

                    remove.Click += delegate (object sender, EventArgs e)
                    {
                        this.remove(sender, e, Convert.ToInt32(remove.ID));
                    };

                    //index of the remove button
                    int index;
                    index = Convert.ToInt32(loop);

                    //itemLabel.CssClass = "cartInfo";

                    sb.Append("<br><hr><br>");
                    sb.Append("Name : " + cartItem.Product.ProductName + "<br>");
                    sb.Append("Quantity: " + cartItem.Quantity + "<br>");
                    double cost = (cartItem.Product.Price * cartItem.Quantity);
                    totalCost += cost;
                    sb.Append("Combined Cost : $" + cost.ToString("##.00") + "<br>");
                    itemLabel.Text = sb.ToString();

                    // add the item controls (labels) to the panel  
                    this.pnlOrders.Controls.Add(itemLabel);
                    this.pnlOrders.Controls.Add(remove);

                }//for
                Label lbltotalCost = new Label();
                lbltotalCost.Text = "<br><hr><br>Total Cost $" + totalCost.ToString("##.00");
                pnlOrders.Controls.Add(lbltotalCost);
            }//if
            else
            {
                Label itemLabel = new Label();
                itemLabel.Text = "You have 0 items in your cart";
                pnlOrders.Controls.Add(itemLabel);
            }//else
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//displayCart

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// clears the users shoping basket.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Remove("ShoppingBasket");
            displayCart();
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//btnClear_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// navigates the user to the checkOut page to finalise order.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/secure/checkOut.aspx");
    }//btnPurchase_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Removes the selected cartItem from the shopping basket.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <param name="index"></param>
    protected void remove(object sender, EventArgs e, int index)
    {
        try
        {
            ArrayList arrCart = (ArrayList)Session["ShoppingBasket"];

            //will remove shopping cart if the user tries to remove with only 1 cart item left.
            if (arrCart.Count == 1)
            {
                Session.Remove("ShoppingBasket");
            }//if
            else
            {
                arrCart.RemoveAt(index);
            }//else
            displayCart();
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//remove
}//namespace