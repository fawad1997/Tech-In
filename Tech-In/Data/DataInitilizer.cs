using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Data;

namespace Tech_In.Models.Database
{
    public class DataInitilizer
    {
        private City _context;

        public DataInitilizer(City context)
        {
            _context = context;
            using (var initObject = new ApplicationDbContext())
            {
                //Country Andorra = new Country[]
                //{
                //    new Country{CountryID = 1, CountryCode = "AN", CountryName = "Andorra", CountryPhoneCode = "+376" },
                //    new Country{CountryID=2, CountryCode="AE",CountryName="United Arab Emirates",CountryPhoneCode="+971"},
                //    new Country{CountryID=3, CountryCode="AF", CountryName="Afghanistan", CountryPhoneCode="+93"},
                //    new Country{CountryID=4, CountryCode="BH", CountryName="Bahrain", CountryPhoneCode="+973"},
                //    new Country{CountryID=5, CountryCode="BE", CountryName="Belgium", CountryPhoneCode="+975"},
                //    new Country{CountryID=6, CountryCode="BE", CountryName="Belgium", CountryPhoneCode="+32"},
                //    new Country{CountryID=6, CountryCode="BE", CountryName="Belgium", CountryPhoneCode="+32"},
                    
                //};
                //City city = new City()
                //{
                //    CityID = 1,
                //    CityName = "Islamabad",
                //    Country = Andorra,
                //    CountryID = 1
                //};
                
                //initObject.City.Add(city);
                //initObject.Country.Add(Andorra);
                //initObject.SaveChanges();
                
            }
        }


    }
 }