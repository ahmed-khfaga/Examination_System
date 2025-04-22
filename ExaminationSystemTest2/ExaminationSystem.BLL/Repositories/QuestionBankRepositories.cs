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
    public class QuestionBankRepositories : IQuestionBankRepositories
    {
        private readonly ExaminitionSystemDbContext _dbcontext;
        public QuestionBankRepositories(ExaminitionSystemDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public int Add(QuestionBank questionBank)
        {
            _dbcontext.QuestionBanks.Add(questionBank); // state added 
            return _dbcontext.SaveChanges();
        }

        public int Delete(QuestionBank questionBank)
        {
            _dbcontext.QuestionBanks.Remove(questionBank); // state added 
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<QuestionBank> GetAll()
        {
            return _dbcontext.QuestionBanks.AsNoTracking().ToList();
        }

        public QuestionBank GetByID(int id)
        {
            var questionBank = _dbcontext.QuestionBanks.Find(id);
            return questionBank;
        }

        public int Update(QuestionBank questionBank)
        {
            _dbcontext.QuestionBanks.Update(questionBank); // state added 
            return _dbcontext.SaveChanges();
        }
    }
}
