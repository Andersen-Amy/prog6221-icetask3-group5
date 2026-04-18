
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusManagement
{
    public static class CampusManager
    {
        public static List<Student> AllStudents = new List<Student>();
        public static List<Lecturer> AllLecturers = new List<Lecturer>();
        public static List<Course> AllCourses = new List<Course>();

        public static Student FindStudent(string studentNo) => AllStudents.Find(s => s.StudentNumber == studentNo);
        public static Course FindCourse(string courseCode) => AllCourses.Find(c => c.CourseCode == courseCode);
    }
}