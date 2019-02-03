using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
    /// <summary>
    /// Author Jude
    /// 
    /// this is a page load.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = Session["error"].ToString();
        }
        catch (Exception ex) {
            lblError.Text = ex.ToString();
        }
    }//Page_Load

    /// <summary>
    /// Author Jude.
    /// this method returns the user to index page.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIndezx_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }//btnIndezx_Click
}//class