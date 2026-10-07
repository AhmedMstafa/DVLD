using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess;

namespace Business
{
    public class CountryBusiness
    {
        public int CountryID { get; set; }
        public String CountryName { get; set; }


        public CountryBusiness(int CountryID,string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static CountryBusiness Find(int CountryID )
        {
           
            if(CountryData.GetCountryNameByID( CountryID,out string CountryName ) )
            {
                return new CountryBusiness(CountryID, CountryName);
            }else
            {
                return null;
            }
        }

        public static CountryBusiness Find(string CountryName)
        {
            if(CountryData.GetCountryIDByName( CountryName,out int CountryID) )
            {
                return new CountryBusiness(CountryID,CountryName);
            }else
            {
                return null;
            }
        }
        public static DataTable GetAllCountries ()
        {
            return CountryData.GetAllCountries();
        }
    }
}
