using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeEstuantesBootcamp.Entities
{
    public class NoteStudent
    {
        public int Qualification { get; set; }
        public string SubjectCode { get; set; }
        public string GetQualificationLetter()
        {
            if (90 >= Qualification && 100 <= Qualification)
            {
                return "A";
            }
            else if (80 >= Qualification && 89 <= Qualification)
            {
                return "B";
            }
            else if (70 >= Qualification && 79 <= Qualification)
            {
                return "C";
            }
            else if (41 >= Qualification && 69 <= Qualification)
            {
                return "D";
            }
            else
            {
                return "F";
            }


        }
    }
}
