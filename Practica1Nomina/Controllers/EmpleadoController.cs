using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Nomina.Models;

namespace Practica1Nomina.Controllers
{
    public class EmpleadoController : Controller
    {
        //Primero crear un listado de empleados.
        public static List<Empleado> empleados = new List<Empleado>();
        // GET: EmpleadoController
        public ActionResult Index()
        {
            return View(empleados);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado is null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: EmpleadoController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado empleado)
        {
            empleado.Id = empleados.Count + 1;
            empleados.Add(empleado);
            return RedirectToAction("Index");
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);

            if (empleado is null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado empleado)
        {
            var empleadoExiste = empleados.FirstOrDefault(e => e.Id == id);
            if (empleadoExiste is null)
            {
                return NotFound();
            }

            empleadoExiste.Nombre = empleado.Nombre;
            empleadoExiste.Apellido = empleado.Apellido;
            empleadoExiste.Edad = empleado.Edad;
            empleadoExiste.FechaNacimiento = empleado.FechaNacimiento;
            empleadoExiste.Sexo = empleado.Sexo;
            empleadoExiste.Salario = empleado.Salario;
            empleadoExiste.Direccion.Pais = empleado.Direccion.Pais;
            empleadoExiste.Direccion.Provincia = empleado.Direccion.Provincia;
            empleadoExiste.Direccion.Municipio = empleado.Direccion.Municipio;
            empleadoExiste.Direccion.Sector = empleado.Direccion.Sector;
            empleadoExiste.Licencia = empleado.Licencia;

            return RedirectToAction("Index");
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado empleado)
        {
            var empleadoExiste = empleados.FirstOrDefault(e => e.Id == id);
            if (empleadoExiste is null)
            {
                return NotFound();
            }

            empleados.Remove(empleadoExiste);
            return RedirectToAction("Index");
        }
    }
}
