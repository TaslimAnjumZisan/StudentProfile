using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Data;
using StudentProfile.Models;
using StudentProfile.ViewModel;

namespace StudentProfile.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _db;
        private readonly IMapper _mapper;
        public StudentController(StudentDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Idx = _db.Students.ToList();
            var objCategoryList = _mapper.Map<List<Student>, List<StudentIndexModel>>(Idx);

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            var model = new StudentCreateModel();
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<StudentCreateModel, Student>(obj);
                    _db.Students.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var getFromDb = _db.Students.Find(id);
                var model = _mapper.Map<Student, StudentEditModel>(getFromDb);

                if (model is null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentEditModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<StudentEditModel, Student>(obj);
                    _db.Students.Update(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }


        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var getFromDb = _db.Students.Find(id);
                var model = _mapper.Map<Student, StudentDeleteModel>(getFromDb);

                if (model is null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentDeleteModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<StudentDeleteModel, Student>(obj);
                    _db.Students.Remove(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
