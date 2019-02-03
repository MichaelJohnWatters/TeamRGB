using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop : System.Web.UI.Page
{
    public static string filterValue { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            System.Data.DataSet ds = null;
            if (!IsPostBack)
            {
                filterValue = null;
                //If Navigation to the page contains a query string
                if (Request.QueryString["search"] != null)
                {
                    //set Filter value
                    filterValue = Request.QueryString["search"].ToString();

                    //Set Search bar text
                    txtSearchBar.Text = Request.QueryString["search"];
                    string filter = Request.QueryString["search"];
                    if (filter == "PC")
                    {
                        ds = Product.getProductsPC();
                    }
                    else if (filter == "XBOX")
                    {
                        ds = Product.getProductsXBOX();
                    }
                    else if (filter == "PS")
                    {
                        ds = Product.getProductsPS();
                    }
                    else if (filter == "GAMES")
                    {
                        ds = Product.getProductsGAMES();
                    }
                    else
                    {
                        //if query string does not match(prevents user forcing Query string).
                        ds = Product.searchShopFilter(filter);
                    }//else
                }//if
                else
                {
                    //if Query string does not exist.
                    ds = Product.searchShopFilter(filterValue);
                }//else
            }//if
            else
            {
                //If is postback on page.
                ds = Product.searchShopFilter(filterValue);
            }//else

            //Fill Shop Grid view with data
            dgvProducts2.DataSource = ds.Tables["dtProducts2"];

            dgvProducts2.AllowPaging = true;
            dgvProducts2.PageSize = 8;

            dgvProducts2.DataBind();
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }//catch

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// When the user clicks on the "view" button for a product,
    /// it will set a session varible and navigate to the page to display the product.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvProducts2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //set filter value
            filterValue = txtSearchBar.Text;

            /*Using Session Varible to select which product to display*/
            Session["SelectedProductID"] = dgvProducts2.Rows[dgvProducts2.SelectedIndex].Cells[0].Text;

        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
        Response.Redirect("~/productDetails.aspx");

    }//dgvProducts2_SelectedIndexChanged

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Managers the user selecting the next page of the gridview.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvProducts2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //set filter value
            filterValue = txtSearchBar.Text;

            dgvProducts2.PageIndex = e.NewPageIndex;
            dgvProducts2.DataBind();
        }catch(Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");

        }//catch

    }//dgvProducts2_PageIndexChanging

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This button is used to filter the Gridviews contents
    /// this allows the user to "search" for items the prefer.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchButton_Click(object sender, EventArgs e)
    {
        try
        {
            //set filter value
            filterValue = txtSearchBar.Text;

            System.Data.DataSet ds = Product.searchShopFilter(txtSearchBar.Text.ToString());
            dgvProducts2.DataSource = ds.Tables["dtProducts2"];

            dgvProducts2.AllowPaging = true;
            dgvProducts2.PageSize = 8;

            dgvProducts2.DataBind();
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }//catch

    }//btnSearchButton_Click

}//namespace