using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid) // Check if model state is valid
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribe = viewModel.Subscribe
                };

                dbContext.Students.Add(student);
                await dbContext.SaveChangesAsync();

                // Redirect to a different action after successful save
                return RedirectToAction("Index", "Home"); // Modify the action and controller names as needed
            }

            // If ModelState is not valid, return to the same view with errors
            return View(viewModel);
        }
    }
}
