using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPractica4.Entities
{
    public class AbonosEntidad
    {
        public long Id_Compra { get; set; }
        public long Id_Abono { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        
    }
}