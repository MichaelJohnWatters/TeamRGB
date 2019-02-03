using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            //you are allready logged on
            Response.Redirect("~/index.aspx");
        }//if

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Check for the user in the database if name and pass match, check if user is an admin.
    /// if is admin send to the admin page.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            //check if user is Admin
            if (txtEmail.Text == "admin@outlook.com")
            {
                Customer customer = Customer.checkLogin(txtEmail.Text, txtPassword.Text);

                if (customer != null)
                {
                    Session["customer"] = customer;
                    FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, chkPersist.Checked);
                    //Response.Redirect("~/secureAdmin/manager.aspx");
                }//if
                else
                {
                    lblMsg.Text = "Login Failed Please input correct details.";
                }//else

            }//if
            else
            {
                Customer customer = Customer.checkLogin(txtEmail.Text, txtPassword.Text);

                if (customer != null)
                {
                    Session["customer"] = customer;
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(customer.FirstName, chkPersist.Checked);
                }//if
                else
                {
                    lblMsg.Text = "Login Failed Please input correct details.";
                }//else

            }//else
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//btn_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// sets colorings for the check button.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkPersist_CheckedChanged(object sender, EventArgs e)
    {
        //TEMP find javascrip way to change the colors of the remeber me if possible
        if (chkPersist.Checked == true)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(255, 255, 255);
            chkPersist.ForeColor = myRgbColor;
        }//if
        else
        {
            Color color = new Color();
            color = Color.DimGray;
            chkPersist.ForeColor = color;
        }//else

    }//chkPersist_CheckedChanged

}//namespace