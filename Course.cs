using CampusManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CampusManagement
{
    public class Course
{
    
    private string _courseCode;
    private string _courseName;
    private List<Student> _enrolledStudents; // The list of students in this "room"

    // CONSTRUCTOR
    public Course(string courseCode, string courseName)
    {
        CourseCode = courseCode;
        CourseName = courseName;
        _enrolledStudents = new List<Student>(); // Start with an empty classroom
    }

    
    public string CourseCode
    {
        get { return _courseCode; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Course code cannot be empty.");
            _courseCode = value;
        }
    }

    public string CourseName
    {
        get { return _courseName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Course name cannot be empty.");
            _courseName = value;
        }
    }

        
        //THE ENROLLMENT LOGIC 
        public void EnrollStudent(Student student)
        {
        
            if (student == null)
                throw new ArgumentNullException("Student cannot be null.");

           
            foreach (Student s in _enrolledStudents)
            {
                if (s.StudentNumber == student.StudentNumber)
                    throw new InvalidOperationException($"{student.Name} is already enrolled.");
            }

            _enrolledStudents.Add(student);
            Console.WriteLine($"{student.Name} enrolled in {CourseName} successfully.");
        }

        //THE REPORTING LOGIC
        public void ViewReport()
    {
        Console.WriteLine($"\n--- Report: {CourseCode} - {CourseName} ---");

        if (_enrolledStudents.Count == 0)
        {
            Console.WriteLine("No students enrolled yet.");
            return;
        }

        
        foreach (Student s in _enrolledStudents)
        {
            Console.WriteLine(s.GetDetails());
        }
    }
}
}