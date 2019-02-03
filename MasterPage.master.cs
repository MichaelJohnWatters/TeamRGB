using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set the dynamic label used to display logged in user.
        lblAccount.Text = "Login";

        //maybee remove session
        if (Context.User.Identity.IsAuthenticated && Session["customer"] != null)
        {
            //Set the dynamic label used to display logged in user.
            lblAccount.Text = Context.User.Identity.Name;
        }//if
        else
        {
            lblAccount.Text = "Login";
        }//else

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Logs the user out and remove attached session varibles.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
        FormsAuthentication.SignOut();
        Session.Remove("ShoppingBasket");
        Session.Remove("customer");
        Response.Redirect("~/index.aspx");

    }//btnLogin_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This Method is used to log the user out.
    /// 
    /// </summary>
    protected void logOut()
    {
        FormsAuthentication.SignOut();
        Session.Remove("ShoppingBasket");
        Session.Remove("customer");
        Response.Redirect("~/index.aspx");
    }//logOut

}//namespace
