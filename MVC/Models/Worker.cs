using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models
{
    public class Worker
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public string Father_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
    }
}
