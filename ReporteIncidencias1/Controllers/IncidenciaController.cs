using Microsoft.Ajax.Utilities;
using ReporteIncidencias1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReporteIncidencias1.Controllers
{
    public class IncidenciaController : Controller
    {
        IncidenciaDBContext db = new IncidenciaDBContext();
        //IncHistorialDBContext dbh = new IncHistorialDBContext();
        // GET: Incidencia
        /*public ActionResult Index()
        {
            return View(db.Incidencia.ToList());
        }*/
        //public ActionResult Buscar(string nombre)
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index(string nombre)
        {
            var busqueda = from e in db.Incidencia select e;
            if(!String.IsNullOrEmpty(nombre))
            {
                /*busqueda = busqueda.Where(e => e.UnidadAtencion.Contains(nombre) || e.TipoIncidencia.Contains(nombre) || e.SubTipoIncidencia.Contains(nombre)
                 || e.ModalidadIncidencia.Contains(nombre) || e.Usuario.Contains(nombre) || e.Turno.Contains(nombre)
                  || e.Mancomunidad.Contains(nombre) || e.Distrito.Contains(nombre) || e.Semaforizacion.Contains(nombre)
                   || e.DireccionIncidencia.Contains(nombre) || e.FuenteInfo.Contains(nombre) || e.ContactoIncidencia.Contains(nombre)
                    || e.TelefonoContacto.Contains(nombre) || e.CargoContacto.Contains(nombre) || e.InstitucionContacto.Contains(nombre)
                     || e.DescripcionIncidencia.Contains(nombre) || e.ObservacionIncidencia.Contains(nombre) || e.ApoyoInter.Contains(nombre)
                      || e.FechaIncidencia.Contains(nombre) || e.HoraRegistroInc.Contains(nombre) || e.EstadoIncidencia.Contains(nombre));*/
                
                //--------------------------------------------

                busqueda = busqueda.Where(e => e.UnidadAtencion.Contains(nombre) || e.TipoIncidencia.Contains(nombre) || e.Mancomunidad.Contains(nombre)
                 || e.Distrito.Contains(nombre) || e.Semaforizacion.Contains(nombre) || e.FuenteInfo.Contains(nombre)
                  || e.FechaIncidencia.Contains(nombre) || e.EstadoIncidencia.Contains(nombre));
            }
            return View(busqueda.ToList());
        }
        public ActionResult Priorizar()
        {
            var Clientes = from e in db.Incidencia
                           orderby e.Semaforizacion
                           select e;
            return View(Clientes);
        }

        // GET: Incidencia/Details/5
        public ActionResult Details(int id)
        {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Incidencia inc = db.Incidencia.Find(id);
                if (inc == null)
                {
                    return HttpNotFound();
                }
                return View(inc);
        }

        // GET: Incidencia/Create
        public ActionResult Create()
        {
            List<string> ListaUnidad = new List<string>();
            ListaUnidad.Add("Seleccionar");
            ListaUnidad.Add("Seguridad Ciudadana");
            ListaUnidad.Add("Fiscalización");
            ListaUnidad.Add("Seguridad Vial");
            ListaUnidad.Add("Desarrollo Humano");
            ListaUnidad.Add("Defensa Civil");
            ListaUnidad.Add("Ambientes y Desastres Naturales");
            ListaUnidad.Add("Apoyo al Turista");
            ListaUnidad.Add("Obras y Servicios Públicos");
            ListaUnidad.Add("Violencia Contra la Mujer y/o integrantes del grupo familiar");
            ListaUnidad.Add("Vigilancia y Control Sanitario");

            List<string> ListaMancomunidad = new List<string>();
            ListaMancomunidad.Add("Seleccionar");
            ListaMancomunidad.Add("Lima Norte");
            ListaMancomunidad.Add("Lima Centro 1");
            ListaMancomunidad.Add("Lima Centro 2");
            ListaMancomunidad.Add("Lima Este");
            ListaMancomunidad.Add("Lima Sur");
            SelectList Distrito = new SelectList(ListaMancomunidad);
            //ver
            SelectList Tipos = new SelectList(ListaUnidad);

            List<string> ListaSemaforizacion = new List<string>();
            ListaSemaforizacion.Add("Seleccionar");
            ListaSemaforizacion.Add("Rojo");
            ListaSemaforizacion.Add("Verde");
            ListaSemaforizacion.Add("Amarillo");
            ListaSemaforizacion.Add("Azul");
            SelectList Semaforizacion = new SelectList(ListaSemaforizacion);

            List<string> ListFuenteInfo = new List<string>();
            ListFuenteInfo.Add("Seleccionar");
            ListFuenteInfo.Add("Bomberos");
            ListFuenteInfo.Add("Cámaras CECOP");
            ListFuenteInfo.Add("Informe de Tv");
            ListFuenteInfo.Add("Diario Online");
            ListFuenteInfo.Add("Despachador Tetra");
            ListFuenteInfo.Add("Llamada Telefónica");
            ListFuenteInfo.Add("Whatsapp");
            ListFuenteInfo.Add("Facebook - Pag. 3ros");
            ListFuenteInfo.Add("Facebook - Pag. Oficial");
            ListFuenteInfo.Add("Twitter");
            ListFuenteInfo.Add("SoSafe");
            ListFuenteInfo.Add("Otros");
            SelectList FuenteI = new SelectList(ListFuenteInfo);

            List<string> ListTurno = new List<string>();
            ListTurno.Add("Seleccionar");
            ListTurno.Add("Diurno (07:00 - 16:00");
            ListTurno.Add("Nocturno (16:01 - 06:59)");
            SelectList Turno = new SelectList(ListTurno);

            List<string> ListaEstado = new List<string>();
            ListaEstado.Add("Seleccionar");
            ListaEstado.Add("En progreso");
            ListaEstado.Add("Atendido");
            ListaEstado.Add("Cerrado");
            SelectList Estado = new SelectList(ListaEstado);

            List<string> ListaApoyo = new List<string>();
            ListaApoyo.Add("Seleccionar");
            ListaApoyo.Add("Cisternas");
            ListaApoyo.Add("Patrullas");
            ListaApoyo.Add("Ambulancias");
            ListaApoyo.Add("Apoyo de Sedapal");
            ListaApoyo.Add("Apoyo de Enel / Luz del Sur");
            ListaApoyo.Add("Apoyo de Unidad de Bomberos");
            ListaApoyo.Add("Coordinación con CEM de distrito aldeaño");
            ListaApoyo.Add("Otro (Especifique)");
            SelectList Apoyo = new SelectList(ListaApoyo);

            ViewData["ApoyoI"] = Apoyo;
            ViewData["Estado"] = Estado;
            ViewData["Turno"] = Turno;
            ViewData["FuenteInfo"] = FuenteI;
            ViewData["Semaforizacion"] = Semaforizacion;
            ViewData["Distrito"] = Distrito;
            ViewData["Tipos"] = Tipos;
            return View();
        }

        // POST: Incidencia/Create
        [HttpPost]
        public ActionResult Create(Incidencia i)
        {
            try
            {
                //TempData["request"] = i.request;
                // TODO: Add insert logic here
                db.Incidencia.Add(i);
                db.SaveChanges();
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult Distrito(string Mancomunidad)
        {
            List<string> ListDistritos = new List<string>();
            switch (Mancomunidad)
            {
                case "Lima Norte":
                    ListDistritos.Add("SELECCIONAR");
                    ListDistritos.Add("ANCON");
                    ListDistritos.Add("CARABAYLLO");
                    ListDistritos.Add("COMAS");
                    ListDistritos.Add("INDEPENDENCIA");
                    ListDistritos.Add("LOS OLIVOS");
                    ListDistritos.Add("PUENTE PIEDRA");
                    ListDistritos.Add("SAN MARTIN DE PORRES");
                    ListDistritos.Add("SANTA ROSA");
                    break;
                case "Lima Centro 1":
                    ListDistritos.Add("SELECCIONAR");
                    ListDistritos.Add("SAN ISIDRO");
                    ListDistritos.Add("SANTIAGO DE SURCO");
                    ListDistritos.Add("SURQUILLO");
                    ListDistritos.Add("BARRANCO");
                    ListDistritos.Add("SAN BORJA");
                    ListDistritos.Add("MAGDALENA DEL MAR");
                    ListDistritos.Add("MIRAFLORES");
                    ListDistritos.Add("CHORRILLOS");
                    break;
                case "Lima Centro 2":
                    ListDistritos.Add("SELECCIONAR");
                    ListDistritos.Add("LIMA");
                    ListDistritos.Add("LA VICTORIA");
                    ListDistritos.Add("RIMAC");
                    ListDistritos.Add("BREÑA");
                    ListDistritos.Add("JESUS MARIA");
                    ListDistritos.Add("PUEBLO  LIBRE");
                    ListDistritos.Add("SAN MIGUEL");
                    ListDistritos.Add("LINCE");
                    break;
                case "Lima Este":
                    ListDistritos.Add("SELECCIONAR");
                    ListDistritos.Add("SAN JUAN DE LURIGANCHO");
                    ListDistritos.Add("SAN LUIS");
                    ListDistritos.Add("SANTA ANITA");
                    ListDistritos.Add("ATE");
                    ListDistritos.Add("LA MOLINA");
                    ListDistritos.Add("EL AGUSTINO");
                    ListDistritos.Add("CIENEGUILLA");
                    ListDistritos.Add("LURIGANCHO - CHOSICA");
                    ListDistritos.Add("CHACLACAYO");
                    break;
                case "Lima Sur":
                    ListDistritos.Add("SELECCIONAR");
                    ListDistritos.Add("LURIN");
                    ListDistritos.Add("PACHACAMAC");
                    ListDistritos.Add("PUCUSANA");
                    ListDistritos.Add("PUNTA HERMOSA");
                    ListDistritos.Add("PUNTA NEGRA");
                    ListDistritos.Add("SAN BARTOLO");
                    ListDistritos.Add("SAN JUAN DE MIRAFLORES");
                    ListDistritos.Add("SANTA MARIA DEL MAR");
                    ListDistritos.Add("VILLA EL SALVADOR");
                    ListDistritos.Add("VILLA MARIA DEL TRIUNFO");
                    break;
            }
            return Json(ListDistritos);
        }
       
        public JsonResult Tipos(string Unidad)
        {
            List<string> ListTipos = new List<string>();
            switch (Unidad)
            {
                case "Seguridad Ciudadana":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("ACCIDENTES DE TRANSITO");
                    ListTipos.Add("HECHO CONTRA LA VIDA EL CUERPO Y LA SALUD");
                    ListTipos.Add("HECHO CONTRA LA LIBERTAD");
                    ListTipos.Add("HECHO CONTRA EL PATRIMONIO");
                    ListTipos.Add("OTROS HECHOS CONTRA EL PATRIMONIO");
                    ListTipos.Add("HECHOS CONTRA LA SEGURIDAD PÚBLICA");
                    ListTipos.Add("HECHOS CONTRA LA HUMANIDAD");
                    ListTipos.Add("SOSPECHOSOS");
                    ListTipos.Add("PATRULLAJES");
                    ListTipos.Add("OPERATIVOS");
                    ListTipos.Add("APOYO AL CONTRIBUYENTE");
                    break;
                case "Fiscalización":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("ORDEN PÚBLICO");
                    ListTipos.Add("RUIDOS MOLESTOS");
                    break;
                case "Seguridad Vial":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("VEHICULOS MAL ESTACIONADOS");
                    ListTipos.Add("VEHICULOS APARENTEMENTE ABANDONADOS");
                    ListTipos.Add("PARADERO INFORMAL");
                    ListTipos.Add("TRANSPORTE PUBLICO FUERA DE RUTA");
                    ListTipos.Add("TRANSPORTE PUBLICO INFORMAL ");
                    ListTipos.Add("PIQUES Y/O CARRERAS ILEGALES ");
                    ListTipos.Add("CONGESTION VEHICULAR");
                    ListTipos.Add("SEMAFOROS INOPERATIVOS");
                    ListTipos.Add("FALTA DE SEÑALIZACION EN SEGURIDAD VIAL");
                    break;
                case "Desarrollo Humano":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("ATENCION A ORATE");
                    ListTipos.Add("ATENCION A MENOR MENDIGANDO Y/O VENDIENDO");
                    ListTipos.Add("PERSONA EN ESTADO DE ABANDONO ");
                    break;
                case "Defensa Civil":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("VIVIENDAS EN PELIGRO DE COLAPSO Y/O DERRUMBES");
                    ListTipos.Add("INMUEBLE ABANDONADO / INHABITABLE ");
                    ListTipos.Add("DEPOSITOS DE ALTO RIESGO");
                    ListTipos.Add("PELIGRO POR MATERIAL INFLAMABLE,EXPLOSIVOS Y TOXICOS");
                    ListTipos.Add("OBSTACULIZAR LIBRE TRANSITO EN INMUEBLES");
                    ListTipos.Add("INCENDIO");
                    ListTipos.Add("AFORO");
                    break;
                case "Ambientes y Desastres Naturales":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("HUAICOS Y DESLIZAMIENTOS");
                    ListTipos.Add("INUNDACIÓN");
                    ListTipos.Add("HUMOS Y/O OLORES ");
                    break;
                case "Apoyo al Turista":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("ORIENTACION");
                    ListTipos.Add("APOYO MEDICO");
                    ListTipos.Add("ORATES");
                    ListTipos.Add("SITUACION PRECARIA");
                    ListTipos.Add("DESORDEN EN VIA PUBLICA");
                    ListTipos.Add("COMERCIO AMBULATORIO");
                    break;
                case "Obras y Servicios Públicos":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("ARROJO DE BASURA, DESMONTE Y/O MALEZA");
                    ListTipos.Add("ANIEGOS");
                    ListTipos.Add("BUZON SIN TAPA ");
                    ListTipos.Add("ENSUCIAR LA VIA PUBLICA POR REALIZAR NECESIDADES FISIOLOGICAS ");
                    ListTipos.Add("PODA DE ARBOLES Y JARDINES");
                    ListTipos.Add("DEPOSICIONES DE LOS ANIMALES");
                    ListTipos.Add("INFRAESTRUCTURA PUBLICA DETERIORADA ");
                    ListTipos.Add("ZONAS DE POCA ILUMINACION");
                    ListTipos.Add("CAIDA DE OBJETOS CONTUNDENTES ");
                    break;
                case "Violencia Contra la Mujer y/o integrantes del grupo familiar":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("VIOLENCIA ECONÓMICA Y PATRIMONIAL");
                    ListTipos.Add("VIOLENCIA FISICA ");
                    ListTipos.Add("VIOLENCIA SEXUAL");
                    ListTipos.Add("VIOLENCIA PSICOLOGICA");
                    break;
                case "Vigilancia y Control Sanitario":
                    ListTipos.Add("Seleccionar");
                    ListTipos.Add("LUGAR DE VENTA DE ALIMENTOS SIN CONTROL SANITARIO");
                    ListTipos.Add("ESTABLECIMIENTO COMERCIAL SIN CONDICIONES DE SALUBRIDAD");
                    break;
            }
            return Json(ListTipos);
        }
        // GET: Incidencia/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencia inc = db.Incidencia.Find(id);
            if (inc == null)
            {
                return HttpNotFound();
            }
            return View(inc);
        }

        // POST: Incidencia/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IncidenciaID,UnidadAtencion,TipoIncidencia,SubTipoIncidencia,ModalidadIncidencia,Usuario,Turno,Mancomunidad,Distrito,Semaforizacion,DireccionIncidencia,FuenteInfo,ContactoIncidencia,TelefonoContacto,CargoContacto,InstitucionContacto,DescripcionIncidencia,ObservacionIncidencia,ApoyoInter,PrimerCanal,HoraIncidencia,EstadoIncidencia")] Incidencia inc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inc);
        }

        // GET: Incidencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencia inc = db.Incidencia.Find(id);
            if (inc == null)
            {
                return HttpNotFound();
            }
            return View(inc);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incidencia inc = db.Incidencia.Find(id);
            db.Incidencia.Remove(inc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
