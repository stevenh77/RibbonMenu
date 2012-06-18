using System;
using System.Collections.Generic;
using System.Web;
using SilverlightExampleApp.Web.Models;

namespace SilverlightExampleApp.Web.Factories
{
    public class ClientFactory
    {
        private static List<Client> _clients = new List<Client>(20)
                                                   {
                                                       new Client
                                                           {
                                                               Id = 1,
                                                               Title = TitleFactory.Get(1),
                                                               FirstName = "Andy",
                                                               FamilyName = "Appleton",
                                                               DateOfBirth = new DateTime(1951, 01, 01),
                                                               Residence = CountryFactory.Get(1),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 2,
                                                               Title = TitleFactory.Get(2),
                                                               FirstName = "Ben",
                                                               FamilyName = "Birbeck",
                                                               DateOfBirth = new DateTime(1952, 02, 02),
                                                               Residence = CountryFactory.Get(2),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 3,
                                                               Title = TitleFactory.Get(3),
                                                               FirstName = "Calvin",
                                                               FamilyName = "Clayton",
                                                               DateOfBirth = new DateTime(1953, 03, 03),
                                                               Residence = CountryFactory.Get(3),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 4,
                                                               Title = TitleFactory.Get(4),
                                                               FirstName = "Derrick",
                                                               FamilyName = "Digby",
                                                               DateOfBirth = new DateTime(1954, 04, 04),
                                                               Residence = CountryFactory.Get(4),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 5,
                                                               Title = TitleFactory.Get(5),
                                                               FirstName = "Eddie",
                                                               FamilyName = "Edwards",
                                                               DateOfBirth = new DateTime(1955, 05, 05),
                                                               Residence = CountryFactory.Get(5),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 6,
                                                               Title = TitleFactory.Get(6),
                                                               FirstName = "Fred",
                                                               FamilyName = "Flint",
                                                               DateOfBirth = new DateTime(1956, 06, 06),
                                                               Residence = CountryFactory.Get(6),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 7,
                                                               Title = TitleFactory.Get(7),
                                                               FirstName = "Greg",
                                                               FamilyName = "Gaynor",
                                                               DateOfBirth = new DateTime(1957, 07, 07),
                                                               Residence = CountryFactory.Get(7),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 8,
                                                               Title = TitleFactory.Get(1),
                                                               FirstName = "Harry",
                                                               FamilyName = "Hillbilly",
                                                               DateOfBirth = new DateTime(1958, 08, 08),
                                                               Residence = CountryFactory.Get(1),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 9,
                                                               Title = TitleFactory.Get(2),
                                                               FirstName = "Ingrid",
                                                               FamilyName = "Inglebert",
                                                               DateOfBirth = new DateTime(1959, 9, 9),
                                                               Residence = CountryFactory.Get(2),
                                                               ActiveFlag = true
                                                           },
                                                       new Client
                                                           {
                                                               Id = 10,
                                                               Title = TitleFactory.Get(3),
                                                               FirstName = "Jacqui",
                                                               FamilyName = "Jackson",
                                                               DateOfBirth = new DateTime(1960, 10, 10),
                                                               Residence = CountryFactory.Get(3),
                                                               ActiveFlag = true
                                                           },
                                              new Client
                                                  {
                                                      Id = 11,
                                                      Title = TitleFactory.Get(1),
                                                      FirstName = "Kelly",
                                                      FamilyName = "Klackson",
                                                      DateOfBirth = new DateTime(1961, 01, 01),
                                                      Residence = CountryFactory.Get(4),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 12,
                                                      Title = TitleFactory.Get(2),
                                                      FirstName = "Leo",
                                                      FamilyName = "Lyons",
                                                      DateOfBirth = new DateTime(1952, 02, 02),
                                                      Residence = CountryFactory.Get(5),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 13,
                                                      Title = TitleFactory.Get(3),
                                                      FirstName = "Marcus",
                                                      FamilyName = "Matthews",
                                                      DateOfBirth = new DateTime(1953, 03, 03),
                                                      Residence = CountryFactory.Get(6),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 14,
                                                      Title = TitleFactory.Get(4),
                                                      FirstName = "Nigel",
                                                      FamilyName = "Newton",
                                                      DateOfBirth = new DateTime(1954, 04, 04),
                                                      Residence = CountryFactory.Get(7),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 15,
                                                      Title = TitleFactory.Get(5),
                                                      FirstName = "Otis",
                                                      FamilyName = "Otherson",
                                                      DateOfBirth = new DateTime(1955, 05, 05),
                                                      Residence = CountryFactory.Get(1),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 16,
                                                      Title = TitleFactory.Get(6),
                                                      FirstName = "Paul",
                                                      FamilyName = "Pickles",
                                                      DateOfBirth = new DateTime(1956, 06, 06),
                                                      Residence = CountryFactory.Get(2),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 17,
                                                      Title = TitleFactory.Get(7),
                                                      FirstName = "Richard",
                                                      FamilyName = "Rutherford",
                                                      DateOfBirth = new DateTime(1957, 07, 07),
                                                      Residence = CountryFactory.Get(3),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 18,
                                                      Title = TitleFactory.Get(1),
                                                      FirstName = "Steve",
                                                      FamilyName = "Saunders",
                                                      DateOfBirth = new DateTime(1958, 08, 08),
                                                      Residence = CountryFactory.Get(4),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 19,
                                                      Title = TitleFactory.Get(2),
                                                      FirstName = "Tommy",
                                                      FamilyName = "Tackle",
                                                      DateOfBirth = new DateTime(1959, 9, 9),
                                                      Residence = CountryFactory.Get(5),
                                                      ActiveFlag = true
                                                  },
                                              new Client
                                                  {
                                                      Id = 20,
                                                      Title = TitleFactory.Get(3),
                                                      FirstName = "Yohan",
                                                      FamilyName = "Yatz",
                                                      DateOfBirth = new DateTime(1960, 10, 10),
                                                      Residence = CountryFactory.Get(6),
                                                      ActiveFlag = true
                                                  }
                                            };

        public static List<Client> GetAll()
        {
            return _clients;
        }

        public static Client Get(int id)
        {
            return _clients.Find(c => id == c.Id);
        }
    }
}