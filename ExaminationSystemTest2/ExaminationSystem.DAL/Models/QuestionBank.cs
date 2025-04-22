using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class QuestionBank
    {
        public int ID { get; set; }

        public string Type { get; set; } = null!;

        public string CorrectChoice { get; set; } = null!;

        public DateTime? InsertionDate { get; set; }

        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        public string QuestionText { get; set; } = null!;


        public virtual Instructor Instructor { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<ExamModelQuestion> ExamModelQuestions { get; set; } = new HashSet<ExamModelQuestion>();

        public virtual ICollection<QuestionBankChoice> QuestionBankChoices { get; set; } = new HashSet<QuestionBankChoice>();

    }
}
