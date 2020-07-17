using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReporteIncidencias1.Models;

namespace ReporteIncidencias1.Models
{
    public class Incidencia
    {
        /*public Incidencia()
        {
            this.IncHistorial = new HashSet<IncHistorial>();
        }*/

        //DateTime dt = System.DateTime.Today;
        string valueFecha = string.Format("{0:dd/MM/yyyy}", System.DateTime.Today);
        string valueHora = string.Format("{0:hh:mm}", System.DateTime.Now);
        [DisplayName("ID")]
        public int IncidenciaID { get; set; }
        //[Required(ErrorMessage ="Seleccione una Unidad")]
        [DisplayName("Unidad")]
        public string UnidadAtencion { get; set; }
        [DisplayName("Tipo")]
        public string TipoIncidencia { get; set; }
        [DisplayName("SubTipo")]
        public string SubTipoIncidencia { get; set; }
        [DisplayName("Modalidad")]
        public string ModalidadIncidencia { get; set; }
        public string Usuario { get; set; }
        public string Turno { get; set; }
        public string Mancomunidad { get; set; }
        public string Distrito { get; set; }
        public string Semaforizacion { get; set; }
        //[StringLength(5, ErrorMessage ="La dirección no puede sobrepasar los 50 caracteres")]
        [DisplayName("Dirección")]
        public string DireccionIncidencia { get; set; }
        [DisplayName("Fuente")]
        public string FuenteInfo { get; set; }
        [DisplayName("Contacto")]
        public string ContactoIncidencia { get; set; }
        //[Phone]
        [DisplayName("Teléfono")]
        public string TelefonoContacto { get; set; }
        [DisplayName("Cargo")]
        public string CargoContacto { get; set; }
        [DisplayName("Institución")]
        public string InstitucionContacto { get; set; }
        [Required]
        [DisplayName("Descripción")]
        public string DescripcionIncidencia { get; set; }
        [DisplayName("Observaciones")]
        public string ObservacionIncidencia { get; set; }
        [DisplayName("Apoyo Interinstitucional")]
        public string ApoyoInter { get; set; }
        [DisplayName("El CiM fue el primer canal de atención")]
        public bool PrimerCanal { get; set; }
        [DisplayName("Fecha")]
        //[DataType(DataType.Date)]
        public string FechaIncidencia
        {
            get
            {
                return valueFecha;
            }
            set
            {
                valueFecha = value;
            }
        }
        //[DisplayName("Hora")]
        //public string HoraIncidencia { get; set; }
        [DisplayName("Hora")]
        public string HoraRegistroInc
        {
            get
            {
                return valueHora;
            }
            set
            {
                valueHora = value;
            }
        }
        [DisplayName("Estado")]
        public string EstadoIncidencia { get; set; }
        public string Evidencia1 { get; set; }
        public string Evidencia2 { get; set; }
        public string Evidencia3 { get; set; }
        //public virtual ICollection<IncHistorial> IncHistorial { get; set; }
    }
    public class IncidenciaDBContext : DbContext
    {
        //internal object inc;
        public DbSet<Incidencia> Incidencia { get; set; }
        //public DbSet<IncHistorial> IncHistorial { get; set; }
    }

}