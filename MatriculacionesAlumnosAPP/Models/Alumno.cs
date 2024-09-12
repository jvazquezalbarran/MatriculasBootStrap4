using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculacionesAlumnosAPP.Models
{
    public class Alumno
    {
        [Key]
        public int AlumnoID { get; set; }
        public string nombreAlumno { get; set; }
        public int Edad { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }

    }
}