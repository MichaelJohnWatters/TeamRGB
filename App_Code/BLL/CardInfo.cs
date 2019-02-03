using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Author Michael Watters
/// Create 7/11/2018
/// 
/// This Object class represents a credit card and the info that is assoiated.
/// </summary>
public class CardInfo
{
    public string CardNumber { get; set; }
    public string CardSecurity { get; set; }

    /// <summary>
    /// Author Michael Watters
    /// Create 7/11/2018
    /// 
    /// Constructor
    /// 
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <param name="cardSecurity"></param>
    public CardInfo(string cardNumber, string cardSecurity)
    {
        CardNumber = cardNumber;
        CardSecurity = cardSecurity;
    }//CardInfo
}//class