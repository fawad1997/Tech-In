using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Data;

namespace Tech_In.Models.Database
{
    public static class DataInitilizer
    {
        
        public static void Initilize(ApplicationDbContext context)
            {
            context.Database.EnsureCreated();

           if (context.Country.Any())
            {
                return;   // DB has been seeded
            }
            if (context.City.Any())
            {
                return;   // DB has been seeded
            }
            var countries = new Country[]
                {
                    new Country {CountryId=1, CountryCode = "AF", CountryName = "Afghanistan", CountryPhoneCode = "+93" },
                    new Country {CountryId=2, CountryCode = "AU", CountryName = "Australia", CountryPhoneCode = "+78" },
                    new Country {CountryId=3, CountryCode = "AS", CountryName = "Austria", CountryPhoneCode = "+56" }
                }.ToList();
            foreach (Country c in countries)
            {
                context.Country.Add(c);
            }
            context.SaveChanges();

            var cities = new City[] {
                    new City { CityId = 11, CityName = "Kabul", CountryId = 1 },
                    new City { CityId = 12, CityName = "Herat", CountryId = 1 },
                    new City { CityId = 13, CityName = "Jallabad", CountryId = 1 },

                    new City { CityId = 14, CityName = "Sydney", CountryId = 2 },
                    new City { CityId = 15, CityName = "Melbourne", CountryId = 2 },
                    new City { CityId = 16, CityName = "Perth", CountryId = 2 },

                    new City { CityId = 17, CityName = "Vienna", CountryId = 3 },
                    new City { CityId = 18, CityName = "Salzburg", CountryId = 3 },
                    new City { CityId = 19, CityName = "Graz", CountryId = 3 },
                }.ToList();
            foreach (City ct in cities)
            {
                context.City.Add(ct);
            }
            context.SaveChanges();





        }
    }
    }
