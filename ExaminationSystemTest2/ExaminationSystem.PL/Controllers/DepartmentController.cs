using ExaminationSystem.BLL.Interfaces;
using ExaminationSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepositories;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentRepositories repositories, ILogger<DepartmentController> logger)
        {
            _departmentRepositories = repositories;
            _logger = logger;
        }
        // BaseUrl/department/index
        public IActionResult Index()
        {
            var department = _departmentRepositories.GetAll();
            return View(department);
        }


        //we need add for create new department  with delete and viewdetails and update all CRUD OP 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                var count = _departmentRepositories.Add(department);
                if(count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
            
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {

            if(!id.HasValue) // id is null 
            {
                return BadRequest(); 
            }
            var department = _departmentRepositories.GetByID(id.Value);
            if(department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) // id is null 
            {
                return BadRequest();
            }
            var department = _departmentRepositories.GetByID(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if(id != department.ID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return View(department);
           
            try
            {
                _departmentRepositories.Update(department);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                // Log the error and handle exception
                //_logger.LogError(string.Empty,ex.Message);

                ModelState.AddModelError(string.Empty, "An error occurred while updating the department.");
              
                return View(department);

            }
        }

        [HttpGet]
        public IActionResult Delete(int ?id)
        {

            if (!id.HasValue)
                return BadRequest();

            var department = _departmentRepositories.GetByID(id.Value);
            if (department == null)
                return NotFound();

            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id,Department department)
        {
          
            try
            {
               
                _departmentRepositories.Delete(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                // Log the error and handle exception
                //_logger.LogError(string.Empty,ex.Message);

                ModelState.AddModelError(string.Empty, "An error occurred while Deleting the department.");

                return View(department);

            }
        }
    }
}
