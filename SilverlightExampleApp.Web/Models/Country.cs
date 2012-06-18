using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SilverlightExampleApp.Web.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}