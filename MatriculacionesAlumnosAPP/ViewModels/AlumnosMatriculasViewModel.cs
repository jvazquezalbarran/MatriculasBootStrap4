using MatriculacionesAlumnosAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculacionesAlumnosAPP.ViewModels
{
    public class AlumnosMatriculasViewModel
    {
        public int MatriculaID { get; set; }
        public string NombreAlumno { get; set; }
        public int EdadAlumno { get; set; }
        public string NombreAsignatura { get; set; }
        public int CreditosAsignatura { get; set; }
    }
}