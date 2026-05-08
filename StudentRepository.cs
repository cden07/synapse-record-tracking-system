using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace synapse_record_tracking_system
{
    public static class StudentRepository
    {
        public static BindingList<Student> Students = new BindingList<Student>();

        public static void AddStudent(Student s) => Students.Add(s);

        public static Student GetStudentById(int id) =>
            Students.FirstOrDefault(s => s.StudentID == id);

        public static void UpdateStudent(Student updated)
        {
            var student = GetStudentById(updated.StudentID);
            if (student != null)
            {
                student.StudentID = updated.StudentID;
                student.Password = updated.Password;
                student.FirstName = updated.FirstName;
                student.LastName = updated.LastName;
                student.YearLevel = updated.YearLevel;
                student.Birthday = updated.Birthday;
                student.Block = updated.Block;
                student.ContactNumber = updated.ContactNumber;
                student.ProgramCourse = updated.ProgramCourse;
            }
        }

        public static void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
                Students.Remove(student);
        }

        // Add a grade to a student
        public static void AddGrade(Grade grade)
        {
            var student = Students.FirstOrDefault(s => s.StudentID == grade.StudentID);
            if (student != null)
            {
                if (student.Grades == null)
                    student.Grades = new List<Grade>();

                student.Grades.Add(grade);
            }
        }

        // Performance calculation
        public static Performance GetPerformance(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student == null || student.Grades == null || student.Grades.Count == 0)
                return null;

            double avg = student.Grades.Average(g => g.FinalGrade);
            int passed = student.Grades.Count(g => g.FinalGrade >= 75);
            int failed = student.Grades.Count(g => g.FinalGrade < 75);

            string remarks = avg >= 75 ? "Passed" : "Failed";

            return new Performance
            {
                AverageGrade = avg,
                PassedCount = passed,
                FailedCount = failed,
                Remarks = remarks
            };
        }
    }
}
