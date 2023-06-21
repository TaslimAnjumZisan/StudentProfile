using AutoMapper;
using StudentProfile.Models;
using StudentProfile.ViewModel;

namespace StudentProfile.Map
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentIndexModel>().ReverseMap();
            CreateMap<Student, StudentCreateModel>().ReverseMap();
            CreateMap<Student, StudentEditModel>().ReverseMap();
            CreateMap<Student, StudentDeleteModel>().ReverseMap();
            CreateMap<Student, StudentCreateNewModel>().ReverseMap();

            CreateMap<Student, StudentEditNewModel>().ReverseMap();
            CreateMap<Student, StudentDeleteNewModel>().ReverseMap();


        }
    }
}
