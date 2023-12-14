using AllServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;


namespace AllServices.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=pc2;Initial Catalog=Allservice;Integrated Security=True");

        business_layer business_Layer = new business_layer();
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(AllDetails allDetails)
        {
            business_Layer.reg(allDetails);
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contactus contactus)
        {
            business_Layer.contactus(contactus);
            return View();
            

        }
        public ActionResult opne()
        {
            return View();
        }
        public ActionResult Allservices()
        {
            return View();
        }
        [HttpGet]
       public ActionResult UploadServices()
        {
            ViewBag.uploadservices=business_Layer.GetallState();


            return View();
        }


        public ActionResult getdistrictbystate(string state)
        {
            AllDetails district = business_Layer.getdistrictbystate(state);
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCitybyDistrict(string district)
        {
            AllDetails city = business_Layer.getDistrictbyCity(district);
            return Json(city, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadServices(AllDetails ad)
        {



           
            business_Layer.UploadServices(ad);
           return View();
        }
    }
}