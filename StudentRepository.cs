using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


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
                student.Username = updated.Username;
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
    }
}
