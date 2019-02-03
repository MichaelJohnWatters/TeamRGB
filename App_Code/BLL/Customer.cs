using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// Create 7/11/2018
/// 
/// Represents a customers and their account.
/// 
/// </summary>
public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int LastViewedProduct { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
    public string Pwd { get; set; }
    public string SecurityQuestion { get; set; }
    public string SecurityAnswer { get; set; }

    //Empty constructor
    public Customer()
    {

    }

    //full constructor
    public Customer(int customerID, string firstName, string secondName, int lastViewedProduct, string address, string postCode, string country, string email, string pwd, string securityQuestion, string securityAnswer)
    {
        this.CustomerID = customerID;
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.LastViewedProduct = lastViewedProduct;
        this.Address = address;
        this.PostCode = postCode;
        this.Country = country;
        this.Email = email;
        this.Pwd = pwd;
        this.SecurityQuestion = securityQuestion;
        this.SecurityAnswer = securityAnswer;
    }
    /// <summary>
    /// 
    /// Controller Method
    /// This method check if the user exists in the Database and their input information is valid.
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public static Customer checkLogin(string email, string pwd)
    {
        return DataAccess.checkLogin(email, pwd);
    }//checkLogin

    /// <summary>
    /// Author Michael Watters
    /// Create 7/11/2018
    /// Controller Method.
    /// This Method allows the user to create an Account on the website.
    /// 
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public static Customer createAccount(Customer customer)
    {
        return DataAccess.createAccount(customer);
    }//createAccount

    /// <summary>
    /// Author Michael Watters
    /// Create 7/11/2018
    /// Controller Method.
    /// This Method allows the user to update their information.
    /// 
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public int updateCustomer(Customer customer)
    {
        return DataAccess.updateCustomer(customer);
    }//updateCustomer

    /// <summary>
    /// Author Michael Watters
    /// Create 7/11/2018
    /// This method is used to check if an email already exists in the database.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool checkEmailExists(string email) {
        return DataAccess.checkEmailExists(email);
    }//checkEmailExists
}//class