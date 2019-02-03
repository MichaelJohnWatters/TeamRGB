using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Data.OleDb;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Author Michael Watters, Lukas Audi
/// created 5/11/2018
/// 
/// This class controls all the database functionality within the website.
/// 
/// </summary>
public class DataAccess
{
    public DataAccess()
    {

    }//DataAccess

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// Opens the connection to the database.
    /// </summary>
    /// <returns></returns>
    private static OleDbConnection openConnection()
    {
        // declare the connection string USING RELATIVE PATH
        string conStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =";
        //conStr += System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/database2.mdb");
        //conStr += System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/data3AddedCols.mdb");
        conStr += System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Database.mdb");

        // create connection object
        OleDbConnection conn = new OleDbConnection(conStr);
        conn.Open();

        // connection object returned
        return conn;

    }//openConnection

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// opens the current using Adaptor method using web config.
    /// </summary>
    /// <returns></returns>
    private static OleDbConnection openConnectionAdaptorMethod()
    {
        // path to the root of the web site where the web.config file exists
        string configPath = "~";
        // access to web.config file
        System.Configuration.Configuration rootWebConfig =
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
        // declaring the connection string
        string conStr = null;

        // get the value(s) in the connection string
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            try
            {
                conStr = rootWebConfig.ConnectionStrings.ConnectionStrings["database"].ToString();
            }
            catch (Exception ex)
            {
                conStr = null;
            }

            if (conStr != null)
            {
                HttpContext.Current.Trace.Warn("database connection string = \"{0}\"", conStr);

                //Create an OleDbConnection object using the Connection String
                OleDbConnection cn = new OleDbConnection(conStr);
                //Open the connection.
                cn.Open();
                return cn;
            }
            else
            {
                HttpContext.Current.Trace.Warn("No database connection string");
                return null;
            }
        }//if

