using AutoMapper;
using StudentProfile.manager.managerInterface;
using StudentProfile.Models;
using StudentProfile.service.serviceInterface;
using StudentProfile.ViewModel;

namespace StudentProfile.service.serviceImplementation
{                                
    public class StudentsManager : IStudentsManager
    {                   
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;
                               
        public StudentsManager(IStudentsRepository studentsRepository, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
        }
        public  async Task< List<StudentIndexModel>> GetAllStudentsAsync()
        {
            var existListOfStudent = await _studentsRepository.GetAllStudentsAsync();
            var studentList = _mapper.Map<List<Student>, List<StudentIndexModel>>(existListOfStudent);
            return studentList;

        }

        public async Task<Boolean> CreateStudentAsync(StudentCreateModel model)
        {
            var student = _mapper.Map<StudentCreateModel,Student>(model);
            Boolean result = await _studentsRepository.CreateStudentAsync(student);
            return result;

        }

        public async Task<StudentEditModel> GetStudentBy(int id)
        {
            var studentDb= await _studentsRepository.GetStudentBy(id);
            var student = _mapper.Map< Student, StudentEditModel>(studentDb);
            return student;
        }

        public async Task<Boolean> UpdateStudent(StudentEditModel model)
        {
            //var studentDb = await _studentsRepository.
            var student = _mapper.Map<StudentEditModel,Student>(model);
            Boolean result = await _studentsRepository.UpdateStudent(student);
            return result;
        }


    }
}
