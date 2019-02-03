using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_trackOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && Session["customer"] != null)
        {
            try
            {
                Customer myCust = (Customer)Session["customer"];
                System.Data.DataSet ds = Order.getAllOrdersCustomer(myCust.CustomerID);
                dvgOrders.DataSource = ds.Tables["dtOrders"];

                dvgOrders.AllowPaging = true;
                dvgOrders.PageSize = 10;

                dvgOrders.DataBind();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString();
                Response.Redirect("~/error.aspx");
            }
        }//if
        else {
            Response.Redirect("~/login.aspx");
        }

    }//Page_Load

    protected void dvgOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*Using Session Variable to select which order to display*/
        Session["SelectedOrderID"] = dvgOrders.Rows[dvgOrders.SelectedIndex].Cells[0].Text;
        string del = dvgOrders.Rows[dvgOrders.SelectedIndex].Cells[0].Text;
        Session["SelectedOrderDate"] = dvgOrders.Rows[dvgOrders.SelectedIndex].Cells[1].Text;
        Session["SelectedOrderPrice"] = dvgOrders.Rows[dvgOrders.SelectedIndex].Cells[2].Text;
        try
        {
            Session["SelectedOrderDelivery"] = Order.getDel(Convert.ToInt32(del));
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
        Response.Redirect("~/secure/trackOrdersSpecfic.aspx");

    }//dvgOrders_SelectedIndexChanged

    protected void dvgOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dvgOrders.PageIndex = e.NewPageIndex;
            dvgOrders.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");

        }//catch

    }//dvgOrders_PageIndexChanging

}//namespace