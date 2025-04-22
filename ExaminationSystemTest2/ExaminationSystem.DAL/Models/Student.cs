using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string FName { get; set; } = null!;

        public string LName { get; set; } = null!;

        public string? Gender { get; set; }
        
        public int DepartmentID { get; set; }
       
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual Instructor Instouctor { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        public virtual ICollection<StudentSubmit> StudentSubmits { get; set; } = new HashSet<StudentSubmit>();


    }
}
