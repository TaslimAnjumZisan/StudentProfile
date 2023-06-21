using StudentProfile.Models;

namespace StudentProfile.manager.managerInterface
{
    public interface IStudentsManager
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
