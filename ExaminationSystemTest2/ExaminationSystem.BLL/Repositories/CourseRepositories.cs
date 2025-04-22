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
    public class CourseRepositories : ICourseRepositories
    {
        private readonly ExaminitionSystemDbContext _dbcontext;

        public CourseRepositories(ExaminitionSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int Add(Course course)
        {
            _dbcontext.Courses.Add(course); // state added 
            return _dbcontext.SaveChanges();
        }

        public int Delete(Course course)
        {
            _dbcontext.Courses.Remove(course); // state added 
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbcontext.Courses.AsNoTracking().ToList();
        }

        public Course GetByID(int id)
        {
            var courses = _dbcontext.Courses.Find(id);
            return courses;
        }

        public int Update(Course course)
        {
            _dbcontext.Courses.Update(course); // state added 
            return _dbcontext.SaveChanges();
        }
    }
}
