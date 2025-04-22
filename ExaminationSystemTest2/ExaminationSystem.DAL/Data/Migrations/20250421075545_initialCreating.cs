using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__3214EC275B31593B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__3214EC27F1174726", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    InstructorsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CoursesID, x.InstructorsID });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Instructors_InstructorsID",
                        column: x => x.InstructorsID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<TimeOnly>(type: "time", nullable: false),
                    startTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    endTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    instructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExamMode__3214EC27B24958E0", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ExamModel__Cours__6B24EA82",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__ExamModel__instr__6C190EBB",
                        column: x => x.instructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correctChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    insertionDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    instructorID = table.Column<int>(type: "int", nullable: false),
                    courseID = table.Column<int>(type: "int", nullable: false),
                    questionText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__3214EC27602A1141", x => x.ID);
                    table.ForeignKey(
                        name: "FK__QuestionB__cours__656C112C",
                        column: x => x.courseID,
                        principalTable: "Course",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__QuestionB__instr__6477ECF3",
                        column: x => x.instructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    departmentID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InstouctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__3214EC270133B1E4", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Instructors_InstouctorID",
                        column: x => x.InstouctorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Student__Department__5AEE82B9",
                        column: x => x.departmentID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExamModel_Question",
                columns: table => new
                {
                    examModelID = table.Column<int>(type: "int", nullable: false),
                    questionID = table.Column<int>(type: "int", nullable: false),
                    mark = table.Column<int>(type: "int", nullable: false),
                    correctChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExamMode__35117C44B0348E50", x => new { x.examModelID, x.questionID });
                    table.ForeignKey(
                        name: "FK__ExamModel__examM__02084FDA",
                        column: x => x.examModelID,
                        principalTable: "ExamModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__ExamModel__quest__02FC7413",
                        column: x => x.questionID,
                        principalTable: "QuestionBank",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBank_Choice",
                columns: table => new
                {
                    questionID = table.Column<int>(type: "int", nullable: false),
                    Choice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__90F6A66A39E34133", x => new { x.questionID, x.Choice });
                    table.ForeignKey(
                        name: "FK__QuestionB__quest__7F2BE32F",
                        column: x => x.questionID,
                        principalTable: "QuestionBank",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    StudentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesID, x.StudentsID });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubmit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    examModelID = table.Column<int>(type: "int", nullable: false),
                    submitDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__3214EC2765B8348D", x => x.ID);
                    table.ForeignKey(
                        name: "FK__StudentSu__examM__70DDC3D8",
                        column: x => x.examModelID,
                        principalTable: "ExamModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__StudentSu__stude__6FE99F9F",
                        column: x => x.studentID,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubmit_Answer",
                columns: table => new
                {
                    StudentSubmitID = table.Column<int>(type: "int", nullable: false),
                    studentAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    examModelID = table.Column<int>(type: "int", nullable: false),
                    questionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__660F8DE877CAD984", x => new { x.StudentSubmitID, x.studentAnswer });
                    table.ForeignKey(
                        name: "FK__StudentSu__Stude__06CD04F7",
                        column: x => x.StudentSubmitID,
                        principalTable: "StudentSubmit",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__StudentSubmit_An__07C12930",
                        columns: x => new { x.examModelID, x.questionID },
                        principalTable: "ExamModel_Question",
                        principalColumns: new[] { "examModelID", "questionID" });
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Course__737584F61367C110",
                table: "Course",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_InstructorsID",
                table: "CourseInstructor",
                column: "InstructorsID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsID",
                table: "CourseStudent",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__737584F653CD3C1A",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamModel_CourseID",
                table: "ExamModel",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamModel_instructorID",
                table: "ExamModel",
                column: "instructorID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamModel_Question_questionID",
                table: "ExamModel_Question",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_courseID",
                table: "QuestionBank",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_instructorID",
                table: "QuestionBank",
                column: "instructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_departmentID",
                table: "Student",
                column: "departmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_InstouctorID",
                table: "Student",
                column: "InstouctorID");

            migrationBuilder.CreateIndex(
                name: "UQ__Student__AB6E6164EA4F3A50",
                table: "Student",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Student__B43B145F789254A2",
                table: "Student",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmit_examModelID",
                table: "StudentSubmit",
                column: "examModelID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmit_studentID",
                table: "StudentSubmit",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmit_Answer_examModelID_questionID",
                table: "StudentSubmit_Answer",
                columns: new[] { "examModelID", "questionID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "QuestionBank_Choice");

            migrationBuilder.DropTable(
                name: "StudentSubmit_Answer");

            migrationBuilder.DropTable(
                name: "StudentSubmit");

            migrationBuilder.DropTable(
                name: "ExamModel_Question");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "ExamModel");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
