using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Create a new user based on the info supplied by the user.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Click(object sender, EventArgs e)
    {
        bool failedLogin = false;

            Customer newCustomer = new Customer();
            newCustomer.FirstName = txtFirstName.Text;
            newCustomer.SecondName = txtSecondName.Text;
            newCustomer.Address = txtAddress.Text;
            newCustomer.PostCode = txtPostCode.Text;
            newCustomer.Country = txtCountry.Text;
            newCustomer.Email = txtEmail.Text;

        //Check if email address is free (not taken)
        if (Customer.checkEmailExists(newCustomer.Email) == false)
        {
            //if password and repeat password are the same.
            if (txtPassword.Text == txtPasswordCheck.Text)
            {
                newCustomer.Pwd = txtPassword.Text;
            }//if
            try
            {
                Customer cust = Customer.createAccount(newCustomer);
                failedLogin = false;
            }
            catch (Exception ex)
            {
                failedLogin = true;
            }
            if (failedLogin == true)
            {
                lblMessage.Text = "Error Account Not Created";
            }//if
            else
            {
                Response.Redirect("~/login.aspx");
            }//else
        }
        else {
            lblMessage.Text = "Email Already Exists please choose another.";
        }//else

    }//btn_click

}//createAccount