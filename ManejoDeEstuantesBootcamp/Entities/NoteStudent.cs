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
            if (Qualification >= 90 && Qualification <= 100)
            {
                return "A";
            }
            else if (Qualification >= 80 && Qualification <= 89)
            {
                return "B";
            }
            else if (Qualification >= 70 && Qualification <= 79)
            {
                return "C";
            }
            else if (Qualification >= 41 && Qualification <= 69)
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
