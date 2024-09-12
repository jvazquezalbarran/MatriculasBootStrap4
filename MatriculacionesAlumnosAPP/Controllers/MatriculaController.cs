using MatriculacionesAlumnosAPP.Models;
using MatriculacionesAlumnosAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculacionesAlumnosAPP.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Matricula
        public ActionResult CrearMatricula()
        {
            MatriculasAlumnosViewModel vm = new MatriculasAlumnosViewModel();
            using(var context = new DbContext.Context())
            {
                vm.Alumnos = context.Alumnos.OrderByDescending(a => a.nombreAlumno).ToList();
                vm.Asignaturas = context.Asignaturas.OrderByDescending(a => a.nombreAsignatura).ToList();
            }

            return View(vm);
        }
        [HttpPost]
        public RedirectToRouteResult CrearMatricula(MatriculasAlumnosViewModel vm)
        {
            using(var context = new DbContext.Context())
            {
                var alumno = context.Alumnos.Where(a => a.AlumnoID 
                        == vm.AlumnoSeleccionado).FirstOrDefault();
                var asignatura = context.Asignaturas.Where(a => a.AsignaturaID 
                        == vm.AsignaturaSeleccionada).FirstOrDefault();

                Matricula matricula = new Matricula();
                matricula.Alumno = alumno;
                matricula.AlumnoID = Convert.ToInt32(vm.AlumnoSeleccionado);
                matricula.Asignatura = asignatura;
                matricula.AsignaturaID = Convert.ToInt32(vm.AsignaturaSeleccionada);
                matricula.Fecha_Matricula = vm.FechaMatricula;

                context.Matriculas.Add(matricula);
                context.SaveChanges();
                    
            }
            return RedirectToAction("VerMatriculas");
        }

        public PartialViewResult _CreatePartial()
        {
            var model = new MatriculasAlumnosViewModel();
            using (var context = new DbContext.Context())
            {
                model.Alumnos = context.Alumnos.OrderByDescending(a => a.nombreAlumno).ToList();
                model.Asignaturas = context.Asignaturas.OrderByDescending(a => a.nombreAsignatura).ToList();
            }
            return PartialView(model);
        }

        public ActionResult VerMatriculas()
        {
            using (var context = new DbContext.Context())
            {
                //haciendolo con Includes
                
                var queryConIncludes = context.Matriculas.Include(m => m.Alumno).Include(m => m.Asignatura).ToList();

                return View("VerMatriculasConInclude",queryConIncludes);


                //haciendolo con ViewModel
                //var query = context.Matriculas.Select(m => m).ToList();
                //List<AlumnosMatriculasViewModel> vm = new List<AlumnosMatriculasViewModel>();

                //foreach(var matricula in query)
                //{
                //    AlumnosMatriculasViewModel alumnosMatriculasViewModel = new AlumnosMatriculasViewModel();
                //    alumnosMatriculasViewModel.MatriculaID = matricula.MatriculaID;
                //    alumnosMatriculasViewModel.NombreAlumno = context.Alumnos.Where(a => a.AlumnoID == matricula.AlumnoID).FirstOrDefault().nombreAlumno;
                //    alumnosMatriculasViewModel.EdadAlumno = context.Alumnos.Where(a => a.AlumnoID == matricula.AlumnoID).FirstOrDefault().Edad;
                //    alumnosMatriculasViewModel.NombreAsignatura = context.Asignaturas.Where(a => a.AsignaturaID == matricula.AsignaturaID).FirstOrDefault().nombreAsignatura;
                //    alumnosMatriculasViewModel.CreditosAsignatura = context.Asignaturas.Where(a => a.AsignaturaID == matricula.AsignaturaID).FirstOrDefault().Creditos;

                //    vm.Add(alumnosMatriculasViewModel);
                //}
                
                //return View(vm);
            }
        }
        public RedirectToRouteResult EliminarMatricula(int id)
        {
            using(var context = new DbContext.Context())
            {
                var query = context.Matriculas.Where(m => m.MatriculaID == id).SingleOrDefault();
                
                if(query != null)
                {
                    context.Matriculas.Remove(query);
                    context.SaveChanges();
                    return RedirectToAction("VerMatriculas");
                }
                else
                {
                    return null;
                }    

            }       
        }

    }
}