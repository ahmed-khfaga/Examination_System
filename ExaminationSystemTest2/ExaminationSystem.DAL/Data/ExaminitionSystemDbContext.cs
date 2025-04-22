using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.DAL.Data
{
    public class ExaminitionSystemDbContext : DbContext
    {
        public ExaminitionSystemDbContext(DbContextOptions<ExaminitionSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
   

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK__Course__3214EC275B31593B");

                entity.ToTable("Course");

                entity.HasIndex(e => e.Name, "UQ__Course__737584F61367C110").IsUnique();

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasMany(d => d.Instructors).WithMany(p => p.Courses);
                  
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK__Departme__3214EC27F1174726");

                entity.ToTable("Department");

                entity.HasIndex(e => e.Name, "UQ__Departme__737584F653CD3C1A").IsUnique();

                entity.Property(e => e.ID).HasColumnName("ID");
   
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ExamModel>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK__ExamMode__3214EC27B24958E0");

                entity.ToTable("ExamModel");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.CourseId).HasColumnName("CourseID");
                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.EndTime).HasColumnName("endTime");
                entity.Property(e => e.InstructorId).HasColumnName("instructorID");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.HasOne(d => d.Course).WithMany(p => p.ExamModels)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__ExamModel__Cours__6B24EA82");

                entity.HasOne(d => d.Instructor).WithMany(p => p.ExamModels)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__ExamModel__instr__6C190EBB");
            });
            modelBuilder.Entity<ExamModelQuestion>(entity =>
            {
                entity.HasKey(e => new { e.ExamModelId, e.QuestionId }).HasName("PK__ExamMode__35117C44B0348E50");

                entity.ToTable("ExamModel_Question");

                entity.Property(e => e.ExamModelId).HasColumnName("examModelID");
                entity.Property(e => e.QuestionId).HasColumnName("questionID");
                entity.Property(e => e.CorrectChoice)
                    .HasMaxLength(200)
                    .HasColumnName("correctChoice");
                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.ExamModel).WithMany(p => p.ExamModelQuestions)
                    .HasForeignKey(d => d.ExamModelId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__ExamModel__examM__02084FDA");

                entity.HasOne(d => d.Question).WithMany(p => p.ExamModelQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__ExamModel__quest__02FC7413");
            });

            modelBuilder.Entity<QuestionBank>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK__Question__3214EC27602A1141");

                entity.ToTable("QuestionBank");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.CorrectChoice)
                    .HasMaxLength(200)
                    .HasColumnName("correctChoice");
                entity.Property(e => e.CourseId).HasColumnName("courseID");
                entity.Property(e => e.InsertionDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("insertionDate");
                entity.Property(e => e.InstructorId).HasColumnName("instructorID");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(200)
                    .HasColumnName("questionText");
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Course).WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__QuestionB__cours__656C112C");

                entity.HasOne(d => d.Instructor).WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__QuestionB__instr__6477ECF3");
            });
            modelBuilder.Entity<QuestionBankChoice>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.Choice }).HasName("PK__Question__90F6A66A39E34133");

                entity.ToTable("QuestionBank_Choice");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");
                entity.Property(e => e.Choice).HasMaxLength(200);


                entity.HasOne(d => d.Question).WithMany(p => p.QuestionBankChoices)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__QuestionB__quest__7F2BE32F");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK__Student__3214EC270133B1E4");

                entity.ToTable("Student");

                entity.HasIndex(e => e.Email, "UQ__Student__AB6E6164EA4F3A50").IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Student__B43B145F789254A2").IsUnique();


                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");
                entity.Property(e => e.DepartmentID).HasColumnName("departmentID");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FName)
                    .HasMaxLength(20)
                    .HasColumnName("firstName");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.LName)
                    .HasMaxLength(20)
                    .HasColumnName("lastName");
                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Department)
               .WithMany(p => p.Students)  // Assuming 'Department' has a 'Students' collection
                .HasForeignKey(d => d.DepartmentID)  // Define the foreign key properly
                .OnDelete(DeleteBehavior.NoAction)  // Define the delete behavior
                .HasConstraintName("FK__Student__Department__5AEE82B9");  // Specify constraint name
            });

            modelBuilder.Entity<StudentSubmit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC2765B8348D");

                entity.ToTable("StudentSubmit");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ExamModelId).HasColumnName("examModelID");
               
                entity.Property(e => e.StudentId).HasColumnName("studentID");
                entity.Property(e => e.SubmitDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("submitDate");

                entity.HasOne(d => d.ExamModel).WithMany(p => p.StudentSubmits)
                    .HasForeignKey(d => d.ExamModelId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__StudentSu__examM__70DDC3D8");

                entity.HasOne(d => d.Student).WithMany(p => p.StudentSubmits)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__StudentSu__stude__6FE99F9F");
            });

            modelBuilder.Entity<StudentSubmitAnswer>(entity =>
            {
                entity.HasKey(e => new { e.StudentSubmitId, e.StudentAnswer }).HasName("PK__StudentS__660F8DE877CAD984");

                entity.ToTable("StudentSubmit_Answer");

                entity.Property(e => e.StudentSubmitId).HasColumnName("StudentSubmitID");
                entity.Property(e => e.StudentAnswer)
                    .HasMaxLength(200)
                    .HasColumnName("studentAnswer");
                entity.Property(e => e.ExamModelId).HasColumnName("examModelID");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.HasOne(d => d.StudentSubmit).WithMany(p => p.StudentSubmitAnswers)
                    .HasForeignKey(d => d.StudentSubmitId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__StudentSu__Stude__06CD04F7");

                entity.HasOne(d => d.ExamModelQuestion).WithMany(p => p.StudentSubmitAnswers)
                    .HasForeignKey(d => new { d.ExamModelId, d.QuestionId })
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__StudentSubmit_An__07C12930");
            });
        

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<ExamModel> ExamModels { get; set; }
        public virtual DbSet<ExamModelQuestion> ExamModelQuestions { get; set; }
        public virtual DbSet<QuestionBank> QuestionBanks { get; set; }
        public virtual DbSet<QuestionBankChoice> QuestionBankChoices { get; set; }
        public virtual DbSet<StudentSubmit> StudentSubmits { get; set; }
        public virtual DbSet<StudentSubmitAnswer> StudentSubmitAnswers { get; set; }

    }
}
