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

//Hello World!


namespace Universidad.Controllers
{
    [BreadCrumb(Title = "Empleados", Url = "/Empleados/Index", Order = 0)]
    public class EmpleadosController : Controller
    {
        public static List<Empleados> empleados;
        // GET: EmpleadosController
        [BreadCrumb(Title = "Listado de Empleados", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                          string sortExpression = "nombre")
        {
            if (empleados == null)
            {
                empleados = new List<Empleados>()
                {
                    new Empleados()
                    {
                    Id=1, codigo=0102, cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Juan",apellido="Escolástico",sexo='M', estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano",religion="Católica", email="escolas@gmail.com",direccion="SFM",
                    salariomensual=3000,departamento="Ing. Sistemas",contactoemergencia="829921281",afp="Ing. Sistemas",
                    ars="Ing. Sistemas",observaciones="Overlook"
                    },
                       new Empleados()
                    {
                    Id=2, codigo=0102102, cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Yerson",apellido="Escolástico",sexo='M', estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano",religion="Católica", email="escolas@gmail.com",direccion="SFM",
                    salariomensual=3000,departamento="Ing. Sistemas",contactoemergencia="829921281",afp="Ing. Sistemas",
                    ars="Ing. Sistemas",observaciones="Overlook"
                    },   new Empleados()
                    {
                    Id=3, codigo=0102, cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Maria",apellido="Escolástico",sexo='M', estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano",religion="Católica", email="escolas@gmail.com",direccion="SFM",
                    salariomensual=3000,departamento="Ing. Sistemas",contactoemergencia="829921281",afp="Ing. Sistemas",
                    ars="Ing. Sistemas",observaciones="Overlook"
                    },   new Empleados()
                    {
                    Id=4, codigo=0102102, cedula="40211098",fechaNacimiento=DateTime.Now, fechaIngreso=DateTime.Now,
                    nombre="Pedro",apellido="Escolástico",sexo='M', estadoCivil="Soltero", ocupacion="Estudiante",
                    tipoSangre="O+",nacionalidad="Dominicano",religion="Católica", email="escolas@gmail.com",direccion="SFM",
                    salariomensual=3000,departamento="Ing. Sistemas",contactoemergencia="829921281",afp="Ing. Sistemas",
                    ars="Ing. Sistemas",observaciones="Overlook"
                    },
                };
            }
            List<Empleados> filtrada = empleados;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = empleados.FindAll(x => x.nombre.ToUpper().Contains(filter.ToUpper()));
            }

            var model = PagingList.Create(filtrada, 2, page, sortExpression, "nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: EmpleadosController/Details/5
        [BreadCrumb(Title = "Detalle de Empleados", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = empleados.Find(x => x.Id == id);

            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: EmpleadosController/Create
        [BreadCrumb(Title = "Crear Empleados", Order = 1)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleados modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EmpleadosController/Edit/5
        [BreadCrumb(Title = "Editar Empleados", Order = 1)]
        public ActionResult Edit(int id)
        {
            var modelo = empleados.Find(x => x.Id == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleados modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = empleados.FindIndex(x => x.Id == modelo.Id);
                    empleados[indice] = modelo;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EmpleadosController/Delete/5
        [BreadCrumb(Title = "Eliminar Empleados", Order = 1)]
        public ActionResult Delete(int id)
        {
            var modelo = empleados.Find(x => x.Id == id);

            if (modelo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleados modelo)
        {
            try
            {
                int indice = empleados.FindIndex(x => x.Id == modelo.Id);
                empleados.RemoveAt(indice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelo);
            }
        }
    }
}
