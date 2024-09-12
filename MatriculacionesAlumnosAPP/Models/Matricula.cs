using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatriculacionesAlumnosAPP.Models
{
    public class Matricula
    {
        [Key]
        public int MatriculaID { get; set; }
        public int AlumnoID { get; set; }
        [ForeignKey(name: "AlumnoID")]
        public virtual Alumno Alumno { get; set; }
        public int AsignaturaID { get; set; }
        [ForeignKey(name: "AsignaturaID")]
        public virtual Asignatura Asignatura{ get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Matricula { get; set; }

    }
}