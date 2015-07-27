using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipLab1.Models
{
    //class to store customer information and be the basis of our customer database
    public class Customer
    {
        public string firstName { get; set; }   //First name of customer
        public string lastName { get; set; }    //last name of customer

        public AutoModel carPurchased;          //link to car that is purchased, if any.  
    }
}