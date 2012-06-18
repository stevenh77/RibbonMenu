using System.ComponentModel.DataAnnotations;

namespace SilverlightExampleApp.Web.Models
{
    public class Title
    {
        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }
    }
}