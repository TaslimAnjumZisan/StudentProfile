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
        private readonly IStudentsService _studentsService;

        public StudentController(IStudentsService studentsService)
        {
            _studentsService = studentsService;

        }
        public async Task<IActionResult> Index()
        {
            var studentList = await _studentsService.GetAllStudentsAsync();


            return View(studentList);
        }

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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(StudentCreateNewModel obj)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = _mapper.Map<StudentCreateNewModel, Student>(obj);
        //            _db.Students.Add(model);
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

        //public IActionResult Edit(int? id)
        //{
        //    try
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }
        //        var getFromDb = _db.Students.Find(id);

        //        var model = _mapper.Map<Student, StudentEditModel>(getFromDb);
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
        //public IActionResult Edit(StudentEditNewModel obj)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = _mapper.Map<StudentEditNewModel, Student>(obj);
        //            _db.Students.Update(model);
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
