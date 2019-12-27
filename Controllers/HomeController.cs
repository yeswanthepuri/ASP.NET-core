using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployManagment.core.Models;
using EmployManagment.core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployManagment.core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository repo;
        private readonly IHostingEnvironment env;

        public HomeController(IEmployeeRepository repo, IHostingEnvironment env)
        {
            this.repo = repo;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View(repo.getEmployees());
        }
        public IActionResult Detail(Guid id)
        {
            var employ = repo.getEmployeebyID(id);
            if (employ.Employee == null)
            {
                Response.StatusCode = 404;
                return View("RecordNotFound");
            }
            return View(employ);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        private string SavePhoto(IFormFile photo)
        {
            string uniquefilename = null;
            if (photo != null)
            {
                string uploadFolder = Path.Combine(env.WebRootPath, "images");
                uniquefilename = string.Join("_", Guid.NewGuid().ToString(), photo.FileName);
                string filepath = Path.Combine(uploadFolder, uniquefilename);
                using (var file = new FileStream(filepath, FileMode.Create))
                {
                    photo.CopyTo(file);
                }
            }
            return uniquefilename;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uniquefilename = SavePhoto(model.Photo);
                Employee toCreateemployee = new Employee() { Department = model.Department, Email = model.Email, Fname = model.Fname, Lname = model.Lname, PhotoPath = uniquefilename };
                toCreateemployee = repo.AddEmployee(toCreateemployee);
                return RedirectToAction("Detail", new { id = toCreateemployee.ID });
            }
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(Guid id)
        {
            Employee emp = repo.getEmployeebyID(id).Employee;
            EmployeeEditViewModel empEdit = new EmployeeEditViewModel()
            {
                ID = emp.ID,
                Department = emp.Department,
                Fname = emp.Fname,
                Lname = emp.Lname,
                Email = emp.Email,
                ExistingPhotoPath = emp.PhotoPath
            };
            return View(empEdit);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniquefilename = null;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        var filetoDelete = Path.Combine(env.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filetoDelete);
                    }
                    uniquefilename = SavePhoto(model.Photo);
                }
                Employee empUpdate = new Employee()
                {
                    ID = model.ID,
                    Department = model.Department,
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Email = model.Email,
                    PhotoPath = uniquefilename ?? model.ExistingPhotoPath
                };
                repo.UpdateEmployee(empUpdate);
                return RedirectToAction("Detail", new { id = empUpdate.ID });
            }
            return View(model);
        }
    }
}