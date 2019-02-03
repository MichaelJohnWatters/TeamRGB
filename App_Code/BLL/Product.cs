using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters, Lukas Audi
/// create 5/11/2018
/// This class repreants a individual product within the website.
/// Summary description for Product
/// </summary>
public class Product
{
    /*Public Properties*/
    public int ProductID { get; set; }
    public int TypeID { get; set; }
    //created from join
    public string ImageLocation { get; set; }
    public string TypeName { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }

    /*Empty Constructor*/
    public Product()
    {

    }//empty Constructor

    /*Full Constructor*/
    public Product(int productID, int typeID, string imageLocation, string typeName, String productName, double price, double discount, int stock, String description)
    {
        this.ProductID = productID;
        this.TypeID = typeID;
        this.ImageLocation = imageLocation;
        this.TypeName = typeName;
        this.ProductName = productName;
        this.Price = price;
        this.Discount = discount;
        this.Stock = stock;
        this.Description = description;
    }//constructors

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This Method Creates and populates a product object instance to be used in other method.
    /// </summary>
    /// <param name="productID"></param>
    public void loadProduct(string productID)
    {
        Product tempProduct = DataAccess.getProduct(productID);

        ProductID = tempProduct.ProductID;
        ProductName = tempProduct.ProductName;
        TypeName = tempProduct.TypeName;
        Description = tempProduct.Description;
        ImageLocation = tempProduct.ImageLocation;
        Price = tempProduct.Price;
        Stock = tempProduct.Stock;
    }//loadProduct

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// This Method returns all products for the shop.
    /// </summary>
    /// <returns></returns>
    public static DataSet getProducts()
    {
        return DataAccess.getProductsForShop();
    }//getProducts

    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// This method returns all the PC related products for the shop
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsPC()
    {
        return DataAccess.getProductsForShopPC();
    }//getProductsPC

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This method returns all the playstation related products for the shop
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsPS()
    {
        return DataAccess.getProductsForShopPS();
    }//getProductsPS

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This method returns all the Xbox related products for the shop.
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsXBOX()
    {
        return DataAccess.getProductsForShopXBOX();
    }//getProductsXBOX

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This method returns all the game related products for the shop.
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsGAMES()
    {
        return DataAccess.getProductsForShopGAMES();
    }//getProductsGAMES

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This method returns all the products that match the filter text for the shop.
    /// </summary>
    /// <param name="filterText"></param>
    /// <returns></returns>
    public static DataSet searchShopFilter(string filterText)
    {
        return DataAccess.searchShopFilter(filterText);
    }//searchShopFilter

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This Method is used to update all the stock items in database when purcahsed.
    /// </summary>
    /// <param name="parBasket"></param>
    /// <returns></returns>
    public static int updateStock(ArrayList parBasket) {
        return DataAccess.updateStock(parBasket);
    }//updateStock

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This method creates an arraylist used to populate controls within the manager page.
    /// </summary>
    /// <returns></returns>
    public static ArrayList getProductsForManager() {
        return DataAccess.getProductsForManager();
    }//getProductsForManager

    /// <summary>
    /// Author Michael Watters, Lukas Audi
    /// create 5/11/2018
    /// This Method allows the manager to update the stock of product in the database.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static int updateStockSingleProduct(string name, int amount) {
        return DataAccess.updateStockSingleProduct(name, amount);
    }//updateStockSingleProduct


    /// <summary>
    /// Author Michael Watters
    /// create 5/11/2018
    /// This method allows the manager to add new products too the database for purchase
    /// </summary>
    /// <param name="newProduct"></param>
    /// <returns></returns>
    public static int addNewProduct(Product newProduct) {
        return DataAccess.insertNewProduct(newProduct);
    }//addNewProduct

    /// <summary>
    /// Author Michael Watter
    /// create 5/11/2018
    /// Method allows the manager page to populate a dataset with all the products in the database.
    /// </summary>
    /// <returns></returns>
    public static DataSet getProductsForManagerDataSet()
    {
        return DataAccess.getProductsForManagerDataSet();
    }//getProductsForManagerDataSet

    /// <summary>
    /// Update Column within the database.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnString(string value,string column, string productName) {
        return DataAccess.updateColumnString(value, column, productName);
    }//updateColumnString

    /// <summary>
    /// Author Michael Watters, Lukas Audi, Jude Maguire
    /// create 5/11/2018
    /// Update Column within the database.
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnDouble(double value, string column, string productName) {
        return DataAccess.updateColumnDouble(value, column, productName);
    }//updateColumnDouble

    /// <summary>
    /// Update Column within the database.
    /// Author Michael Watters, Lukas Audi, Jude Maguire
    /// create 5/11/2018
    /// </summary>
    /// <param name="value"></param>
    /// <param name="column"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public static int updateColumnInt(int value, string column, string productName)
    {
        return DataAccess.updateColumnInt(value, column, productName);
    }//updateColumnInt
}//class