        return null;
    }// openConnection

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// Closes the connection with the database.
    /// </summary>
    /// <param name="cn"></param>
    private static void closeConection(OleDbConnection cn)
    {
        cn.Close();
    }//closeConnection

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// Gets a spefic product based on ID of the param
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static Product getProduct(string productID)
    {
        int temp;
        temp = Convert.ToInt32(productID);
        Product product = new Product();
        OleDbConnection conn = openConnection();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE ProductID = " + temp + ";";

        OleDbCommand cmd = new OleDbCommand(sqlString, conn);
        OleDbDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            product.ProductID = (int)reader["ProductID"];
            product.ProductName = (string)reader["ProductName"];
            product.TypeName = (string)reader["TypeName"];
            product.Description = (string)reader["Description"];
            product.ImageLocation = (string)reader["ImageLocation"];
            product.Price = Convert.ToDouble(reader["Price"]);
            product.Stock = Convert.ToInt32(reader["Stock"]);
        }
        reader.Close();
        closeConection(conn);
        return product;
    }//getProduct

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// Gets product arraylist for the manager page.
    /// </summary>
    /// <returns></returns>
    public static ArrayList getProductsForManager()
    {

        ArrayList list = new ArrayList();
        OleDbConnection conn = openConnection();

        //sql string
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID";

        OleDbCommand cmd = new OleDbCommand(sqlString, conn);
        OleDbDataReader reader = cmd.ExecuteReader();

        while (reader.Read() == true)
        {
            Product product = new Product();
            product.ProductName = reader["ProductName"].ToString();
            product.Stock = (int)reader["Stock"];
            product.ProductID = (int)reader["ProductID"];
            list.Add(product);
        }
        //close reader.
        reader.Close();

        conn.Close();
        return list;
    }//getProductsForManager

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// This Method returns a dataset of all the products for the manager to use.
    /// 
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForManagerDataSet()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "grvAllProduct");

        conn.Close();

        return dsProducts;
    }//getProductsForManagerDataSet

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// This method gets all the products for the shop unfiltered
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForShop()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        conn.Close();

        return dsProducts;
    }//getProductForShop

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method gets all the products for the shop filtered by PC
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForShopPC()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE tblProductType.TypeName ='PC'";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        conn.Close();

        return dsProducts;
    }//getProductsForShopPC

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method gets all the products for the shop filter by xbox
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForShopXBOX()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE tblProductType.TypeName ='XBOX'";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        //close connection
        conn.Close();

        return dsProducts;
    }//getProductsForShopXBOX

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method gets all the products from the shop fitler by ps
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForShopPS()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE tblProductType.TypeName ='PS'";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        conn.Close();

        return dsProducts;
    }//getProductsForShopPS

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this gets all the orders for a specifc iD used in the track orders page.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DataSet getOrdersForCustomer(int id)
    {

        OleDbConnection conn = openConnection();
        DataSet dsOrders = new DataSet();
        string sqlString = "SELECT * FROM tblOrder WHERE CustomerID = " + id + " ORDER BY OrderID DESC";
        OleDbDataAdapter daOrders = new OleDbDataAdapter(sqlString, conn);
        daOrders.Fill(dsOrders, "dtOrders");

        conn.Close();

        return dsOrders;
    }//getOrdersForCustomer

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this gets all the products for the shop filtering by GAMES
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForShopGAMES()
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE tblProductType.TypeName ='GAMES'";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        conn.Close();

        return dsProducts;
    }//getProductsForShopGAMES

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this gets all the products for the shop that are like the input filter string.
    /// </summary>
    /// <param name="searchText"></param>
    /// <returns></returns>
    public static DataSet searchShopFilter(string searchText)
    {
        OleDbConnection conn = openConnection();
        DataSet dsProducts = new DataSet();
        string sqlString = "SELECT * FROM tblProducts INNER JOIN tblProductType ON tblProducts.TypeID = tblProductType.TypeID WHERE tblProductType.TypeName LIKE '%"
            + searchText + "%' OR tblProducts.ProductName LIKE '%"
            + searchText + "%' OR tblProducts.Description LIKE '%"
            + searchText + "%'";
        OleDbDataAdapter daProducts = new OleDbDataAdapter(sqlString, conn);
        daProducts.Fill(dsProducts, "dtProducts2");

        conn.Close();

        return dsProducts;
    }

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method check if the email para arllready exists in the database.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool checkEmailExists(string email)
    {
        OleDbConnection cn = openConnection();
        string sqlString = "SELECT email FROM tblCustomer WHERE email = '" + email + "'";

        OleDbCommand cmd = new OleDbCommand(sqlString, cn);
        OleDbDataReader reader = cmd.ExecuteReader();

        while (reader.Read() == true)
        {
            string queryEmail = (string)reader["email"];
            if (queryEmail == email)
            {
                return true;
            }//if
        }//while
        return false;
    }//checkEmailExists

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method allows the user to create a new account in the dataabase
    /// </summary>
    /// <param name="newCustomer"></param>
    /// <returns></returns>
    public static Customer createAccount(Customer newCustomer)
    {

        OleDbConnection cn = openConnection();
        string insertSQL = "INSERT INTO tblCustomer(firstName,secondName,lastViewedProduct,address,postCode,country,email,pwd) "
            + " VALUES ('"
            + newCustomer.FirstName + "', '"
            + newCustomer.SecondName + "','"
            + 0 + "','"
            + newCustomer.Address + "','"
            + newCustomer.PostCode + "','"
            + newCustomer.Country + "','"
            + newCustomer.Email + "','"
            + newCustomer.Pwd
            + "')";
        OleDbCommand cmd = new OleDbCommand(insertSQL, cn);
        //this for non SELECT (NON-QUERY)
        int rowCount = cmd.ExecuteNonQuery();
        //says a finds primary key of last record created.
        cmd.CommandText = "SELECT @@IDENTITY";
        //Scalar returns 1 bit of data.
        //int newCustID = Convert.ToInt32(cmd.ExecuteScalar());
        cn.Close();

        if (rowCount == 1)
        {
            return newCustomer;
        }
        else
        {
            return null;
        }
    }//createAccount

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// This method checks if the users login info is valid and then returns the customer as a object.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static Customer checkLogin(string email, string password)
    {
        OleDbConnection conn = openConnection();
        string sqlString = "SELECT * FROM tblCustomer WHERE email='" + email + "' AND pwd='" + password + "'";

        OleDbCommand cmd = new OleDbCommand(sqlString, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        Customer customer = null;

        while (reader.Read() == true)
        {
            int custID = (int)reader["CustomerID"];
            string firstName = reader["firstName"].ToString();
            string secondName = reader["secondName"].ToString();
            int lastViewedProduct = (int)reader["lastViewedProduct"];
            string address = reader["address"].ToString();
            string postCode = reader["postCode"].ToString();
            string country = reader["country"].ToString();
            string emailDB = reader["email"].ToString();
            string pwd = reader["pwd"].ToString();
            string securityQuestion = reader["securityQuestion"].ToString();
            string securityAnswer = reader["securityAnswer"].ToString();
            customer = new Customer(custID, firstName, secondName, lastViewedProduct, address, postCode, country, emailDB, pwd, securityQuestion, securityAnswer);
        }
        reader.Close();
        closeConection(conn);
        return customer;
    }//checkLogin

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method allows for the insertion of new reviews in the database for products.
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    public static string InsertReview(Review review)
    {
        OleDbConnection conn = openConnection();

        //NEED SQL
        string strSQL = "INSERT INTO tblReview (ProductID, CustomerID, Title, Message, Rating, ThumbsUp, ThumbsDown)"
            + "VALUES ("
            + review.ProductID + ", "
            + review.Customer.CustomerID + ", "
            + "'" + review.Title + "'" + ", "
            + "'" + review.Message + "'" + ", "
            + review.Rating + ", "
            + review.ThumbsUp + ", "
            + review.ThumbsDown
            + ")";

        //create the command object using the SQL
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        // execute the insertion command
        cmd.ExecuteNonQuery();

        //change the SQL to return the new review ID 
        cmd.CommandText = "Select @@Identity";

        string reviewID = cmd.ExecuteScalar().ToString();

        closeConection(conn); // close connection
        return reviewID; // return the review id
    }//InsertReview


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this gets all the reviews for a product specfic by its ID and returns as an arraylist
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static ArrayList ReviewsSpecficProduct(int productID)
    {
        ArrayList arrReviews = new ArrayList();

        //Open Connection
        OleDbConnection cn = openConnection();

        string SQL = "SELECT * FROM tblReview INNER JOIN tblCustomer ON tblReview.CustomerID = tblCustomer.CustomerID WHERE tblReview.ProductID =" + productID + " ORDER BY tblReview.ThumbsUp DESC;";
        try
        {
            //Command Object
            OleDbCommand cmd = new OleDbCommand(SQL, cn);

            //Gets each record matching SQL
            OleDbDataReader reader = cmd.ExecuteReader();

            // reading one record at a time
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.FirstName = reader["firstName"].ToString();
                customer.SecondName = reader["secondName"].ToString();
                customer.CustomerID = (int)reader["tblCustomer.CustomerID"];
                int reviewID = (int)reader["ReviewID"];
                int productNum = (int)reader["ProductID"];
                string title = reader["Title"].ToString();
                string text = reader["Message"].ToString();
                int stars = (int)reader["Rating"];
                int thumbsUp = (int)reader["ThumbsUp"];
                int thumbsDown = (int)reader["ThumbsDown"];

                //Create Review Object then Return to arrReviews.
                Review tempReview = new Review(reviewID, productNum, customer, title, text, stars, thumbsUp, thumbsDown);
                arrReviews.Add(tempReview);
            }//while
        }//try
        catch (Exception ex)
        {
            throw ex;
        }
        //Close Connection
        cn.Close();
        return arrReviews;
    }//ReviewsSpecficProduct


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// this method allows you to create a new invoice based on info stored in the database.
    /// </summary>
    /// <returns></returns>
    public static string createNewInvoice()
    {
        OleDbConnection conn = openConnection();

        //NEED SQL
        string strSQL = "";

        //create the command object using the SQL
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        cmd.ExecuteNonQuery(); // execute the insertion command

        //change the SQL to return the new invoice number
        cmd.CommandText = "Select @@Identity";

        string intInvoiceNum = cmd.ExecuteScalar().ToString();

        closeConection(conn); // close connection
        return intInvoiceNum; // return the invoice number

    }//createNewInvoice

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// this method allows for the insertion of a new product in the database.
    /// </summary>
    /// <param name="newProduct"></param>
    /// <returns></returns>
    public static int insertNewProduct(Product newProduct)
    {
        OleDbConnection conn = openConnection();

        //NEED SQL
        string strSQL = "INSERT INTO tblProducts (TypeID, ImageLocation, ProductName, Price, Discount, Stock, Description)"
            + "VALUES (" + newProduct.TypeID + ", " + "'" + newProduct.ImageLocation + "', '" + newProduct.ProductName + "', " + newProduct.Price + ", " + newProduct.Discount + ", " + newProduct.Stock + ", '" + newProduct.Description + "')";

        //create the command object using the SQL
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        //Execute non Query 
        int updated = cmd.ExecuteNonQuery();

        //close connection
        conn.Close();
        return updated;
    }//insertNewProduct

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// this method allows for the insertions of a new order into the database.
    /// </summary>
    /// <param name="customerID"></param>
    /// <param name="price"></param>
    /// <param name="deliveryCost"></param>
    /// <returns></returns>
    public static string insertOrder(int customerID, double price, double deliveryCost)
    {
        OleDbConnection conn = openConnection();

        //NEED SQL
        string strSQL = "INSERT INTO tblOrder (CustomerID, datePlaced, TotalPrice,DeliveryCost)"
            + "VALUES (" + customerID + ", " + "'" + DateTime.Now + "'" + ", " + price + ", " + deliveryCost + ")";

        //create the command object using the SQL
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        // execute the insertion command
        cmd.ExecuteNonQuery();

        //change the SQL to return the new invoice number
        cmd.CommandText = "Select @@Identity";

        string intOrderNum = cmd.ExecuteScalar().ToString();

        closeConection(conn);
        return intOrderNum;
    }//insertOrder

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method creates the functionality that allows a delivey cost to be requested for database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static double getOrderDel(int id)
    {
        OleDbConnection conn = openConnection();
        double del = 0;
        string strSQL = "SELECT DeliveryCost FROM tblOrder WHERE OrderID =" + id;

        //Command Object
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        //Gets each record matching SQL
        OleDbDataReader reader = cmd.ExecuteReader();

        // reading one record at a time
        while (reader.Read())
        {
            del = Convert.ToDouble(reader["DeliveryCost"]);
        }
        reader.Close();
        closeConection(conn);
        return del;
    }


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method allows for the insertions of orderlines in the database.
    /// </summary>
    /// <param name="orderID"></param>
    /// <param name="productID"></param>
    /// <param name="quantity"></param>
    public static void insertOrderline(int orderID, int productID, int quantity)
    {
        OleDbConnection conn = openConnection();

        string strSQL = "INSERT INTO tblOrderline (OrderID, ProductID, Quantity)"
            + "VALUES (" + orderID + ", " + productID + ", " + quantity + ")";

        //create the command object using the SQL
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);

        cmd.ExecuteNonQuery();
        closeConection(conn);
    }//insertOrderline

    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method allows for the updating of customer table in the database.
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public static int updateCustomer(Customer customer)
    {
        //connection 
        OleDbConnection cn = openConnection();

        //string
        string strSQL = "UPDATE tblCustomer SET firstName = '" + customer.FirstName + "', secondName = '" + customer.SecondName + "', address = '" + customer.Address + "', postCode = '" + customer.PostCode + "', country = '" + customer.Country + "', pwd = '" + customer.Pwd + "', securityQuestion = '" + customer.SecurityQuestion + "', SecurityAnswer = '" + customer.SecurityAnswer + "' WHERE CustomerID = " + customer.CustomerID;

        //command object
        OleDbCommand cmd = new OleDbCommand(strSQL, cn);
        cmd.CommandText = strSQL.ToString();

        //Execute non Query 
        int updated = cmd.ExecuteNonQuery();
        //close connection
        cn.Close();

        //return the new Customer
        return updated;
    }//updateCustomer


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// this method create the fuctionality to update the stock of vairous products within the database.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static int updateStockSingleProduct(string name, int amount)
    {
        OleDbConnection cn = openConnection();
        string strSQL = "SELECT Stock FROM tblProducts";
        OleDbCommand cmd = new OleDbCommand(strSQL, cn);

        int updated = 0;

        cmd.CommandText = "SELECT Stock FROM tblProducts WHERE ProductName = '" + name + "'";

        OleDbDataReader reader = cmd.ExecuteReader();
        reader.Read();
        int stock = Convert.ToInt32(reader["Stock"]);

        //substract the quantity ordered from the current stock level
        stock = stock + amount;

        reader.Close();

        cmd.CommandText = "UPDATE tblProducts SET Stock = " + stock + " WHERE ProductName = '" + name + "'";

        updated = cmd.ExecuteNonQuery();

        cn.Close();
        return updated;

    }//updateStockSingleProduct


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// this method allows for the updating stock when they are purchased by the user.
    /// </summary>
    /// <param name="parBasket"></param>
    /// <returns></returns>
    public static int updateStock(ArrayList parBasket)
    {
        OleDbConnection cn = openConnection();
        string strSQL = "SELECT Stock FROM tblProducts";
        OleDbCommand cmd = new OleDbCommand(strSQL, cn);

        int updated = 0;

        foreach (CartItem itemLine in parBasket)
        {
            //change SQL in command object to select only the required Product
            // MIGHT NEED FIXED
            cmd.CommandText = "SELECT Stock FROM tblProducts WHERE ProductID = " + itemLine.Product.ProductID;

            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            //access the InStock value in the selected record
            int stock = Convert.ToInt32(reader["Stock"]);

            //substract the quantity ordered from the current stock level
            stock = stock - itemLine.Quantity;

            reader.Close();

            //Perform update to stock value in tblProducts
            cmd.CommandText = "UPDATE tblProducts SET Stock =" + stock + "  WHERE ProductID = " + itemLine.Product.ProductID;

            //the number of records updated are returned as an integer 
            //(only 1 record should match Product ID)
            int recordsUpdated = cmd.ExecuteNonQuery();
            updated = updated + recordsUpdated;
        }//foreach

        cn.Close();
        return updated; //return number of product records updated
    }//updateStock


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// this method returns all the orders and orders them by descending orderID
    /// </summary>
    /// <returns></returns>
    public static DataSet displayAllOrders()
    {
        OleDbConnection conn = openConnection();
        DataSet dsOrders = new DataSet();
        string sqlString = "SELECT * FROM tblOrder ORDER BY OrderID DESC;";
        OleDbDataAdapter daOrders = new OleDbDataAdapter(sqlString, conn);
        daOrders.Fill(dsOrders, "grvAllOrdersValue");
        conn.Close();

        return dsOrders;
    }//displayAllOrders


    /// <summary>
    /// Author Michael Watters
    /// created 5/11/2018
    /// 
    /// This method allows for the updating of the upvote for a specfic review.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static int upVoteReview(int id)
    {
        OleDbConnection cn = openConnection();
        string strSQL = "SELECT ThumbsUp FROM tblReview";
        OleDbCommand cmd = new OleDbCommand(strSQL, cn);

        int updated = 0;

        cmd.CommandText = "SELECT ThumbsUp FROM tblReview WHERE ReviewID = " + id;

        OleDbDataReader reader = cmd.ExecuteReader();
        reader.Read();


        int current = (int)reader["ThumbsUp"];

        //increase thumbs up by 1
        current = current + 1;

        reader.Close();

        //Perform update to stock value in tblProducts
        cmd.CommandText = "UPDATE tblReview SET ThumbsUp = " + current + " WHERE ReviewID = " + id;

        //the number of records updated are returned as an integer 
        int recordsUpdated = cmd.ExecuteNonQuery();
        updated = updated + recordsUpdated;

        cn.Close();
        return updated; //return number of product records updated
    }//upVoteReview

    /// <summary>
    /// author Lukas Audzevicius
    /// created 4/1/2019
    /// 
    /// this method gets all the customers orders based on their customer ID.
    /// 
    /// </summary>
    /// <param name="CustID"></param>
    /// <returns></returns>
    public static DataSet getAllCustomerOrders(int CustID)
    {
        OleDbConnection conn = openConnection();
        DataSet dsOrders = new DataSet();
        string sqlString = "SELECT * FROM tblOrder WHERE CustomerID = " + CustID + " ORDER BY OrderID DESC";
        OleDbDataAdapter daOrders = new OleDbDataAdapter(sqlString, conn);
        daOrders.Fill(dsOrders, "dtOrders");

        conn.Close();
        return dsOrders;
    }//getAllOrders

    /// <summary>
    /// author Lukas Audzevicius, Michael Watters
    /// created 4/1/2019
    /// 
    /// This method gets all the orderlines to a specfic order.
    /// 
    /// </summary>
    /// <param name="OrderID"></param>
    /// <returns></returns>
    public static DataSet getOrderLines(int OrderID)
    {
        OleDbConnection conn = openConnection();
        DataSet dsOrderLines = new DataSet();
        string sqlString = "SELECT tblProducts.ProductName, tblOrderline.Quantity, tblProducts.Price, "
            + "tblProductType.TypeName, (tblProducts.Price * tblOrderline.Quantity) AS LineTotal "
            + "FROM tblProductType INNER JOIN (tblProducts INNER JOIN tblOrderline ON "
            + "tblProducts.ProductID = tblOrderline.ProductID) ON tblProductType.TypeID = tblProducts.TypeID "
            + "WHERE(((tblOrderline.OrderID) = " + OrderID + "))";
        OleDbDataAdapter daOrderLines = new OleDbDataAdapter(sqlString, conn);
        daOrderLines.Fill(dsOrderLines, "dtOrderlines");

        conn.Close();
        return dsOrderLines;
    }//getOrderLines

    /// <summary>
    /// author  Michael Watters
    /// created 4/1/2019
    /// this method allows the user to update a column in the tblProducts table
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnString(string value, string column, string productName)
    {
        //connection 
        OleDbConnection cn = openConnection();

        string strSQl = "UPDATE tblProducts SET " + column + " = '" + value + "' WHERE ProductName = '" + productName + "'";
       
        //command object
        OleDbCommand cmd = new OleDbCommand(strSQl, cn);
        cmd.CommandText = strSQl.ToString();

        //Execute non Query 
        int updated = cmd.ExecuteNonQuery();
        //close connection
        cn.Close();

        //return int 
        return updated;
    }//updateColumnString

    /// <summary>
    /// author Michael Watters
    /// created 4/1/2019
    /// this method allows the user to update a column in the table Products page.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnDouble(double value, string column, string productName)
    {
        //connection 
        OleDbConnection cn = openConnection();

        string strSQl = "UPDATE tblProducts SET " + column + " = " + value + " WHERE ProductName = '" + productName + "'";

        //command object
        OleDbCommand cmd = new OleDbCommand(strSQl, cn);
        cmd.CommandText = strSQl.ToString();

        //Execute non Query 
        int updated = cmd.ExecuteNonQuery();
        //close connection
        cn.Close();

        //return int 
        return updated;
    }//updateColumnDouble

    /// <summary>
    /// author Lukas Audzevicius, Michael Watters
    /// created 4/1/2019
    /// this method allows the user to update a colum in the tblproducts table.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnInt(int value, string column, string productName)
    {
        //connection 
        OleDbConnection cn = openConnection();

        string strSQl = "UPDATE tblProducts SET " + column + " = " + value + " WHERE ProductName = '" + productName + "'";

        //command object
        OleDbCommand cmd = new OleDbCommand(strSQl, cn);
        cmd.CommandText = strSQl.ToString();

        //Execute non Query 
        int updated = cmd.ExecuteNonQuery();
        //close connection
        cn.Close();

        //return int 
        return updated;
    }//updateColumnInt
}//class