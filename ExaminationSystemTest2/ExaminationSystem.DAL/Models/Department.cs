using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();


    }
}
