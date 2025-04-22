using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class StudentSubmit
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ExamModelId { get; set; }

        public DateTime? SubmitDate { get; set; }

        public virtual ExamModel ExamModel { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;

        public virtual ICollection<StudentSubmitAnswer> StudentSubmitAnswers { get; set; } = new HashSet<StudentSubmitAnswer>();


    }
}
