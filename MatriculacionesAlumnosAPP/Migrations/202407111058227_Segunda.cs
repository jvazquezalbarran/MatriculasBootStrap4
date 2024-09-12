namespace MatriculacionesAlumnosAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segunda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        AlumnoID = c.Int(nullable: false, identity: true),
                        nombreAlumno = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoID);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        MatriculaID = c.Int(nullable: false, identity: true),
                        AlumnoID = c.Int(nullable: false),
                        AsignaturaID = c.Int(nullable: false),
                        Fecha_Matricula = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MatriculaID)
                .ForeignKey("dbo.Alumno", t => t.AlumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Asignatura", t => t.AsignaturaID, cascadeDelete: true)
                .Index(t => t.AlumnoID)
                .Index(t => t.AsignaturaID);
            
            CreateTable(
                "dbo.Asignatura",
                c => new
                    {
                        AsignaturaID = c.Int(nullable: false, identity: true),
                        nombreAsignatura = c.String(),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsignaturaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "AsignaturaID", "dbo.Asignatura");
            DropForeignKey("dbo.Matricula", "AlumnoID", "dbo.Alumno");
            DropIndex("dbo.Matricula", new[] { "AsignaturaID" });
            DropIndex("dbo.Matricula", new[] { "AlumnoID" });
            DropTable("dbo.Asignatura");
            DropTable("dbo.Matricula");
            DropTable("dbo.Alumno");
        }
    }
}
