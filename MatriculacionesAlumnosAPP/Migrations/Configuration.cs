namespace MatriculacionesAlumnosAPP.Migrations
{
    using MatriculacionesAlumnosAPP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MatriculacionesAlumnosAPP.DbContext.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MatriculacionesAlumnosAPP.DbContext.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            

            var asignaturas = new List<Asignatura>
            {
                new Asignatura{nombreAsignatura="Matematicas",Creditos=22},
                new Asignatura{nombreAsignatura="Filosofia",Creditos=15},
                new Asignatura{nombreAsignatura="Fisica",Creditos=20}
            };
            asignaturas.ForEach(asignatura => context.Asignaturas.AddOrUpdate(a => a.nombreAsignatura, asignatura));
            context.SaveChanges();

            var alumnos = new List<Alumno>
            {
                new Alumno{nombreAlumno="Olga Ramirez",Edad=22},
                new Alumno{nombreAlumno="Pedro Jimenez",Edad=20},
                new Alumno{nombreAlumno="Sebastian Gomez", Edad=30}
            };
            alumnos.ForEach(alumno => context.Alumnos.AddOrUpdate(a => a.nombreAlumno, alumno));
            context.SaveChanges();

            var matriculas = new List<Matricula>
            {
                new Matricula
                {
                    AlumnoID = context.Alumnos.Single(a=>a.AlumnoID == 1).AlumnoID,
                    AsignaturaID = context.Asignaturas.Single(a=>a.AsignaturaID == 1).AsignaturaID,
                    Fecha_Matricula = DateTime.Now
                },
                new Matricula
                {
                    AlumnoID = context.Alumnos.Single(a=>a.AlumnoID == 1).AlumnoID,
                    AsignaturaID = context.Asignaturas.Single(a=>a.AsignaturaID == 2).AsignaturaID,
                    Fecha_Matricula = DateTime.Now
                },
                new Matricula
                {
                    AlumnoID = context.Alumnos.Single(a=>a.AlumnoID == 2).AlumnoID,
                    AsignaturaID = context.Asignaturas.Single(a=>a.AsignaturaID == 2).AsignaturaID,
                    Fecha_Matricula = DateTime.Now
                },
                new Matricula
                {
                    AlumnoID = context.Alumnos.Single(a=>a.AlumnoID == 3).AlumnoID,
                    AsignaturaID = context.Asignaturas.Single(a=>a.AsignaturaID == 1).AsignaturaID,
                    Fecha_Matricula = DateTime.Now
                },
                new Matricula
                {
                    AlumnoID = context.Alumnos.Single(a=>a.AlumnoID == 3).AlumnoID,
                    AsignaturaID = context.Asignaturas.Single(a=>a.AsignaturaID == 3).AsignaturaID,
                    Fecha_Matricula = DateTime.Now
                }
            };
            matriculas.ForEach(matricula => context.Matriculas.AddOrUpdate(m => m.Alumno, matricula));
            context.SaveChanges();
        }
    }
}
