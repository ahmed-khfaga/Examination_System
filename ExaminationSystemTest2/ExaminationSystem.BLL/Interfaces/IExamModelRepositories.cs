using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.DAL.Models;

namespace ExaminationSystem.BLL.Interfaces
{
    public interface IExamModelRepositories
    {
        IEnumerable<ExamModel> GetAll();
        ExamModel GetByID(int id);
        int Add(ExamModel examModel);
        int Update(ExamModel examModel);
        int Delete(ExamModel examModel);
    }
}
