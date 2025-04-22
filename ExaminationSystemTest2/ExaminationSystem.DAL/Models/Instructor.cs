using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string? Gender { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;

        
        public virtual Department Department { get; set; } = null!;

        public virtual ICollection<ExamModel> ExamModels { get; set; } = new HashSet<ExamModel>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        public virtual ICollection<QuestionBank> QuestionBanks { get; set; } = new HashSet<QuestionBank>();

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
