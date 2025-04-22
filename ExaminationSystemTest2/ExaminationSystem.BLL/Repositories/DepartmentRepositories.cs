using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.BLL.Interfaces;
using ExaminationSystem.DAL.Data;
using ExaminationSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.BLL.Repositories
{
    public class DepartmentRepositories : IDepartmentRepositories
    {
        public readonly ExaminitionSystemDbContext _dbcontext;

        public DepartmentRepositories(ExaminitionSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int Add(Department department)
        {
            _dbcontext.Departments.Add(department); // state added 
            return _dbcontext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _dbcontext.Departments.Remove(department); // state delete 
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbcontext.Departments.AsNoTracking().ToList();
        }

        public Department GetByID(int id)
        {
            var department = _dbcontext.Departments.Find(id);
            return department;
        }

        public int Update(Department department)
        {
            _dbcontext.Departments.Update(department); // update state to modified 
            return _dbcontext.SaveChanges();
        }
    }
}
