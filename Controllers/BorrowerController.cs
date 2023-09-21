using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVCApp.Controllers
{
    [Route("[controller]")]
    public class BorrowerController : Controller
    {
        BorrowerRepo boRepo = new BorrowerRepo(new LibraryContext());
        
        public async Task<IActionResult> Index()
        {
            List<Borrower> boList = await boRepo.GetAll();
            StringBuilder sbBooks = new StringBuilder();
            return View(boList);
        }
        [Route("AddBorrower")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("AddBorrowerForm")]
        public IActionResult Create(Borrower borrower)
        {
            if(borrower != null)
            {
                bool isAdded = boRepo.Add(borrower);
                if(isAdded)
                    return RedirectToAction("Index");
            }
            return Content("Could'nt add Borrower");
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            bool isRemoved = boRepo.Remove(id);
            if(isRemoved)
                return RedirectToAction("Index");
            return Content("Could'nt remove Borrower");
        }

        [Route("EditBorrower")]
        public async Task<IActionResult> EditBorrower(int id)
        {
            Borrower borrower = await boRepo.GetById(id);
            return View(borrower);
        }

        [HttpPost]
        [Route("EditBorrowerForm")]
        public IActionResult Edit(Borrower borrower)
        {
            bool isUpdated = boRepo.Update(borrower.Id,borrower);
            if(isUpdated)
                return RedirectToAction("Index");
            return Content("Could'nt update Borrower");
        }
    }
}