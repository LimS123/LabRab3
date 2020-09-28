using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LabRab3
{
    
    partial class Student
    {
        public static List<Student> Data { get; private set; }

        public int Id { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Address { get; private set; }
        public string Number { get; private set; }
        public string Faculty { get; private set; }
        public int Group { get; private set; }
        public int Course { get; private set; }
        public static int Counter { get; private set; }

        static Student()
        {
            Counter = 0;
            Data = new List<Student> {
                new Student(1, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                new Student(2, "Oleshkevich", "Kirill", "Vadimovich", new DateTime(2002,03,31), "Чижовка сити", "+375(29)chto-to tam", "IT", 2, 2),
                new Student(3, "Shibko", "Dmitry", "Yurievich", new DateTime(2002,04,23), "Чижовка сити", "+375(29)chto-to tam", "IT", 2, 2),
                new Student(4, "Gromadko", "Eugene", "Valerich", new DateTime(2001,06,19), "Большие степаншки))))", "+375(29)chto-to tam", "LH", 2, 1),
                new Student(5, "Beloded", "Nikolay", "Ivanovich", new DateTime(1900,01,01), "Свердлова 13а", "+375(29)chto-to tam", "IT", 25, 2),
                new Student(6, "Pupkin", "Vasily", "Igorevich", new DateTime(2001,12,11), "Бобруйская 25", "+375(29)chto-to tam", "LH", 2, 3),
                //new Student(7, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                //new Student(8, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                //new Student(9, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                //new Student(10, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                //new Student(11, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
                //new Student(12, "Zayats", "Roman", "Viktorovich", new DateTime(2002,06,19), "Белорусская 21", "+375(29)chto-to tam", "IT", 2, 2),
            };
            qwerty2 = 322;
        }
        public Student()
        {
            Id = 0;
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

        public Student(int id, string surname, string name, string patronymic, DateTime birthdate, string address, string number, string faculty, int group, int course)  // Param constr
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthdate;
            Address = address;
            Number = number;
            Faculty = faculty;
            Group = group;
            Course = course;
        }

        public Student(
            string surname,
            string name,
            int id = 0,
            string patronymic = "-",
            DateTime birthdate = new DateTime(),
            string address = "-",
            string number = "-",
            string faculty = "-",
            int group = 0,
            int course = 1)  // Param constr
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthdate;
            Address = address;
            Number = number;
            Faculty = faculty;
            Group = group;
            Course = course;
        }

        public void Add(Student student)
        {
            Data.Add(student);
            Counter++;
        }
        public int GetAge()
        {
            int age = 0;
            var now = DateTime.Now;
            age = now.Year - Birthday.Year;
            if (now.Month < Birthday.Month && now.Day < Birthday.Day) age--;
            return age;
        }
        public static List<Student> GetStudentsFromFaculty(ref string faculty)
        {
            var list = new List<Student>();
            foreach (var student in Data)
            {
                if (student.Faculty == faculty)
                    list.Add(student);
            }
            return list;
        }
        public static List<Student> GetStudentsFromGroup(string faculty, int course, int group)
        {
            var list = new List<Student>();
            foreach (var student in Data)
            {
                if (student.Faculty == faculty && student.Course == course && student.Group == group)
                    list.Add(student);
            }
            return list;
        }
        public static void IsIdFree(int id, out bool isFree)
        {
            isFree = true;
            foreach (var item in Data)
            {
                if (item.Id == id)
                {
                    isFree = false;
                    break;
                }
            }
        }
    }
}
