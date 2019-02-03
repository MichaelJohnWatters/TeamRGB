using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class productDetails : System.Web.UI.Page
{
    //current Product ID selected by the user.
    private string currentProductID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["SelectedProductID"] == null)
                {

                }//if
                else
                {
                    currentProductID = Session["SelectedProductID"].ToString();

                    //Creating a cookie holding the users last viewed product.
                    HttpCookie lastViewedCookie = new HttpCookie("teamRGBCookie");

                    //set Values in cookie
                    lastViewedCookie["lastViewedID"] = Session["SelectedProductID"].ToString();

                    //Add Expire Time to the Persistent cookie (lasts 1 year).
                    lastViewedCookie.Expires = DateTime.Now.AddDays(365);

                    //add cookie to the Web session.
                    Response.Cookies.Add(lastViewedCookie);

                    //Display Product using Session Varible
                    displayProduct(Session["SelectedProductID"].ToString());
                    displayReviews(Convert.ToInt32(Session["SelectedProductID"]));
                }//else
            }
            else
            {
                //if is postback
                //if below enabled messes up quantity selection MIGHT BE FIXED
                displayReviews(Convert.ToInt32(Session["SelectedProductID"]));

                currentProductID = Session["SelectedProductID"].ToString();
            }//if
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//Page_Load

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This method displays the product information 
    /// for the selected ID.
    /// 
    /// </summary>
    /// <param name="productID"></param>
    private void displayProduct(string productID)
    {
        try
        {
            lblProductID.Text = productID.ToString();

            //create a tmpProduct object using the loadProduct method 
            Product tempProduct = new Product();

            //Load the product information from the database.
            tempProduct.loadProduct(productID.ToString());

            // display the data within the tempProduct object 
            lblProductName.Text = tempProduct.ProductName;
            lblTypeName.Text = "Product Type : " + tempProduct.TypeName;
            lblDescription.Text = "Description : " + tempProduct.Description;
            imgProduct.ImageUrl = tempProduct.ImageLocation;
            lblPrice.Text = "Price : $" + tempProduct.Price.ToString("##.00");

            //ensure drop down list is empty
            ddlStock.Items.Clear();

            //remove the abbilty of the user to buy a product if there is no Items left.
            if (tempProduct.Stock <= 0)
            {
                ddlStock.Visible = false;
                lblQuantity.Text = "Out of Stock";
                Color myRgbColor = new Color();
                myRgbColor = Color.FromArgb(255, 0, 0);
                lblQuantity.ForeColor = myRgbColor;
                btnAdd.Visible = false;

            }//if
            else
            {
                //using the inStock value to populate the drop down list
                btnAdd.Visible = true;
                ddlStock.Visible = true;
                for (int index = 1; index <= tempProduct.Stock; index++)
                {
                    ddlStock.Items.Add(index.ToString());
                }//for

            }//else
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");

        }
    }//displayProduct

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This method displays the reviews for the current product selected.
    /// 
    /// </summary>
    /// <param name="productID"></param>
    private void displayReviews(int productID)
    {
        try
        {
            // clear the panel that may have previous items
            this.pnlReviews.Controls.Clear();

            //Pull Resultset from 
            ArrayList arrReviews = Review.ReviewsSpecficProduct(productID);

            //for each thing in result set.
            foreach (Review review in arrReviews)
            {
                StringBuilder stringBuilder = new StringBuilder();

                //Create controls for each review
                Label lblReviewText = new Label();

                Button btnUpvote = new Button();
                btnUpvote.CssClass = "btn-up";

                btnUpvote.Width = 100;

                //set ID of button to review ID from database
                btnUpvote.ID = review.ReviewID.ToString();

                //UpVote
                btnUpvote.Click += delegate (object sender, EventArgs e)
                {
                    this.btnUpvote(sender, e, Convert.ToInt32(btnUpvote.ID));
                };

                //Build Text for Review Output
                stringBuilder.Append("<hr><h3>");
                stringBuilder.Append(review.Title);
                stringBuilder.Append(" ");

                //Process Number of Stars
                bool[] arrStars = { false, false, false, false, false };
                for (int i = 0; i < review.Rating; i++)
                {
                    arrStars[i] = true;
                }//for

                //Add Correct Star icons to stringbulder
                foreach (bool item in arrStars)
                {
                    if (item == true)
                    {
                        //Add solid star
                        stringBuilder.Append(@"<i class=""fas fa-star""></i>");
                    }//if
                    else
                    {
                        //Add hollow stars
                        stringBuilder.Append(@"<i class=""far fa-star""></i>");
                    }//else

                }//foreach

                //Append string used to display a review.
                stringBuilder.Append("</h3>");
                stringBuilder.Append(review.Message);
                stringBuilder.Append("<br><br>");
                stringBuilder.Append("Reviewed by: " + review.Customer.FirstName + " " + review.Customer.SecondName);
                stringBuilder.Append("<br><br>");

                lblReviewText.Text = stringBuilder.ToString();
                btnUpvote.Text = "Like (" + review.ThumbsUp + ")";

                // add the item controls to the panel  
                this.pnlReviews.Controls.Add(lblReviewText);

                //this.pnlReviews.Controls.Add(lblReviewID);
                this.pnlReviews.Controls.Add(btnUpvote);

            }//foreach
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");

        }
    }//displayReviews

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This button allows the user to add 
    /// the selected quantity and product to their cart.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && Session["customer"] != null)
        {
            //Add to Cart
            ArrayList basket;
            Product currentProduct = new Product();
            try
            {
                //load product details from database.
                currentProduct.loadProduct(currentProductID);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString();
                Response.Redirect("~/error.aspx");
            }
            //get selected quantity.
            int quant = Convert.ToInt32(ddlStock.SelectedValue);
            CartItem item = new CartItem(currentProduct, quant);

            if (Session["ShoppingBasket"] != null)
            {
                basket = (ArrayList)Session["ShoppingBasket"];
            }//if
            else
            {
                basket = new ArrayList();
            }//else
            basket.Add(item);

            //create ShoppingBasket session variable
            Session["ShoppingBasket"] = basket;

            Response.Redirect("~/shop.aspx");
        }//if
        else
        {
            Response.Redirect("~/login.aspx");
        }//else
    }//btnAdd_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This button allows the user to write a review for a product.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && Session["customer"] != null)
        {
            //Submit Review
            Review review = new Review();
            int temp = Convert.ToInt32(lblProductID.Text);
            review.ProductID = temp;

            //review.ProductID = Convert.ToInt32(lblProductID.Text);
            review.Customer = (Customer)Session["customer"];
            review.Message = txtWriteCommentText.Text;
            review.Title = txtWriteCommentTitle.Text;
            review.ThumbsDown = 0;
            review.ThumbsUp = 0;

            //Get Rating for review
            if (star0.Checked)
            {
                review.Rating = 0;
            }
            else if (star1.Checked)
            {
                review.Rating = 1;
            }
            else if (star2.Checked)
            {
                review.Rating = 2;
            }
            else if (star3.Checked)
            {
                review.Rating = 3;
            }
            else if (star4.Checked)
            {
                review.Rating = 4;
            }
            else if (star5.Checked)
            {
                review.Rating = 5;
            }

            try
            {
                //Insert Review
                Review.InsertReview(review);
            }
            catch (Exception ex) {
                Session["error"] = ex.ToString();
                Response.Redirect("~/error.aspx");
            }

            //Clear Review boxes
            txtWriteCommentText.Text = "";
            txtWriteCommentTitle.Text = "";
            star0.Checked = true;

            try
            {
                //Display page 
                displayProduct(Session["SelectedProductID"].ToString());
                displayReviews(Convert.ToInt32(Session["SelectedProductID"]));
            }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString();
                Response.Redirect("~/error.aspx");
            }//catch

        }//if
        else
        {
            //Prompt to loggin
            Response.Redirect("~/login.aspx");
        }//else

    }//btnSubmitComment_Click

    /// <summary>
    /// author Michael Watters
    /// created 1/1/2019
    /// 
    /// This Method allows the user to upVote reviews.
    /// so they can be display by most popular.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <param name="id"></param>
    private void btnUpvote(object sender, EventArgs e, int id)
    {
        try
        {
            //Process upVote
            Review.upVote(Convert.ToInt32(id));
            displayReviews(Convert.ToInt32(currentProductID));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.ToString();
            Response.Redirect("~/error.aspx");
        }
    }//btnUpvote
}//namespace