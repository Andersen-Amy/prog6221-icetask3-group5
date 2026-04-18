using System;
using System.Collections.Generic;
using System.Text;

namespace CampusManagement
{
    public class Student : Person
    {
        private string _studentNumber;
        private string _courseName;
        private List<double> _marks;

        public Student(string id, string name, string email, string studentNumber, string courseName)
            : base(id, name, email)
        {
            StudentNumber = studentNumber;
            CourseName = courseName;
            _marks = new List<double>();
        }

        public string StudentNumber
        {
            get { return _studentNumber; }
            set
            {
                // Validation: Starts with ST + 8 digits (Total 10 characters)
                if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("ST") || value.Length != 10 || !long.TryParse(value.Substring(2), out _))
                    throw new ArgumentException("Student Number must start with 'ST' followed by exactly 8 digits.");
                _studentNumber = value;
            }
        }

        public string CourseName
        {
            get { return _courseName; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Course name cannot be empty."); _courseName = value; }
        }

        public void AddMark(double mark)
        {
            if (mark < 0 || mark > 100) throw new ArgumentOutOfRangeException("Mark must be between 0 and 100.");
            _marks.Add(mark);
        }

        public double GetAverage()
        {
            if (_marks.Count == 0) throw new InvalidOperationException("No marks have been captured yet.");
            double total = 0;
            foreach (var m in _marks) total += m;
            return total / _marks.Count;
        }

        public override string GetDetails()
        {
            string avg = _marks.Count > 0 ? $"{GetAverage():F1}%" : "No marks yet";
            return $"{base.GetDetails()} | Student No: {StudentNumber} | Average: {avg}";
        }
    }
}