using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentProfile.Data;
using StudentProfile.Models;
using StudentProfile.service.serviceImplementation;
using StudentProfile.service.serviceInterface;
using StudentProfile.ViewModel;

namespace StudentProfile.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentsManager _studentsManager;

        public StudentController(IStudentsManager studentsManager)
        {
            _studentsManager = studentsManager;

        }
        public async Task<IActionResult> Index()
        {
            var studentList = await _studentsManager.GetAllStudentsAsync();
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new StudentCreateModel();
            model.DepartmentList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boolean result = await _studentsManager.CreateStudentAsync(obj);
                    if (result)
                    {
                        //ToDo Need to Incorporate Flash Message
                    }
                    return RedirectToAction("Index");
                }

                obj.DepartmentList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
            };

                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }







        public async Task< IActionResult> Edit(int id)
        {
            try
            {

                var model = await _studentsManager.GetStudentBy(id);
                model.DepartmentList = new List<SelectListItem>()
                    {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
                    };
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentEditModel obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Boolean result = await _studentsManager.UpdateStudent(obj);
                    if (result)
                    {
                        //ToDo Need to Incorporate Flash Message
                    }
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var model = await _studentsManager.GetStudentById(id);
                model.DepartmentList = new List<SelectListItem>()
                    {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
                    };
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentDeleteModel obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Boolean result = await _studentsManager.DeleteStudent(obj);
                    if (result)
                    {
                        //ToDo Need to Incorporate Flash Message
                    }
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        //public IActionResult Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }
        //        var getFromDb = _db.Students.Find(id);
        //        var model = _mapper.Map<Student, StudentDeleteModel>(getFromDb);
        //        model.DepartmentList = new List<SelectListItem>()
        //    {
        //        new SelectListItem(){Text="Select Department",Value=""},
        //        new SelectListItem(){Text="CSE",Value="CSE"},
        //        new SelectListItem(){Text="EEE",Value="EEE"},
        //        new SelectListItem(){Text="CIVIL",Value="CIVIL"},

        //    };

        //        if (model is null)
        //        {
        //            return NotFound();
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(StudentDeleteNewModel obj)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = _mapper.Map<StudentDeleteNewModel, Student>(obj);
        //            _db.Students.Remove(model);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(obj);
        //    }
        //    catch (Exception exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }
        //}
    }
}
