using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Nomina.Comun.Interfaz;
using Practica1Nomina.Models;

namespace Practica1Nomina.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServices empleadoServices;
        private readonly IMapper mapper;
        private readonly ILogger<EmpleadoController> logger;


        public EmpleadoController(IEmpleadoServices empleadoServices,
            IMapper mapper,
            ILogger<EmpleadoController> logger)
        {
            this.empleadoServices = empleadoServices;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Empleados = await empleadoServices.ObtenerEmpleados();

            return View();
        }

        public async Task<IActionResult> Crear(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Municipio = await empleadoServices.ObtenerListaDeMunicipios(0);
                ViewBag.Pais = await empleadoServices.ObtenerListaDePaises("DO");
                ViewBag.Provincia = await empleadoServices.ObtenerListaDeProvincias(0);
                ViewBag.Sector = await empleadoServices.ObtenerListaDeSectores(0);
                return View(new Empleado());
            }
            else
            {
                var empleadoExistente = await empleadoServices.ObtenerEmpleadosPorId(id);
                if (empleadoExistente == null)
                {
                    return NotFound();
                }
                // Asegúrate de que estás utilizando el tipo de modelo correcto en la vista
                return View(empleadoExistente);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Crear(int id, Empleado formularioEmpleados)
        {
            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    var resultado = mapper.Map<Empleado>(formularioEmpleados);
                    await empleadoServices.AgregarEmpleado(resultado);
                }
                else
                {
                    var resultado = mapper.Map<Empleado>(formularioEmpleados);
                    await empleadoServices.ActualizarEmpleado(resultado);

                }
                return View("Index");
               /* return Json(new { isValid = true, html = Helper.Helper.RenderRazorViewToString(this, "Index", empleadoServices.ObtenerEmpleados()) });*/
            }
            return Json(new { isValid = false, html = Helper.Helper.RenderRazorViewToString(this, "Index", formularioEmpleados) });

        }

       /* [HttpPost]
        public async Task<IActionResult> Crear(Empleado formularioEmpleados)
        {
            if (ModelState.IsValid)
            {
                var resultado = mapper.Map<Empleado>(formularioEmpleados);
                await empleadoServices.AgregarEmpleado(resultado);

                return RedirectToAction("Index");
            }


            return Json(new { sucess = true, message = "Empleado creado existosamente" });
        }
       */
        public async Task<IActionResult> Editar(int id)
        {
            var empleado = await empleadoServices.ObtenerEmpleadosPorId(id);
            if (empleado == null)
            {
                return View("Error");
            }
            ViewBag.Municipio = await empleadoServices.ObtenerListaDeMunicipios(0);
            ViewBag.Pais = await empleadoServices.ObtenerListaDePaises("DO");
            ViewBag.Provincia = await empleadoServices.ObtenerListaDeProvincias(0);
            ViewBag.Sector = await empleadoServices.ObtenerListaDeSectores(0);
            var empleadoDTO = mapper.Map<Empleado>(empleado);
            return View(empleadoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Empleado formularioEmpleados)
        {
            if (id != formularioEmpleados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var empleadoActualizado = mapper.Map<Empleado>(formularioEmpleados);
                await empleadoServices.ActualizarEmpleado(empleadoActualizado);
                return RedirectToAction("Index");
            }

            ViewBag.Municipio = await empleadoServices.ObtenerListaDeMunicipios(0);
            ViewBag.Pais = await empleadoServices.ObtenerListaDePaises("DO");
            ViewBag.Provincia = await empleadoServices.ObtenerListaDeProvincias(0);
            ViewBag.Sector = await empleadoServices.ObtenerListaDeSectores(0);

            return View(formularioEmpleados);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await empleadoServices.ObtenerEmpleadosPorId(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await empleadoServices.EliminarEmpleado(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MostrarEmpleadoModal()
        {
            return PartialView("_formularioCrearEmpleado");
        }
    }
}