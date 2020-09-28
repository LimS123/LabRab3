using System;
using System.Collections.Generic;
using System.Text;

namespace LabRab3
{
    partial class Student
    {
        const int qwerty = 228; // usefull information
        static readonly int qwerty2;
        private Student(int id)
        {
            Id = id;
            Surname = "-";
            Name = "-";
            Patronymic = "-";
            Birthday = new DateTime();
            Address = "-";
            Number = "-";
            Faculty = "-";
            Group = 0;
            Course = 0;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (Surname + Name).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }

}
