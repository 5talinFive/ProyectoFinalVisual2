using Modelo.Empresa;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Procesos
{
    public class MovimientoPro
    {

        // Estados de movimiento
        //PENDIENTE
        //COMPLETADO
        //RECHAZADO

        // Tipos de movimiento
        //SALIDA
        //ENTRADA
        public static string procesarMovimiento(int idMovimiento)
        {
            using (var db = new StockContext())
            {
                //Cargamos el movimiento con el idMovimiento
                Movimiento movimiento = db.Movimiento
                    .Include(mov => mov.Pedidos)
                    .Where(mov => mov.MovimientoId == idMovimiento)
                    .Single();

                //Hacemos verificacion de si el movimiento fue encontrado
                if (movimiento != null)
                {
                    //Verificamos si el estado es completado o rechazado, no se puede procesar
                    if (movimiento.Estado == "completado")
                    {
                        return "El movimiento ya fue completado, no se puede procesar";
                    }

                    if (movimiento.Estado == "rechazado")
                    {
                        return "El movimiento fue rechazado, no se puede procesar";
                    }

                    // En caso de que la lista de pedidos este vacia no se puede procesar
                    if (movimiento.Pedidos.Count() == 0)
                    {
                        movimiento.FechaFin = DateTime.Now;
                        movimiento.Estado = "rechazado";
                        db.SaveChanges();
                        return "El movimiento no tiene pedidos, no se puede procesar";
                    }
                    //Cargamos los pedidos del movimiento en una lista
                    List<Pedido> pedidos = movimiento.Pedidos;

                    //Verificamos el tipo de movimiento
                    if (movimiento.TipoMovimiento == "salida")
                    {
                        // Lista de booleanos para verificar si existe suficiente stock
                        List<Boolean> listaVerificacion = new List<Boolean>();

                        foreach (Pedido pedido in pedidos)
                        {
                            //Agregamos el resultado de la verificacion a una lista de booleanos
                            listaVerificacion.Add(PedidoPro.procesarPedidoSalida(pedido));
                        }
                        //[true,true,true,false]
                        //Esta verificacion sirve para revisar que todos los productos tienen la cantidad suficiente
                        if (listaVerificacion.All(elem => elem == true))
                        {
                            //Se procesa la resta de los productos al stock
                            foreach (Pedido pedido in pedidos)
                            {
                                ProductoPro.retirarProducto(pedido.ProductoId, pedido.Cantidad);
                            }
                            movimiento.FechaFin = DateTime.Now;
                            movimiento.Estado = "completado";
                            try
                            {
                                db.SaveChanges();
                                return "El movimiento de salida fue procesado con exito, los productos se restaron del stock";

                            }
                            catch (DbUpdateConcurrencyException exception)
                            {
                                Exception ex = new Exception("Conficto de concurrencia", exception);
                                throw ex;
                            }
                        }
                        movimiento.FechaFin = DateTime.Now;
                        movimiento.Estado = "rechazado";
                        try
                        {
                            db.SaveChanges();
                            return "El movimiento fue rechazado, no existe suficiente stock de productos para satisfacer los pedidos";

                        }
                        catch (DbUpdateConcurrencyException exception)
                        {
                            Exception ex = new Exception("Conficto de concurrencia", exception);
                            throw ex;
                        }

                    }

                    if (movimiento.TipoMovimiento == "entrada")
                    {
                        foreach (Pedido pedido in pedidos)
                        {
                            ProductoPro.ingresarProducto(pedido.ProductoId, pedido.Cantidad);
                        }
                        movimiento.FechaFin = DateTime.Now;
                        movimiento.Estado = "completado";
                        try
                        {
                            db.SaveChanges();
                            return "El movimiento de entrada fue procesado con exito, los productos se añadieron al stock";

                        }
                        catch (DbUpdateConcurrencyException exception)
                        {
                            Exception ex = new Exception("Conficto de concurrencia", exception);
                            throw ex;
                        }
                    }
                }


                return "Movimiento no encontrado";
            }
        }
    }
}