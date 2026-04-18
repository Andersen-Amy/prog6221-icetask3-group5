using System;
using System.Collections.Generic;
using System.Text;


namespace CampusManagement
{
    public class Lecturer : Person
    {
        private string _employeeId;
        private string _department;

        public Lecturer(string id, string name, string email, string employeeId, string department)
            : base(id, name, email)
        {
            EmployeeId = employeeId;
            Department = department;
        }

        public string EmployeeId
        {
            get { return _employeeId; }
            set
            {
                //  Exactly 8 digits
                if (string.IsNullOrWhiteSpace(value) || value.Length != 8 || !long.TryParse(value, out _))
                    throw new ArgumentException("Employee ID must be exactly 8 digits.");
                _employeeId = value;
            }
        }

        public string Department
        {
            get { return _department; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Department cannot be empty."); _department = value; }
        }

        public override string GetDetails() => $"{base.GetDetails()} | Employee ID: {EmployeeId} | Dept: {Department}";
    }
}