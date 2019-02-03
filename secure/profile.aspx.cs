using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secure_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //display Admin navbutton if user is the admin
        if (User.Identity.IsAuthenticated && User.Identity.Name == "admin@outlook.com")
        {
            btnGoToAdmin.Visible = true;
        }
        else
        {
            btnGoToAdmin.Visible = false;
        }

        if (!IsPostBack)
        {
            if (Session["customer"] != null)
            {
                //display customer.
                displayCustomerDetails();
            }//if
            else
            {
                Response.Redirect("~/login.aspx");
            }//else

        }//!isPostBack

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// saves the users changes to their profile info.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        try
        {
            //get current customer
            Customer customer = (Customer)Session["customer"];

            //Get the text set by the user.
            customer.FirstName = txtFirstName.Text;
            customer.SecondName = txtSecondName.Text;
            customer.Address = txtAddress.Text;
            customer.PostCode = txtPostCode.Text;
            customer.Country = txtCountry.Text;
            customer.Pwd = txtPwd.Text;
            customer.SecurityQuestion = txtSecurityQuestion.Text;
            customer.SecurityAnswer = txtSecurityAnswer.Text;

            //Update
            customer.updateCustomer(customer);

            //Force log the user out.
            System.Web.Security.FormsAuthentication.SignOut();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
        //redirect to login
        Response.Redirect("~/login.aspx");


    }//btnSaveChanges_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Displays the customers details to the screen labels.
    /// 
    /// </summary>
    protected void displayCustomerDetails()
    {
        try
        {
            Customer customer = (Customer)Session["customer"];
            lblCustomerIDValue.Text = customer.CustomerID.ToString();
            txtFirstName.Text = customer.FirstName;
            txtSecondName.Text = customer.SecondName;
            txtAddress.Text = customer.Address;
            txtPostCode.Text = customer.PostCode;
            txtCountry.Text = customer.Country;
            lblEmailValue.Text = customer.Email;
            txtPwd.Text = customer.Pwd;
            txtSecurityQuestion.Text = customer.SecurityQuestion;
            txtSecurityAnswer.Text = customer.SecurityAnswer;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//displayCustomerDetails

    protected void btnGoToAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/secureAdmin/manager.aspx");
    }//btnGoToAdmin_Click
}//namespace