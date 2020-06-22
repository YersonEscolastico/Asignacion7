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

namespace Universidad.Controllers
{
    [BreadCrumb(Title = "Estudiantes", Url = "/Estudiantes/Index", Order = 0)]

    public class EstudiantesController : Controller
    {
        public static List<Estudiantes> estudiantes;

        // GET: EstudianteController
        [BreadCrumb(Title = "Listado de Estudiantes", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                          string sortExpression = "nombre")
        {
            if (estudiantes == null)
            {
                estudiantes = new List<Estudiantes>()
                {
                    new Estudiantes(){
                     Id=1,matricula=20160497,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,nombre="Yerson",
                    apellido="Escolástico", sexo='M',  estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+", nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com",
                    nombrePadre="Juan perez", nombreMadre="Juana perez", direccion="SFM", tipoColegio="Private",
                    carrera="Ing. Sistemas", observaciones="Overlook" },

                     new Estudiantes() {
                    Id = 2, matricula = 20160497, cedula = "40211098", fechaNacimiento = DateTime.Now, fechaIngreso = DateTime.Now, nombre = "Yerson",
                    apellido = "Escolástico", sexo = 'M', estadoCivil = "Soltero", ocupacion = "Estudiante",
                    tipoSangre = "O+", nacionalidad = "Dominicano", religion = "Católica", email = "escolas@gmail.com",
                    nombrePadre = "Juan perez", nombreMadre = "Juana perez", direccion = "SFM", tipoColegio = "Private",
                    carrera = "Ing. Sistemas", observaciones = "Overlook" },

                        new Estudiantes(){
                     Id=3,matricula=20160497,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,nombre="Yersonnnn",
                    apellido="Escolástico", sexo='M',  estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+", nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com",
                    nombrePadre="Juan perez", nombreMadre="Juana perez", direccion="SFM", tipoColegio="Private",
                    carrera="Ing. Sistemas", observaciones="Overlook" },

                     new Estudiantes(){
                     Id=4, matricula=20160497,cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,nombre="Yerson",
                    apellido="Escolástico", sexo='M',  estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+", nacionalidad="Dominicano", religion="Católica",email="escolas@gmail.com",
                    nombrePadre="Juan perez", nombreMadre="Juana perez", direccion="SFM", tipoColegio="Private",
                    carrera="Ing. Sistemas", observaciones="Overlook" }


                };
            }

            List<Estudiantes> filtrada = estudiantes;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = estudiantes.FindAll(x => x.nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 2, page, sortExpression, "nombre");
            model.RouteValue = new RouteValueDictionary{
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: EstudianteController/Details/5
        [BreadCrumb(Title = "Detalle de Estudiantes", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = estudiantes.Find(x => x.Id == id);

            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: EstudianteController/Create
        [BreadCrumb(Title = "Crear Estudiantes", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiantes modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estudiantes.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EstudianteController/Edit/5
        [BreadCrumb(Title = "Editar Estudiantes", Order = 4)]
        public ActionResult Edit(int id)
        {
            var modelo = estudiantes.Find(x => x.Id == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estudiantes modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = estudiantes.FindIndex(x => x.Id == modelo.Id);
                    estudiantes[indice] = modelo;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EstudianteController/Delete/5
        [BreadCrumb(Title = "Eliminar Esudiante", Order = 5)]
        public ActionResult Delete(int id)
        {
            var modelo = estudiantes.Find(x => x.Id == id);

            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: EstudianteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Estudiantes modelo)
        {
            try
            {
                int indice = estudiantes.FindIndex(x => x.Id == modelo.Id);
                estudiantes.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}
