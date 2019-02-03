using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_trackOrdersSpecfic : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //If no session varibles go to track orders page
        if (Session["SelectedOrderID"] == null || Session["SelectedOrderDate"] == null || Session["SelectedOrderPrice"]==null || Session["SelectedOrderDelivery"]==null)
        {
            Response.Redirect("~/secure/trackOrders.aspx");
        }//if
        try
        {
            string id = Session["SelectedOrderID"].ToString();
            string date = Session["SelectedOrderDate"].ToString();
            string price = Session["SelectedOrderPrice"].ToString();
            string del = Session["SelectedOrderDelivery"].ToString();
            displayOrder(id, date, price,del);

            System.Data.DataSet ds = DataAccess.getOrderLines(Convert.ToInt32(id));
            dgvOrderlines.DataSource = ds.Tables["dtOrderlines"];
            dgvOrderlines.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");

        }
    }//Page_Load

    /// <summary>
    /// 
    /// </summary>
    /// <param name="OrderID"></param>
    /// <param name="date"></param>
    /// <param name="price"></param>
    /// <param name="delivery"></param>
    private void displayOrder(string OrderID, string date, string price, string delivery)
    {
        lblOrderID.Text = OrderID.ToString();
        lblDate.Text = date.ToString();
        lblPrice.Text = price.ToString();
        lblDel.Text = delivery.ToString();
    }//displayOrder

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/secure/trackOrders.aspx");
    }
}//namespace