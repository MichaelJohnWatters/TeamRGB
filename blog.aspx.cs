using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            loadBlog();

            //display logged in users name.
            if (User.Identity.IsAuthenticated)
            {
                lblStatusBlog.Text = "User: " + User.Identity.Name;
            }//if
            else
            {
                lblStatusBlog.Text = "unknown user";
            }//else
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Submits a message to be added to the blog
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string user = "unknown";
            if (User.Identity.IsAuthenticated)
            {
                user = User.Identity.Name;
            }//if
             //write the message to the file used to display the blog.
            txtBlog.Text += user + " >> " + DateTime.UtcNow.ToShortTimeString() +
                          " >> " + txtEntry.Text + "\n";
            File.WriteAllText(Server.MapPath("~/Files/txtBlog.txt"), txtBlog.Text);
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//btnSubmit_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This method loads the blog, and displays to the screen.
    /// 
    /// </summary>
    protected void loadBlog() {
        try
        {
            String[] strBlog = File.ReadAllLines(Server.MapPath("~/Files/txtBlog.txt"));
            txtBlog.Text = "";

            foreach (String line in strBlog)
            {
                txtBlog.Text += line;
                txtBlog.Text += "\n";
            }//foreach
        }
        catch (Exception ex) {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//loadBlog

}//namespace