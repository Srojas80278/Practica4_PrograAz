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



    }
}
