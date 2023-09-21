using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.WebApp.Models.AdminViewModel
{
    public class AdminViewModel
    {

        public int Id { get; set; }
        [Required]
        public string? AdminName { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*/d)(?=.*[@#$%^&+=!])(?=.{8,})", ErrorMessage = "Password must be eight characters including one uppercase letter,one special character and alphanumeric characters")]
        public string? AdminPassword { get; set; }


    }

    
}
