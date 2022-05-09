using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Entities
{
    public class Student
    {
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<NoteStudent> Notes { get; set; }

        public void Display()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(string.Format("Código del estudiante: {0}", StudentCode));
            Console.WriteLine(string.Format("Nombre del estudiante: {0}", Name));
            Console.WriteLine(string.Format("Apellido del estudiante: {0}", LastName));
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }
    }
}
