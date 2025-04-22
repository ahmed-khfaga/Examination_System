using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class ExamModel
    {
        public int ID { get; set; }

        public TimeOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public DateTime? CreationDate { get; set; }

        public int InstructorId { get; set; }

        public int CourseId { get; set; }


        public virtual Course Course { get; set; } = null!;

        public virtual Instructor Instructor { get; set; } = null!;

        public virtual ICollection<ExamModelQuestion> ExamModelQuestions { get; set; } = new List<ExamModelQuestion>();

        public virtual ICollection<StudentSubmit> StudentSubmits { get; set; } = new List<StudentSubmit>();

    }
}
