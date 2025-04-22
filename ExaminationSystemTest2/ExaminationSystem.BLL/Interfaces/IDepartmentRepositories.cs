using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.DAL.Models;

namespace ExaminationSystem.BLL.Interfaces
{
    public interface IDepartmentRepositories
    {
        IEnumerable<Department> GetAll();
        Department GetByID(int id);
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);
    }
}
