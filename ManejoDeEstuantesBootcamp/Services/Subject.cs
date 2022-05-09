using ManejoDeEstuantesBootcamp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Services
{
    public static class Subject
    {
        public static List<Entities.Subject> Subjects = new List<Entities.Subject>();

        public static void Add()
        {
            var subject = new Entities.Subject();
            Console.WriteLine("Ingrese el codigo de la asignatura");
            subject.SubjectCode = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de la asignatura");
            subject.Name = Console.ReadLine();

            Subjects.Add(subject);
        }

        public static void Delete()
        {
            throw new NotImplementedException();
        }

        public static void Getall()
        {
            throw new NotImplementedException();
        }

        public static void Update()
        {
            throw new NotImplementedException();
        }
        public static void EvaluateStudents(string subjectCode)
        {
            Entities.Subject subject = null;
            foreach (var item in Subjects)
            {
                if (item.SubjectCode == subjectCode)
                {
                    subject = item;
                    break;
                }
            }
            if (subject != null)
            {
                int students = 0;
                foreach (var student in Student.Students)
                {
                    if (student.Subjects != null)
                    {

                        int index = student.Subjects.FindIndex(x => x.Equals(subject));
                        if (index != -1)
                        {
                            var listNotes = new List<Entities.NoteStudent>();
                            Console.WriteLine($"Califique al etudiante: {student.Name} {student.LastName}, porfavor digite su calificacion");
                            var note = new Entities.NoteStudent
                            {
                                SubjectCode = student.Subjects[index].SubjectCode,
                                Qualification = GetQualification(),

                            };
                            Console.WriteLine($"El estudiante {student.Name} {student.LastName} tiene una: {note.GetQualificationLetter()} ");
                            if (student.Notes != null)
                            {
                                listNotes.AddRange(student.Notes);
                            }
                            listNotes.Add(note);
                            student.Notes = listNotes;
                            students++;
                        }
                    }
                }
                if (students == 0)
                {
                    Console.WriteLine("Esta asignatura no tiene ningun estudiante asignado");
                }

            }
            else
            {
                Console.WriteLine("No se pudo encontrar dicha asignatura, por favor verifique el codigo de la asignatura");
            }
        }
        public static void GetAll()
        {
            foreach (var item in Subjects)
            {
                item.Display();
            }
        }
        public static void DisplayNotes(string subjectCode)
        {
            Entities.Subject subject = null;
            foreach (var item in Subjects)
            {
                if (item.SubjectCode == subjectCode)
                {
                    subject = item;
                    break;
                }
            }
            if (subject != null)
            {
                int students = 0;
                foreach (var student in Student.Students)
                {
                    if (student.Subjects != null)
                    {

                        int index = student.Subjects.FindIndex(x => x.Equals(subject));
                        if (index != -1)
                        {
                            if (student.Notes != null)
                            {
                                var note = student.Notes.Find(x => x.SubjectCode == subjectCode);
                                Console.WriteLine($"El estudiante {student.Name} {student.LastName} tiene la calificacion: {note.Qualification} tiene una {note.GetQualificationLetter()}");
                                students++;
                            }
                        }
                    }
                }
                if (students == 0)
                {
                    Console.WriteLine("Esta asignatura no tiene ningun estudiante asignado");
                }

            }
            else
            {
                Console.WriteLine("No se pudo encontrar dicha asignatura, por favor verifique el codigo de la asignatura");
            }

        }
        private static int GetQualification()
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
