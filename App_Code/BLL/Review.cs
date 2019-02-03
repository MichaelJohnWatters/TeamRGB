using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// create 5/11/2018
/// This Class represents a Review of product, that users make on each product page.
/// </summary>
public class Review
{
    public int ReviewID { get;}
    public int ProductID { get; set; }
    public Customer Customer{ get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public int Rating { get; set; }
    public int ThumbsUp { get; set; }
    public int ThumbsDown { get; set; }

    //empty Constructor
    public Review() {

    }//constructor

    //full Constructor
    public Review(int reviewID, int productID, Customer customer, string title, string message, int rating, int thumbsUp, int thumbsDown)
    {
        this.ReviewID = reviewID;
        this.ProductID = productID;
        this.Customer = customer;
        this.Title = title;
        this.Message = message;
        this.Rating = rating;
        this.ThumbsUp = thumbsUp;
        this.ThumbsDown = thumbsDown;
    }//constructor

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// Controller Method
    /// Creates and arraylist of reviews that is used to displays reviews.
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static ArrayList ReviewsSpecficProduct(int productID) {
        return DataAccess.ReviewsSpecficProduct(productID);
    }//ReviewsSpecficProduct

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// Controller Method
    /// Method used to create a new review on the site.
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    public static string InsertReview(Review review) {
        return DataAccess.InsertReview(review);
    }//InsertReview

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// Controller Method
    /// Used to upvote reviews for products
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static int upVote(int id)
    {
        return DataAccess.upVoteReview(id);
    }//upVote

}//class