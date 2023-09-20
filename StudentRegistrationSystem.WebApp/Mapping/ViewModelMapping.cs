using AutoMapper;
using StudentRegistrationSystem.WebApp.Models;
using StudentRegistrationSystem.WebApp.Models.AdminViewModel;
using StudentRegistrationSystem.WebApp.Models.StudentViewModel;
using System.Net.Http.Headers;

namespace StudentRegistrationSystem.WebApp.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping() {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Admin, AdminViewModel>().ReverseMap();



                }





    }
}
