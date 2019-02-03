using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.Cookies["teamRGBCookie"] != null)
            {
                //check if they have ever viewed a product before and display it.
                HttpCookie lastViewedCookie = Request.Cookies["teamRGBCookie"];
                if (lastViewedCookie != null)
                {
                    string lastViewedID = lastViewedCookie["lastViewedID"];

                    //Display id of lastViewed Product ID to the screen.
                    lblIDOfLastViewed.Text = lastViewedID;

                    //use id to load picture of 
                    Product tempProduct = new Product();
                    tempProduct.loadProduct(lastViewedID.ToString());

                    imgBtnlastViewedProductImage.ImageUrl = tempProduct.ImageLocation;
                }
                else
                {
                    //if not display placeholder for no prev item viewed.
                    imgBtnlastViewedProductImage.ImageUrl = "~/images/X.png";
                    lblIDOfLastViewed.Text = "";
                }//else
            }//if
            else
            {
                //display placeholder for no prev item viewed
                imgBtnlastViewedProductImage.ImageUrl = "~/images/X.png";
                lblIDOfLastViewed.Text = "";
            }//else
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
    /// this button will navigate the user to the last viewed product using cookies
    /// 
    /// if the user has never viewed a product user will not be navigated.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnlastViewedProductImage_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Cookies["teamRGBCookie"] != null)
        {
            //check if they have ever viewed a product before and display it.
            HttpCookie lastViewedCookie = Request.Cookies["teamRGBCookie"];
            //Set session ID for selectedProduct to allow for navigation to ProductDetails.
            Session["SelectedProductID"] = lastViewedCookie["lastViewedID"];

            //navigation to product details
            Response.Redirect("~/productDetails.aspx");
        }//if

    }//imgBtnlastViewedProductImage_Click

}//namespace