using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVCApp.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        StudentRepo stRepo = new StudentRepo(new LibraryContext());
        
        public async Task<IActionResult> Index()
        {
            List<Student> stdList = await stRepo.GetAll();
            return View(stdList);
        }
        [Route("AddStudent")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("AddStudentForm")]
        public IActionResult Create(Student student)
        {
            if(student != null)
            {
                bool isAdded = stRepo.Add(student);
                if(isAdded)
                    return RedirectToAction("Index");
            }
            return Content("Could'nt add book");
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            bool isRemoved = stRepo.Remove(id);
            if(isRemoved)
                return RedirectToAction("Index");
            return Content("Could'nt remove student");
        }

        [Route("EditStudent")]
        public async Task<IActionResult> EditStudent(int id)
        {
            Student student = await stRepo.GetById(id);
            return View(student);
        }

        [HttpPost]
        [Route("EditStudentForm")]
        public IActionResult Edit(Student student)
        {
            bool isUpdated = stRepo.Update(student.Id,student);
            if(isUpdated)
                return RedirectToAction("Index");
            return Content("Could'nt update student");
        }
    }
}