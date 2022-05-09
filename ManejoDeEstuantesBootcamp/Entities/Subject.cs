using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Entities
{
    public class Subject
    {
        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public void Display()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(string.Format("Código de la asignatura: {0}", SubjectCode));
            Console.WriteLine(string.Format("Nombre de la asignatura: {0}", Name));
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }
    }
}
