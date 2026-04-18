using System;

namespace CampusManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CAMPUS MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. Add Lecturer");
                Console.WriteLine("3. Create Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Capture Marks");
                Console.WriteLine("6. View Course Report");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            RegisterStudent();
                            break;
                        case "2":
                            AddLecturer();
                            break;
                        case "3":
                            CreateCourse();
                            break;
                        case "4":
                            EnrollInCourse();
                            break;
                        case "5":
                            CaptureMarks();
                            break;
                        case "6":
                            ViewReports();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Press Enter to try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nERROR: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        static void RegisterStudent()
        {
            Console.Write("Enter 13-digit ID: "); string id = Console.ReadLine();
            Console.Write("Enter Name: "); string name = Console.ReadLine();
            Console.Write("Enter Email: "); string email = Console.ReadLine();

            Console.Write("Enter Student Number (type only the 8 digits after 'ST'): ST");
            string sNoSuffix = Console.ReadLine();
            string fullStudentNumber = "ST" + sNoSuffix;

            Console.Write("Enter Course Code: ");
            string cCode = Console.ReadLine();

            var course = CampusManager.FindCourse(cCode);
            if (course == null)
            {
                Console.WriteLine("Error: That course does not exist! Please create the course first.");
                return;
            }

            Student newStudent = new Student(id, name, email, fullStudentNumber, course.CourseName);
            CampusManager.AllStudents.Add(newStudent);
            Console.WriteLine("Student registered successfully!");
        }

        static void AddLecturer()
        {
            Console.Write("Enter 13-digit ID: "); string id = Console.ReadLine();
            Console.Write("Enter Name: "); string name = Console.ReadLine();
            Console.Write("Enter Email: "); string email = Console.ReadLine();
            Console.Write("Enter 8-digit Employee ID: "); string eId = Console.ReadLine();
            Console.Write("Enter Department: "); string dept = Console.ReadLine();

            Lecturer newLecturer = new Lecturer(id, name, email, eId, dept);
            CampusManager.AllLecturers.Add(newLecturer);
            Console.WriteLine("Lecturer added successfully!");
        }

        static void CreateCourse()
        {
            Console.Write("Enter Course Code: "); string code = Console.ReadLine();
            Console.Write("Enter Course Name: "); string name = Console.ReadLine();

            Course newCourse = new Course(code, name);
            CampusManager.AllCourses.Add(newCourse);
            Console.WriteLine("Course created successfully!");
        }

        static void EnrollInCourse()
        {
            Console.Write("Enter Student Number: "); string sNo = Console.ReadLine();
            Console.Write("Enter Course Code: "); string cCode = Console.ReadLine();

            var student = CampusManager.FindStudent(sNo);
            var course = CampusManager.FindCourse(cCode);

            if (student != null && course != null)
            {
                course.EnrollStudent(student);
            }
            else
            {
                Console.WriteLine("Student or Course not found.");
            }
        }

        static void CaptureMarks()
        {
            Console.WriteLine("\n--- Capture Student Marks ---");
            Console.Write("Enter Student Number: ");
            string sNo = Console.ReadLine();

            var student = CampusManager.FindStudent(sNo);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.WriteLine($"Found: {student.Name}");
            Console.Write("Enter Mark (0-100): ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double mark))
            {
                student.AddMark(mark);
                Console.WriteLine("Mark added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a numeric grade.");
            }
        }

        static void ViewReports()
        {
            Console.Write("Enter Course Code: "); string cCode = Console.ReadLine();
            var course = CampusManager.FindCourse(cCode);

            if (course != null)
            {
                course.ViewReport();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
    }
}