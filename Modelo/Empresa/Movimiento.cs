using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Empresa
{
    public class Movimiento : IDBEntity
    {
        public int MovimientoId { get; set; }
        public string TipoMovimiento { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<Pedido> Pedidos { get; set; }

        #nullable enable
        public DateTime? FechaFin { get; set; }

    }
}
