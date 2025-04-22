using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class StudentSubmitAnswer
    {
        public int StudentSubmitId { get; set; }

        public int ExamModelId { get; set; }

        public int QuestionId { get; set; }

        public string StudentAnswer { get; set; } = null!;

        public virtual ExamModelQuestion ExamModelQuestion { get; set; } = null!;

        public virtual StudentSubmit StudentSubmit { get; set; } = null!;
    }
}
