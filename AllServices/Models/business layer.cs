using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AllServices.Models;
using System.Data.SqlClient;
namespace AllServices.Models
{
    public class business_layer
    {
        Datalayer dt=new Datalayer();
        public bool reg(AllDetails allDetails)
        {
            dt.regster(allDetails);
            return true;
        }
        public AllDetails GetallState()
        {

            DataTable dataTable = dt.Getstate("proc_getstate");
            List<AllDetails> States = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails states = new AllDetails();
                states.Id = Convert.ToInt32(row["State_ID"]);
                states.State = row["State"].ToString();
                States.Add(states);
            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = States;
            return obj;
        }
        public bool contactus(Contactus contactus) 
        {
          dt.Contact(contactus);
            return true;
        }
        public bool UploadServices(AllDetails allDetails)
        {
            dt.uploadservices(allDetails);
            return true;
        }

        public AllDetails getdistrictbystate(string state)
        {
            DataTable dataTable = dt.getDistrictByState(state);
            List<AllDetails> District = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails districtobj = new AllDetails();
                districtobj.Id = Convert.ToInt32(row["District_Id"].ToString());
                districtobj.District = row["District"].ToString();
                District.Add(districtobj);
            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = District;
            return obj;

        }
        public AllDetails getDistrictbyCity(string district)
        {
            DataTable dataTable = dt.getcitybyDistrict(district);
            List<AllDetails> City = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails cityobj = new AllDetails();
                cityobj.Id = Convert.ToInt32(row["cityid"].ToString());
                cityobj.City = row["cityname"].ToString();
                City.Add(cityobj);


            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = City;
            return obj;
        }

        internal static object GetPropertyType()
        {
            throw new NotImplementedException();
        }
    }
}