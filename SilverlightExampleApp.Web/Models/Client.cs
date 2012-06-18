using System;
using System.ComponentModel.DataAnnotations;

namespace SilverlightExampleApp.Web.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        
        public Title Title { get; set; }

        public string FirstName { get; set; }
        
        public string FamilyName { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public Country Residence { get; set; }

        public bool ActiveFlag { get; set; }
    }
}