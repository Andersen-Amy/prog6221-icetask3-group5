using System;
using System.Collections.Generic;
using System.Text;

namespace CampusManagement
{
    public abstract class Person
    {
        private string _id;
        private string _name;
        private string _email;

        public Person(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public string Id
        {
            get { return _id; }
            set
            {
                //13 digits id
                if (string.IsNullOrWhiteSpace(value) || value.Length != 13 || !long.TryParse(value, out _))
                    throw new ArgumentException("ID number must be exactly 13 digits.");
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty."); _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                // Must contain @
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Invalid email address.");
                _email = value;
            }
        }

        public virtual string GetDetails() => $"ID: {Id} | Name: {Name} | Email: {Email}";
        public override string ToString() => GetDetails();
    }
}