using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        public virtual ICollection<ExamModel> ExamModels { get; set; } = new HashSet<ExamModel>();

        public virtual ICollection<QuestionBank> QuestionBanks { get; set; } = new HashSet<QuestionBank>();


    }
}

