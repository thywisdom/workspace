using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCorePractice.Migrations
{
    /// <inheritdoc />
    public partial class FixManyToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Courses_CoursesCourseId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Subjects_SubjectsSubjectId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSubject",
                table: "CourseSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "SubjectTeacher",
                newName: "TeacherSubjects");

            migrationBuilder.RenameTable(
                name: "CourseSubject",
                newName: "CourseSubjects");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeachersTeacherId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_TeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSubject_SubjectsSubjectId",
                table: "CourseSubjects",
                newName: "IX_CourseSubjects_SubjectsSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsStudentId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentsStudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects",
                columns: new[] { "SubjectsSubjectId", "TeachersTeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSubjects",
                table: "CourseSubjects",
                columns: new[] { "CoursesCourseId", "SubjectsSubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "CoursesCourseId", "StudentsStudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Courses_CoursesCourseId",
                table: "CourseSubjects",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Subjects_SubjectsSubjectId",
                table: "CourseSubjects",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CoursesCourseId",
                table: "StudentCourses",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentsStudentId",
                table: "StudentCourses",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectsSubjectId",
                table: "TeacherSubjects",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeachersTeacherId",
                table: "TeacherSubjects",
                column: "TeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Courses_CoursesCourseId",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Subjects_SubjectsSubjectId",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CoursesCourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentsStudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectsSubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeachersTeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSubjects",
                table: "CourseSubjects");

            migrationBuilder.RenameTable(
                name: "TeacherSubjects",
                newName: "SubjectTeacher");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "CourseSubjects",
                newName: "CourseSubject");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_TeachersTeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentsStudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSubjects_SubjectsSubjectId",
                table: "CourseSubject",
                newName: "IX_CourseSubject_SubjectsSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectsSubjectId", "TeachersTeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "CoursesCourseId", "StudentsStudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSubject",
                table: "CourseSubject",
                columns: new[] { "CoursesCourseId", "SubjectsSubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourseId",
                table: "CourseStudent",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Courses_CoursesCourseId",
                table: "CourseSubject",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Subjects_SubjectsSubjectId",
                table: "CourseSubject",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                table: "SubjectTeacher",
                column: "TeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Branches_BranchId",
                table: "Teachers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
