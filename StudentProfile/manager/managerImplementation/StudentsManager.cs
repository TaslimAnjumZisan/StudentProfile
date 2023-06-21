using Microsoft.EntityFrameworkCore;
using StudentProfile.Data;
using StudentProfile.manager.managerInterface;
using StudentProfile.Models;

namespace StudentProfile.manager.managerImplementation
{
    public class StudentsManager : IStudentsManager
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentsManager(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var listOfStudent =  _studentDbContext.Students.ToList();
            if (listOfStudent is not null)
            {
                return listOfStudent;
            }
            return null;
        }
    }
}
