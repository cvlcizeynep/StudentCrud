using AutoMapper;
using StudentRegistrationSystem.WebApp.Models;
using StudentRegistrationSystem.WebApp.ViewModels;
using System.Net.Http.Headers;

namespace StudentRegistrationSystem.WebApp.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping() {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Admin, AdminViewModel>().ReverseMap();
            CreateMap<Student,StudentUpdateViewModel>().ReverseMap();



                }





    }
}
