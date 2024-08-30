using System.ComponentModel.DataAnnotations;

namespace MVCwithAdo.net.Models
{
    public class Student
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required] 
        public string city { get; set; }

    }
}
