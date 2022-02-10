using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Empresa
{
    public class Pedido : IDBEntity
    {
        public int PedidoId { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public Movimiento Movimiento { get; set; }

        public int MovimientoId { get; set; }
        public int Cantidad { get; set; }
    }
}


