using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentProfile.Data;
using StudentProfile.manager.managerInterface;
using StudentProfile.Models;
using StudentProfile.ViewModel;
using System.Threading;

namespace StudentProfile.manager.managerImplementation
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentsRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new List<Student>();
            students = await _studentDbContext.Students.ToListAsync();
            return students;
        }

        public async Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default)
        {
            Boolean isCreate = false;
            int count = 0;
            var exists = await _studentDbContext.Students.AnyAsync(x => x.Email.Trim().ToLower() == model.Email.Trim().ToLower());

            if (cancellationToken.IsCancellationRequested==false)
            {
                if (!exists)
                {
                    await _studentDbContext.Students.AddAsync(model);
                    count= await _studentDbContext.SaveChangesAsync();
                    isCreate = true;
                }
            }
            return isCreate;
        }

        public async Task<Student> GetStudentBy(int id)
        {
          var student= await _studentDbContext.Students.FindAsync( id);
           
            return student;
        }

        public async Task<Boolean>  UpdateStudent(Student model, CancellationToken cancellationToken = default)
        {
            Boolean isUpdate = false;
            int count = 0;
            var exists = await _studentDbContext.Students.AnyAsync(x => x.Email.Trim().ToLower() == model.Email.Trim().ToLower()&& x.Id!=model.Id);

            if (cancellationToken.IsCancellationRequested == false)
            {
                if (!exists)
                {
                     _studentDbContext.Students.Update(model);
                    count = await _studentDbContext.SaveChangesAsync();
                    isUpdate = true;
                }
            }
            return isUpdate;

        }

    }
}
