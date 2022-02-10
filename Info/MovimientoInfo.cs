using Modelo;
using Modelo.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class MovimientoInfo
    {
        public static void mostrarMovimiento(Movimiento movimiento)
        {
            string mensaje = String.Format(
                "ID: {0}\t Tipo de Movimiento: {1}\t Estado: {2} Fecha de inicio: {3}\t Fecha de fin: {4} ",
                movimiento.MovimientoId,
                movimiento.TipoMovimiento,
                movimiento.Estado,
                movimiento.FechaInicio,
                movimiento.FechaFin.HasValue ? movimiento.FechaFin : "------"

            );
            Console.WriteLine(mensaje);
            PedidoInfo.mostrarPedidos(movimiento.Pedidos);
            Console.WriteLine("");
        }

        public static void mostrarMovimientos(List<Movimiento> lista)
        {
            Console.WriteLine("\t\t -Movimientos-");
            foreach (Movimiento movimiento in lista)
            {
                mostrarMovimiento(movimiento);
            }


        }
    }
}
