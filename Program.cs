using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace LabRab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие");
            int counter;
            counter = Convert.ToInt32(Console.ReadLine());
            switch (counter)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    foreach (var student in Student.Data)
                    {
                        Console.Write($"\nID: { student.Id}" +
                        $"\nФИО: {student.Surname} {student.Name} {student.Patronymic}" +
                        $"\nТелефон: {student.Number}" +
                        $"\nАдрес: {student.Address}" +
                        $"\nДата рождения: {student.Birthday}" +
                        $"\nВозраст: {student.GetAge()}" +
                        $"\nФакультет: {student.Faculty}" +
                        $"\nКурс: {student.Course}" +
                        $"\nГруппа: {student.Group}" +
                        $"\n");
                    }
                    break;
                case 3:
                    {
                        Console.Write("Введите название факультета: ");
                        string find = Console.ReadLine();
                        List<Student> result = Student.GetStudentsFromFaculty(ref find);
                        if (result.Count == 0) Console.WriteLine("¯\\_(ツ)_/¯");
                        else
                            foreach (var student in result)
                            {
                                Console.Write($"\nID: { student.Id}" +
                                $"\nФИО: {student.Surname} {student.Name} {student.Patronymic}" +
                                $"\nКурс: {student.Course}" +
                                $"\nГруппа: {student.Group}" +
                                $"\n");
                            }
                    }
                    break;
                case 4:
                    {
                        Console.Write("Введите название факультета: ");
                        string faculty = Console.ReadLine();
                        Console.Write("Введите номер курса: ");
                        int course = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите номер группы: ");
                        int group = Convert.ToInt32(Console.ReadLine());

                        List<Student> result = Student.GetStudentsFromGroup(faculty, course, group);
                        if (result.Count == 0) Console.WriteLine("¯\\_(ツ)_/¯");
                        else
                            foreach (var student in result)
                            {
                                Console.Write($"\nID: { student.Id}" +
                                $"\nФИО: {student.Surname} {student.Name} {student.Patronymic}" +
                                $"\n");
                            }
                    }
                    break;

                default:
                    Console.WriteLine("Число введено неверно");
                    break;
            }
        }


        private static void AddStudent()
        {
            Student Student;
            string surname, name;
            Console.Write(
                "\n1 - ввести полную информацию об студентах" +
                "\n2 - ввести краткие сведение об студенте" +
                "\nВыберите действие: ");
            string opt = Console.ReadLine();
            if (opt != "1" && opt != "2")
            {
                Console.WriteLine("Нет такого варианта");
                return;
            }
            Console.Write("\nВведите фамилию: ");
            surname = Console.ReadLine();
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    string patronymic, phone, address, faculty;
                    int id, course, group;

                    Console.Write("Введите отчество: ");
                    patronymic = Console.ReadLine();
                    Console.Write("Введите id: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите телефон: +375");
                    phone = "+375" + Console.ReadLine();
                    Console.Write("Введите дату рождения(ДД.ММ.ГГГГ): ");
                    string date = Console.ReadLine();
                    string[] elems = date.Split('.');
                    var birthdate = new DateTime(Convert.ToInt32(elems[2]), Convert.ToInt32(elems[1]), Convert.ToInt32(elems[0]));
                    Console.Write("Введите адрес: ");
                    address = Console.ReadLine();
                    Console.Write("Введите факультет: ");
                    faculty = Console.ReadLine();
                    Console.WriteLine("Введите курс: ");
                    course = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите Группу: ");
                    group = Convert.ToInt32(Console.ReadLine());


                    Student = new Student(id, surname, name, patronymic, birthdate, address, phone, faculty, group, course);
                    Student.Add(Student);
                    Console.WriteLine("Студент добавлен");
                    break;
                case "2":
                    Student = new Student(surname, name);
                    Student.Add(Student);
                    Console.WriteLine("Студент добавлен");
                    break;
                default:
                    Console.WriteLine("Нет такого варианта");
                    break;
            }

        }
    }

}
