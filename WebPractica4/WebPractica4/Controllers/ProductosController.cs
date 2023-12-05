using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}
