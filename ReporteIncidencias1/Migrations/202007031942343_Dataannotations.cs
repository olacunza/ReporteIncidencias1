namespace ReporteIncidencias1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dataannotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidencias",
                c => new
                    {
                        IncidenciaID = c.Int(nullable: false, identity: true),
                        UnidadAtencion = c.String(),
                        TipoIncidencia = c.String(),
                        SubTipoIncidencia = c.String(),
                        ModalidadIncidencia = c.String(),
                        Usuario = c.String(),
                        Turno = c.String(),
                        Mancomunidad = c.String(),
                        Distrito = c.String(),
                        Semaforizacion = c.String(),
                        DireccionIncidencia = c.String(),
                        FuenteInfo = c.String(),
                        ContactoIncidencia = c.String(),
                        TelefonoContacto = c.String(),
                        CargoContacto = c.String(),
                        InstitucionContacto = c.String(),
                        DescripcionIncidencia = c.String(nullable: false),
                        ObservacionIncidencia = c.String(),
                        ApoyoInter = c.String(),
                        PrimerCanal = c.Boolean(nullable: false),
                        FechaIncidencia = c.String(),
                        HoraRegistroInc = c.String(),
                        EstadoIncidencia = c.String(),
                        Evidencia1 = c.String(),
                        Evidencia2 = c.String(),
                        Evidencia3 = c.String(),
                    })
                .PrimaryKey(t => t.IncidenciaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Incidencias");
        }
    }
}
