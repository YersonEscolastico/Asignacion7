using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ucne.Models;
using DNTBreadCrumb.Core;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Universidad.Controllers
{
    [BreadCrumb(Title = "Profesores", Url = "/Profesores/Index", Order = 0)]
    public class ProfesoresController : Controller
    {
        private readonly IOptions<GlobalSettings> _gSettings;
        public ProfesoresController(IOptions<GlobalSettings> gSettings)
        {
            _gSettings = gSettings;
        }

        public static List<Profesores> profesores;

        // GET: ProfesoresController
        [BreadCrumb(Title = "Listado de Profesores", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                          string sortExpression = "nombre")
        {
            ViewBag.NombreCompania = _gSettings.Value.NombreCompania;
            _gSettings.Value.TelefonoCompania = "!2413241";
            _gSettings.Value.NombreCompania = "Probando el Cambio de Nombre";

            if (profesores == null)
            {
                profesores = new List<Profesores>() {

                    new Profesores() {
                    Id=1,codigo=0102102,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Yerson", apellido="Escolástico",sexo='M', estadoCivil="Soltero",ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com", direccion="SFM",
                    carrera="Sistemas", mayorgradoacademico="Ing. Sistemas",categoriaprofesional="Ing. Sistemas",facultad="Ing. Sistemas",
                    asignaturas="Ing. Sistemas",observaciones="Overlook"
                    },
                       new Profesores() {
                    Id=2,codigo=0102102,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Yerson", apellido="Escolástico",sexo='M', estadoCivil="Soltero",ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com", direccion="SFM",
                    carrera="Sistemas", mayorgradoacademico="Ing. Sistemas",categoriaprofesional="Ing. Sistemas",facultad="Ing. Sistemas",
                    asignaturas="Ing. Sistemas",observaciones="Overlook"
                    },
                          new Profesores() {
                    Id=3,codigo=0102102,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Yerson", apellido="Escolástico",sexo='M', estadoCivil="Soltero",ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com", direccion="SFM",
                    carrera="Sistemas", mayorgradoacademico="Ing. Sistemas",categoriaprofesional="Ing. Sistemas",facultad="Ing. Sistemas",
                    asignaturas="Ing. Sistemas",observaciones="Overlook"
                    },
                             new Profesores() {
                    Id=4,codigo=0102102,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Yerson", apellido="Escolástico",sexo='M', estadoCivil="Soltero",ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com", direccion="SFM",
                    carrera="Sistemas", mayorgradoacademico="Ing. Sistemas",categoriaprofesional="Ing. Sistemas",facultad="Ing. Sistemas",
                    asignaturas="Ing. Sistemas",observaciones="Overlook" }
                };
            }
            List<Profesores> filtrada = profesores;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = profesores.FindAll(x => x.nombre.ToUpper().Contains(filter.ToUpper()));
            }
            var model = PagingList.Create(filtrada, 2, page, sortExpression, "nombre");
            model.RouteValue = new RouteValueDictionary{

                {"filter", filter }
            };

            model.Action = "Index";
            return View(model);
        }

        // GET: ProfesoresController/Details/5
        [BreadCrumb(Title = "Detalle de Profesores", Order = 2)]
        public ActionResult Details(int id)
        {

            var modelo = profesores.Find(x => x.Id == id);
            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: ProfesoresController/Create
        [BreadCrumb(Title = "Crear nuevo Profesor", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesores modelo)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    profesores.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: ProfesoresController/Edit/5
        [BreadCrumb(Title = "Editar Profesor", Order = 4)]
        public ActionResult Edit(int id)
        {
            var modelo = profesores.Find(x => x.Id == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: ProfesoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profesores modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = profesores.FindIndex(x => x.Id == modelo.Id);
                    profesores[indice] = modelo;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: ProfesoresController/Delete/5
        [BreadCrumb(Title = "Eliminar Profesor", Order = 5)]
        public ActionResult Delete(int id)
        {
            var modelo = profesores.Find(x => x.Id == id);

            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: ProfesoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Profesores modelo)
        {

            try
            {
                int indice = profesores.FindIndex(x => x.Id == modelo.Id);
                profesores.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}
