using AutoMapper;
using StudentProfile.manager.managerInterface;
using StudentProfile.Models;
using StudentProfile.service.serviceInterface;
using StudentProfile.ViewModel;

namespace StudentProfile.service.serviceImplementation
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsManager _studentsManager;
        private readonly IMapper _mapper;

        public StudentsService(IStudentsManager studentsManager, IMapper mapper)
        {
            _studentsManager = studentsManager;
            _mapper = mapper;
        }
        public  async Task< List<StudentIndexModel>> GetAllStudentsAsync()
        {
            var existListofStudent = await _studentsManager.GetAllStudentsAsync();
            var studenList = _mapper.Map<List<Student>, List<StudentIndexModel>>(existListofStudent);
            return studenList;

        }
    }
}
