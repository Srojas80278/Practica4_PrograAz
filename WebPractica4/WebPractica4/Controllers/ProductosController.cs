using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPractica4.Entities;
using WebPractica4.Models;

namespace WebPractica4.Controllers
{
    public class ProductosController : Controller
    {
        ModeloProductos ProductoModelo = new ModeloProductos();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = ProductoModelo.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult RegistrarAbono()
        {
            var datos = ProductoModelo.ConsultarPendientes();
            return View(datos);
        }

        [HttpPost]
        public ActionResult RegistrarAbono(int id_compra, decimal dineroAbonar)
        {
            // Crear una instancia de AbonosEntidad con los valores recibidos
            var entidad = new AbonosEntidad
            {
                Id_Compra = id_compra,
                Monto = dineroAbonar
                // Asegúrate de que AbonosEntidad tenga propiedades Id_Compra y Dinero_Abonar
            };

            var datos = ProductoModelo.RegistrarAbono(entidad);
            return RedirectToAction("ConsultarProductos");
        }

    }
}
