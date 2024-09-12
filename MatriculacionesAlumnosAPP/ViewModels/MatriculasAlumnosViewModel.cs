using MatriculacionesAlumnosAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculacionesAlumnosAPP.ViewModels
{
    public class MatriculasAlumnosViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public int? AlumnoSeleccionado { get; set; }

        public List<Asignatura> Asignaturas { get; set; }
        public int? AsignaturaSeleccionada { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaMatricula { get; set; } = DateTime.Now;

    }
}