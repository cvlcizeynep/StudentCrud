using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.WebApp.Models.StudentViewModel
{
    public class StudentUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name field must be between 3 and 50 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Surname required")]
        public string? Surname { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Please enter numbers between 1 and 10")]
        public string? Class { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email adress")]
        public string? Email { get; set; }
        [Required]
        public string? Department { get; set; }

        public string? EducationTime { get; set; }
        [StringLength(300, MinimumLength = 20, ErrorMessage = "The Description field must be between 20 and 300 characters.")]
        [Required]

        public string? Description { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d\d)?", ErrorMessage = "Enter at least two characters after the dot in price field")]
        public Decimal? Dept { get; set; }
        public Decimal RemainingDept { get; set; }
    }


}

