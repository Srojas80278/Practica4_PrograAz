using ApiPractica4.entities;
using ApiPractica4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPractica4.Controllers
{
    public class Practica4Controller : ApiController
    {
        [HttpGet]
        [Route("ConsultarProductos")]
        public List<SP_ORDENADO_Result> ConsultarProductos() //Retornamos el resultado de el SP.
        {
            using (var contexto = new PracticaS12Entities())
            {
                return contexto.SP_ORDENADO().ToList();
                //To List permite devolver en una lista de objetos en formato JSON.
            }
        }


        [HttpGet]
        [Route("ConsultarPendientes")]
        public List<SP_ProductosPendientes_Result> ConsultarPendientes() 
        {
            using (var contexto = new PracticaS12Entities())
            {
                return contexto.SP_ProductosPendientes().ToList();
            }
        }

        [HttpGet]
        [Route("ConsultarProducto")]
        public SP_ConsultarProducto_Result ConsultarProducto(int idCompra)
        {
            using (var contexto = new PracticaS12Entities())
            {
                // Llama al procedimiento almacenado con el parámetro Id_Compra
                var resultado = contexto.SP_ConsultarProducto(idCompra).FirstOrDefault();

                return resultado;
            }
        }


        [HttpPost]
        [Route("RegistrarAbono")]
        public string RegistrarAbonoSP(AbonosEntidad entidad)
        {
            using (var context = new PracticaS12Entities())
            {
                context.RegistrarAbonoSP(entidad.Id_Compra, entidad.Monto);
                return "OK";
            }
        }

    }
}
