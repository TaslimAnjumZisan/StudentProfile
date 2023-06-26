using StudentProfile.Models;
using StudentProfile.ViewModel;

namespace StudentProfile.service.serviceInterface
{
    public interface IStudentsManager
    {
        Task<List<StudentIndexModel>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(StudentCreateModel model);
        //Task<Boolean> EditStudentAsync(StudentEditModel model);
        Task<StudentEditModel> GetStudentBy(int id);
        Task<Boolean> UpdateStudent(StudentEditModel model);
    }
}
