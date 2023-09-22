namespace StudentRegistrationSystem.WebApp.ViewModels
{
    public class StudentListPartialViewModel
    {
public List<StudentPartialViewModel> Students { get; set; }




    }

        public class StudentPartialViewModel
        {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? Department { get; set; }




    }





}











