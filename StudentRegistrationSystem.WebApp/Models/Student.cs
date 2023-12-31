﻿namespace StudentRegistrationSystem.WebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public string? Surname { get; set; }
        public string? Class { get; set; }
        public string? Email { get; set; }
        public string? Department{ get; set; }
        public string? EducationTime { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfRegistration { get; set; }

        public Decimal? Dept { get; set; }
        public Decimal RemainingDept { get; set; }
    }
}
