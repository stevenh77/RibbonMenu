
using System.Collections.Generic;
using SilverlightExampleApp.Web.Models;

namespace SilverlightExampleApp.Web.Factories
{
    public class TitleFactory
    {
        private readonly static List<Title> _titles = new List<Title>(7)
                                        {
                                            new Title() {Id = 1, Description = "Mr"},
                                            new Title() {Id = 2, Description = "Miss"},
                                            new Title() {Id = 3, Description = "Mrs"},
                                            new Title() {Id = 4, Description = "Ms"},
                                            new Title() {Id = 5, Description = "Master"},
                                            new Title() {Id = 6, Description = "Sir"},
                                            new Title() {Id = 7, Description = "Dr"}
                                        };
        public static List<Title> GetAll()
        {
            return _titles;
        }

        public static Title Get(int id)
        {
            return _titles.Find(t => id == t.Id);
        }
    }
}