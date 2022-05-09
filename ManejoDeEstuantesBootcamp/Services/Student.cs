using ManejoDeEstuantesBootcamp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Services
{
    public static class Student
    {
        public static List<Entities.Student> Students = new List<Entities.Student>();

        public static void GetAll()
        {
            foreach (var item in Students)
            {
                item.Display();
            }
            Console.ReadKey();
        }
        public static void Add()
        {
            Entities.Student student = new Entities.Student();

            Console.WriteLine("Digite el código del estudiante");
            student.StudentCode = Console.ReadLine();

            Console.WriteLine("Digite el nombre del estudiante");
            student.Name = Console.ReadLine();

            Console.WriteLine("Digite el apellido del estudiante");
            student.LastName = Console.ReadLine();

            Students.Add(student);
        }

        public static void AddSubject(string studentCode, string subjectCode)
        {
            var student = new Entities.Student();
            int studentIndex = -1;
            Entities.Subject subject = null;
            student.Subjects = new List<Entities.Subject>();

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentCode == studentCode)
                {
                    studentIndex = i;
                    break;
                }
            }
            if (studentIndex != -1)
            {


                foreach (var item in Subject.Subjects)
                {
                    if (item.SubjectCode == subjectCode)
                    {
                        subject = item;
                        break;
                    }
                }

                if (subject == null)
                {
                    Console.WriteLine("No se encontro dicha materia");
                }
                else
                {
                    if (student.Subjects.Count > 0)
                    {
                        student.Subjects.AddRange(student.Subjects);
                    }
                    student.Subjects.Add(subject);
                    Students[studentIndex].Subjects = student.Subjects;
                }
            }
            else
            {
                Console.WriteLine("No se encuentra el estudiante en cuestion, porfavor revise el codigo");
            }


        }

        public static void Delete(string studentCode)
        {
            bool deleted = false;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentCode == studentCode)
                {
                    deleted = true;
                    Students.Remove(Students[i]);
                    break;
                }
            }
            if (deleted)
            {
                Console.WriteLine("El estudiante ha sido eliminado correctamente");
            }
            else
            {
                Console.WriteLine("El estudiante no ha sido encontrado, porfavor revisar bien el codigo del estudiante");
            }
        }

        public static void Update(string studentCode)
        {
            var student = new Entities.Student();
            int studentIndex = new int();


            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentCode == studentCode)
                {
                    student = Students[i];
                    studentIndex = i;
                    break;
                }
            }
            if (studentIndex >= 0)
            {
                Console.WriteLine("Por favor digite el nuevo nombre del estudiante");
                student.Name = Console.ReadLine();

                Console.WriteLine("Por favor digite el nuevo apellido del estudiante");
                student.LastName = Console.ReadLine();

                Students[studentIndex] = student;
            }
            else
            {
                Console.WriteLine("No se encontro el estudiante, porfavor revise el codigo del estudiante ");
            }
        }
        public static void EvaluateSubjects(string studentCode)
        {
            var student = new Entities.Student();
            int studentIndex = -1;

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentCode == studentCode)
                {
                    student = Students[i];
                    studentIndex = i;
                    break;
                }
            }
            if (studentIndex != -1)
            {

                if (student.Subjects != null)
                {

                    var listNotes = new List<Entities.NoteStudent>();
                    foreach (var item in student.Subjects)
                    {
                        Console.WriteLine($"Por favor digite la calificacion del estudiante: {student.Name} en la asignatura: {item.Name}");
                        var Note = new Entities.NoteStudent
                        {
                            SubjectCode = item.SubjectCode,
                            Qualification = GetNumber()
                        };
                        listNotes.Add(Note);

                    }
                    student.Notes = listNotes;
                    Students[studentIndex] = student;
                }

                else
                {
                    Console.WriteLine("Este estudiante no tiene materias asignadas");
                }
            }
            else
            {
                Console.WriteLine("No se encontro el estudiante, porfavor revise el codigo del estudiante ");
            }
        }
        public static void DisplayNotes(string studentCode)
        {
            Entities.Student student = null;
            foreach (var item in Students)
            {
                if (item.StudentCode == studentCode)
                {
                    student = item;
                    break;
                }
            }
            if (student != null)
            {
                int asignaturas = 0;
                if (student.Notes != null)
                {
                    foreach (var note in student.Notes)
                    {
                        Console.WriteLine($"El estudiante {student.Name} {student.LastName} tiene la calificacion: {note.Qualification} tiene una {note.GetQualificationLetter()}");
                        asignaturas++;
                    }
                    if (asignaturas == 0)
                    {
                        Console.WriteLine("Este estudiante no tiene ningun asignatura asignada");
                    }
                }

            }
            else
            {
                Console.WriteLine("No se encontro el estudiante, porfavor revise el codigo del estudiante ");
            }

        }
        private static int GetNumber()
        {
            int number;
            bool isGood;
            do
            {
                isGood = int.TryParse(Console.ReadLine(), out number);
                if (number > 100 || number < 0)
                {
                    Console.WriteLine("La calificacion debe estar entre 0 y 100");
                    isGood = false;
                }
            } while (!isGood);

            return number;
        }
    }
}
