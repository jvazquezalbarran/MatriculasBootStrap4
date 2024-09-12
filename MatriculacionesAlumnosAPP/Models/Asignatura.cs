using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculacionesAlumnosAPP.Models
{
    public class Asignatura
    {
        [Key]
        public int AsignaturaID { get; set; }
        public string nombreAsignatura { get; set; }
        public int Creditos { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
        
    }
}