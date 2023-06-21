using StudentProfile.Models;
using StudentProfile.ViewModel;

namespace StudentProfile.service.serviceInterface
{
    public interface IStudentsService
    {
        Task<List<StudentIndexModel>> GetAllStudentsAsync();
    }
}
