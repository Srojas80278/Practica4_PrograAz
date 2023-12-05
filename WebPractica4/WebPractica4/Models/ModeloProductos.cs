using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using WebPractica4.Entities;
using System.Net.Http.Json;


namespace WebPractica4.Models
{
    public class ModeloProductos
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public List<ProductosEntidad>ConsultarProductos()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarProductos";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<ProductosEntidad>>().Result;
            }
        }


        public List<ProductosEntidad> ConsultarPendientes()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarPendientes";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<ProductosEntidad>>().Result;
            }
        }

        public string RegistrarAbono(AbonosEntidad entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarAbono";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}