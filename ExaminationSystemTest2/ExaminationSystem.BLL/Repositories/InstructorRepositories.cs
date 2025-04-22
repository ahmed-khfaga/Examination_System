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
    public class InstructorRepositories : IInstructorRepositories
    {
        private readonly ExaminitionSystemDbContext _dbcontext;

        public InstructorRepositories(ExaminitionSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int Add(Instructor instructor)
        {
            _dbcontext.Instructors.Add(instructor); // state added 
            return _dbcontext.SaveChanges();
        }

        public int Delete(Instructor instructor)
        {
            _dbcontext.Instructors.Remove(instructor); // state added 
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _dbcontext.Instructors.AsNoTracking().ToList();
        }

        public Instructor GetByID(int id)
        {
            var instructor = _dbcontext.Instructors.Find(id);
            return instructor;
        }

        public int Update(Instructor instructor)
        {
            _dbcontext.Instructors.Update(instructor); // update state to modified 
            return _dbcontext.SaveChanges();
        }
    }
}
