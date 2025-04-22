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
    public class ExamModelRepositories : IExamModelRepositories
    {
        private readonly ExaminitionSystemDbContext _dbcontext;

        public ExamModelRepositories(ExaminitionSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int Add(ExamModel examModel)
        {
            _dbcontext.ExamModels.Add(examModel); // state added 
            return _dbcontext.SaveChanges();

        }

        public int Delete(ExamModel examModel)
        {
            _dbcontext.ExamModels.Remove(examModel); // state added 
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<ExamModel> GetAll()
        {
            return _dbcontext.ExamModels.AsNoTracking().ToList();
        }

        public ExamModel GetByID(int id)
        {
            var examModel = _dbcontext.ExamModels.Find(id);
            return examModel;
        }

        public int Update(ExamModel examModel)
        {
            _dbcontext.ExamModels.Update(examModel); // state added 
            return _dbcontext.SaveChanges();
        }
    }
}
