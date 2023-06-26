using StudentProfile.Models;

namespace StudentProfile.manager.managerInterface
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default);
        //Task<Boolean> EditStudentAsync(int id);
        Task<Student>GetStudentBy(int id);
        Task<Boolean> UpdateStudent(Student model, CancellationToken cancellationToken = default);

    }
}
