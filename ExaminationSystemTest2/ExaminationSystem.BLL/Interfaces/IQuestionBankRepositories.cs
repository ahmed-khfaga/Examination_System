using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.DAL.Models;

namespace ExaminationSystem.BLL.Interfaces
{
    public interface IQuestionBankRepositories
    {
        IEnumerable<QuestionBank> GetAll();
        QuestionBank GetByID(int id);
        int Add(QuestionBank questionBank);
        int Update(QuestionBank questionBank);
        int Delete(QuestionBank questionBank);
    }
}
