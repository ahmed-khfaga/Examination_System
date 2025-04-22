using ExaminationSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepositories;

        public DepartmentController(IDepartmentRepositories repositories)
        {
            _departmentRepositories = repositories; 
        }
        public IActionResult Index()
        {
            var department = _departmentRepositories.GetAll();
            return View(department);
        }
    }
}
