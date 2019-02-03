using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secureAdmin_manager : System.Web.UI.Page
{
    ArrayList products;

    protected void Page_Load(object sender, EventArgs e)
    {
        products = Product.getProductsForManager();

        if (!IsPostBack)
        {
            products = Product.getProductsForManager();
            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());

            }//foreach
            displayPage();

        }
        else
        {
            products = Product.getProductsForManager();
            displayPage();
        }


    }//Page_Load

    public void displayPage()
    {
        //Load all orders
        DataSet ds = null;
        try
        {
            ds = Order.displayAllOrders();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }

        grvAllOrdersValue.DataSource = ds.Tables["grvAllOrdersValue"];
        grvAllOrdersValue.AllowPaging = false;
        grvAllOrdersValue.DataBind();

        //load all Products
        DataSet dsProducts = null;
        try
        {
            dsProducts = Product.getProductsForManagerDataSet();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }

        grvAllProduct.DataSource = dsProducts.Tables["grvAllProduct"];
        grvAllProduct.AllowPaging = true;
        grvAllProduct.PageSize = 10;
        grvAllProduct.DataBind();

        lblWarning.Visible = false;
    }//displayPage

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Add stock to the selected product.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddStock_Click(object sender, EventArgs e)
    {
        try
        {
            //hidden stock change from direct ddl
            Product.updateStockSingleProduct(hiddenAddStock.Value, Convert.ToInt32(txtAddStockValue.Text));
            lblStockMessage.Text = "Successful Stock Update!";
            Color color = new Color();
            color = Color.Green;
            lblStockMessage.ForeColor = color;
            lblStockMessage.Visible = true;
            displayPage();
        }
        catch (Exception ex)
        {
            lblStockMessage.Text = "Error stock update failed";
            Color color = new Color();
            color = Color.Red;
            lblStockMessage.ForeColor = color;
            lblStockMessage.Visible = true;
        }
        txtAddStockValue.Text = null;
    }//btnAddStock_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Create a new product, add to the database and upload image to image folder.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCreateNewProduct_Click(object sender, EventArgs e)
    {
        try
        {
            Product newProduct = new Product();
            newProduct.ProductName = txtNewProductName.Text;
            newProduct.Description = txtNewProductDesc.Text;
            newProduct.Price = Convert.ToDouble(txtNewProductPrice.Text);
            newProduct.Stock = Convert.ToInt32(txtNewProductStockLevel.Text);

            newProduct.TypeID = ddlType.SelectedIndex + 1;
            if (fulNewProductImage.HasFile && fulNewProductImage.PostedFile.ContentType == "image/jpeg")
            {
                newProduct.ProductName = txtNewProductName.Text;
                newProduct.Description = txtNewProductDesc.Text;
                newProduct.Price = Convert.ToDouble(txtNewProductPrice.Text);
                newProduct.Stock = Convert.ToInt32(txtNewProductStockLevel.Text);
                newProduct.TypeID = ddlType.SelectedIndex + 1;
                newProduct.ImageLocation = "images/" + fulNewProductImage.FileName;

                //Add Image to images folder.
                fulNewProductImage.SaveAs(Server.MapPath("~/images/") + fulNewProductImage.FileName);

                //Run Insert new Product in database.
                int rowsUpdated = Product.addNewProduct(newProduct);

                Color color = new Color();
                color = Color.Green;
                lblWarning.ForeColor = color;
                lblWarning.Visible = true;
                lblWarning.Text = "successful addition New Product Rows Added: " + rowsUpdated.ToString();

                txtNewProductName.Text = "";
                txtNewProductDesc.Text = "";
                txtNewProductPrice.Text = "";
                txtNewProductStockLevel.Text = "";

            }
            else
            {
                Color color = new Color();
                color = Color.Red;
                lblWarning.ForeColor = color;
                lblWarning.Text = "Please Select an image file.jpg (current type: " + fulNewProductImage.PostedFile.ContentType + ")";
                lblWarning.Visible = true;
            }

            //MAYBE REMOVE
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        catch (Exception ex)
        {
            Color color = new Color();
            color = Color.Red;
            lblWarning.ForeColor = color;
            lblWarning.Text = "Invalid input Product form!";
            lblWarning.Visible = true;
        }//catch

    }//btnCreateNewProduct_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// Refresh the DDL to display new add stock
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefreshProdudctsDDL_Click(object sender, EventArgs e)
    {
        ddlProductID.Items.Clear();
        foreach (Product item in products)
        {
            ddlProductID.Items.Add(item.ProductName.ToString());
        }
        lblStockMessage.Visible = false;
    }//btnRefreshProdudctsDDL_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// handle the user selecting the next page in the gridview.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grvAllProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvAllProduct.PageIndex = e.NewPageIndex;
            grvAllProduct.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//grvAllProduct_PageIndexChanging

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// used to cause postback to refresh aspects of the page.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefreshProducts_Click(object sender, EventArgs e)
    {
        //used to refresh the page.(cause postback).
    }//btnRefreshProducts_Click

    /// <summary>
    /// 
    /// used to force and exception for demo purposes.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCauseException_Click(object sender, EventArgs e)
    {
        try
        {
            throw new Exception("Test error page");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//btnCauseException_Click

    protected void btnUpdateName_Click(object sender, EventArgs e)
    {
        string column = "ProductName";
        string value = txtUpdateName.Text.ToString();
        string productName = ddlUpdateProduct.SelectedValue.ToString();

        try
        {
            //try to update Product Name
            Product.updateColumnString(value, column, productName);
            Color color = new Color();
            color = Color.Green;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Name successful...";
            //MAYBE REMOVE
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        catch (Exception ex)
        {
            Color color = new Color();
            color = Color.Red;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Name failed...";
        }//catch
        txtUpdateName.Text = null;

    }//btnUpdateName_Click

    protected void btnRefreshUpdate_Click(object sender, EventArgs e)
    {
        ddlUpdateProduct.Items.Clear();
        foreach (Product item in products)
        {
            ddlUpdateProduct.Items.Add(item.ProductName.ToString());
        }
        lblUpdateWarning.Visible = false;
    }//btnRefreshUpdate_Click

    protected void btnUpdateDesc_Click(object sender, EventArgs e)
    {
        string column = "Description";
        string value = txtUpdateDesc.Text.ToString();
        string productName = ddlUpdateProduct.SelectedValue.ToString();

        try
        {
            //try to update Product Name
            Product.updateColumnString(value, column, productName);
            Color color = new Color();
            color = Color.Green;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Description successful...";
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        catch (Exception ex)
        {
            Color color = new Color();
            color = Color.Red;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Description failed...";
        }//catch
        txtUpdateDesc.Text = null;
    }//btnUpdateDesc_Click



    protected void btnUpdatePrice_Click(object sender, EventArgs e)
    {
        string column = "Price";
        string productName = ddlUpdateProduct.SelectedValue.ToString();

        try
        {
            double value = Convert.ToDouble(txtUpdatePrice.Text.ToString());
            //try to update Product Name
            Product.updateColumnDouble(value, column, productName);
            Color color = new Color();
            color = Color.Green;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Price successful...";
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        catch (Exception ex)
        {
            Color color = new Color();
            color = Color.Red;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Price failed...";
        }//catch
        txtUpdatePrice.Text = null;
    }

    protected void btnUpdateType_Click(object sender, EventArgs e)
    {
        string column = "TypeID";
        string value = ddlUpdateType.SelectedValue.ToString();
        string productName = ddlUpdateProduct.SelectedValue.ToString();
        int num = 0;

        if (value == "PC")
        {
            num = 1;
        }
        else if (value == "PS")
        {
            num = 2;
        }
        else if (value == "XBOX")
        {
            num = 3;
        }
        else if (value == "GAMES")
        {
            num = 4;
        }

        try
        {
            //try to update Product type
            Product.updateColumnInt(num, column, productName);
            Color color = new Color();
            color = Color.Green;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Type successful...";
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        catch (Exception ex)
        {
            Color color = new Color();
            color = Color.Red;
            lblUpdateWarning.ForeColor = color;
            lblUpdateWarning.Visible = true;
            lblUpdateWarning.Text = "Update Type failed...";
        }//catch
    }

    protected void btnUpdateImage_Click(object sender, EventArgs e)
    {
        string column = "ImageLocation";
        string productName = ddlUpdateProduct.SelectedValue.ToString();

        if (fulUpdateImage.HasFile && fulUpdateImage.PostedFile.ContentType == "image/jpeg")
        {
            string imageLocation = "images/" + fulUpdateImage.FileName;

            //Add Image to images folder.
            fulUpdateImage.SaveAs(Server.MapPath("~/images/") + fulUpdateImage.FileName);

            //Run Insert new Product in database.
            Product.updateColumnString(imageLocation, column, productName);

            Color color = new Color();
            color = Color.Green;
            lblWarning.ForeColor = color;
            lblWarning.Visible = true;
            lblWarning.Text = "successful update of image";

            txtNewProductName.Text = "";
            txtNewProductDesc.Text = "";
            txtNewProductPrice.Text = "";
            txtNewProductStockLevel.Text = "";
            ddlProductID.Items.Clear();
            ddlUpdateProduct.Items.Clear();
            products = Product.getProductsForManager();

            foreach (Product item in products)
            {
                //populate drop down list with current items.
                ddlProductID.Items.Add(item.ProductName.ToString());
                ddlUpdateProduct.Items.Add(item.ProductName.ToString());
            }//foreach
            displayPage();
        }
        else
        {
            Color color = new Color();
            color = Color.Red;
            lblWarning.ForeColor = color;
            lblWarning.Text = "Please Select an image file.jpg (current type: " + fulUpdateImage.PostedFile.ContentType + ")";
            lblWarning.Visible = true;
        }//else
    }//btnUpdateImage_Click

    protected void ddlProductID_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddenAddStock.Value = ddlProductID.SelectedValue;
    }

    protected void ddlUpdateProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddenUpdateProduct.Value = ddlUpdateProduct.SelectedValue;
    }
}//namespace