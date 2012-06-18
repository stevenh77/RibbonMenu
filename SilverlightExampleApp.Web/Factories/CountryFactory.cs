
using System.Collections.Generic;
using SilverlightExampleApp.Web.Models;

namespace SilverlightExampleApp.Web.Factories
{
    public class CountryFactory
    {
        private readonly static List<Country> _countries = new List<Country>(7)
            {
                new Country() {Id = 1, Description = "England"},
                new Country() {Id = 2, Description = "France"},
                new Country() {Id = 3, Description = "Germany"},
                new Country() {Id = 4, Description = "Italy"},
                new Country() {Id = 5, Description = "Scotland"},
                new Country() {Id = 6, Description = "Spain"},
                new Country() {Id = 7, Description = "Wales"}
            };

        public static List<Country> GetAll()
        {
            return _countries;
        }

        public static Country Get(int id)
        {
            return _countries.Find(t => id == t.Id);
        }
    }
}