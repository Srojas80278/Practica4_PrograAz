﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPractica4.entities
{
    public class ProductosEntidad
    {
            public long Id_Compra { get; set; }
            public decimal Precio { get; set; }
            public decimal Saldo { get; set; }
            public string Descripcion { get; set; }
            public string Estado { get; set; }
    }
}