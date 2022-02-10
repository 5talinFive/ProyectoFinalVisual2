using Modelo.Empresa;
using Persistencia;
using System;
using System.Collections.Generic;
using static Escenario.Escenario;

namespace Escenario
{
    public class EsenarioControl
    {
        public static void Grabar(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new StockContext())
            {
                //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Producto.AddRange((List<Producto>)datos[ListaTipo.Producto]);
                db.Almacen.AddRange((List<Almacen>)datos[ListaTipo.Almacen]);
                db.Marca.AddRange((List<Marca>)datos[ListaTipo.Marca]);
                db.Proveedor.AddRange((List<Proveedor>)datos[ListaTipo.Provedores]);
                db.Pedido.AddRange((List<Pedido>)datos[ListaTipo.Pedido]);
                db.Movimiento.AddRange((List<Movimiento>)datos[ListaTipo.Movimiento]);
                db.SaveChanges();
            }

        }


    }
}
