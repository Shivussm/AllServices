using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AllServices.Models
{
    public class AllDetails
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id {  get; set; }
        public string Mobile {  get; set; }
        public string Password {  get; set; }
        public string Re_Password { get; set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Services { get; set; }
        public string DateTime { get; set; }
        public bool IsActive { get; set; }
        public List<AllDetails> Binddisplay { get; set; }
    }
}

