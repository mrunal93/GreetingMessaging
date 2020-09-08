using System;
using System.ComponentModel.DataAnnotations;

namespace GreetingMessagingModelLayer
{
    public class GreetingEmployeeDetails
    {
        [Required]
        [Key]
        public int id { get; set; }
        
        [Required]
        [RegularExpression("^[A-Z][a-z]{3,}$")]
        public string First_Name { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]{3,}$")]
        public string Last_Name { get; set; }

        [Required]
        [RegularExpression("^([a-z0-9.+-]+)@([a-z0-9-]+).([a-z]{2,8})(.[a-z]{2,8})?$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public string Mobile_Number { get; set; }
    }
}
