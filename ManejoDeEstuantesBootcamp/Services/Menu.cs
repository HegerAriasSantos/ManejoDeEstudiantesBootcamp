using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Services
{
    public class Menu
    {
        public static void Header()
        {
            Console.WriteLine(Title("Manejo de estudiantes"));
            Console.WriteLine();
        }

        public static string Title(string title)
        {
            return string.Format("---------- {0} ----------", title);
        }
        public static void Show()
        {
            Console.Clear();
            Header();
            Console.WriteLine("1- Registrar estudiante");
            Console.WriteLine("2- Registrar asignatura");
            Console.WriteLine("3- Inscribir estudiante en asignatura");
            Console.WriteLine("4- Evaluar estudiantes por asignatura");
            Console.WriteLine("5- Evaluar asignaturas por estudiante");
            Console.WriteLine("6- Visualizar notas por asignaturas");
            Console.WriteLine("7- Visualizar notas por estudiante");
            Console.WriteLine("8- Visualizar estudiantes");
            Console.WriteLine("9- Visualizar asignaturas");
            Console.WriteLine("10- Salir");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Pulse una opción para continuar");


            int option = new int();
            var isValid = false;

            do
            {
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 10;
                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La opción ingresada no es válida, intente nuevamente...");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (!isValid);

            switch (option)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AddSubject();
                    break;
                case 3:
                    AddSubjectToStudent();
                    break;
                case 4:
                    EvaluateStudentsFromSubject();
                    break;
                case 5:
                    EvaluateSubjectsFromStudent();
                    break;
                case 6:
                    DisplayNotesFromSubject();
                    break;
                case 7:
                    DisplayNotesFromStudent();
                    break;
                case 8:
                    DisplayStudents();
                    break;
                case 9:
                    DisplaySubjects();
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Digite una opcion entre 1 y 10");
                    break;
            }

        }

        public static void AddStudent()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Añadir nuevo estudiante"));
            Student.Add();
            Show();
        }
        public static void AddSubject()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Añadir nueva asignatura"));
            Subject.Add();
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }

        public static void AddSubjectToStudent()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Añadir asignatura a estudiante \n"));
            Console.WriteLine("Ingrese codigo del estudiante");
            var studentCode = Console.ReadLine();
            Console.WriteLine("Ingrese codigo de la asignatura");
            var subjectCode = Console.ReadLine();
            Student.AddSubject(studentCode, subjectCode);
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }
        public static void EvaluateStudentsFromSubject()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Evaluar estudiantes de una asignatura "));
            Console.WriteLine("Ingrese codigo de la asignatura");
            var subjectCode = Console.ReadLine();
            Subject.EvaluateStudents(subjectCode);
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }
        public static void EvaluateSubjectsFromStudent()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Notas de un estudiante"));
            Console.WriteLine("Ingrese codigo del estudiante");
            var studentCode = Console.ReadLine();
            Student.EvaluateSubjects(studentCode);
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }
        public static void DisplayStudents()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Visualizar Estudiantes"));
            Student.GetAll();
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }
        public static void DisplayNotesFromSubject()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Notas de una asignatura"));
            Console.WriteLine("Ingrese codigo de la asignatura");
            var studentCode = Console.ReadLine();
            Subject.DisplayNotes(studentCode);
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }

        public static void DisplayNotesFromStudent()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Visualizar Estudiantes"));
            Console.WriteLine("Ingrese codigo del estudiante");
            var studentCode = Console.ReadLine();
            Student.DisplayNotes(studentCode);
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }

        public static void DisplaySubjects()
        {
            Console.Clear();
            Header();
            Console.WriteLine(Title("Visualizar Asignaturas"));
            Subject.GetAll();
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Show();

        }
    }
}
