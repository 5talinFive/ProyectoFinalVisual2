using Modelo;
using Modelo.Empresa;
using System;
using System.Collections.Generic;

namespace Escenario
{
    public class Escenario01 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {
            //Almacenes
            Almacen almacenQuito = new() { Nombre = "Almacen Quito", Ubicacion = "Av. Mariana de Jesus" };
            Almacen almacenGuayaquil = new() { Nombre = "Almacen Guayaquil", Ubicacion = "Av. 9 de Octubre" };
            List<Almacen> listaAlmacen = new() { almacenQuito, almacenGuayaquil };
            datos.Add(ListaTipo.Almacen, listaAlmacen);

            //Marcas
            Marca samsung = new() { Nombre = "Samsung" };
            Marca apple = new() { Nombre = "Apple" };
            List<Marca> listaMarcas = new() { samsung, apple };
            datos.Add(ListaTipo.Marca, listaMarcas);

            //Proveedores
            Proveedor proveedor1 = new() { Nombre = "Carlos Rodas", Numero = "00000000", Correo = "correo@correo.com" };
            Proveedor proveedor2 = new() { Nombre = "Maria Marquez", Numero = "00000000", Correo = "correo@correo.com" };
            List<Proveedor> listaProveedor = new() { proveedor1, proveedor2 };
            datos.Add(ListaTipo.Provedores, listaProveedor);


            //Productos
            Producto samsungA20 = new() { Modelo = "Galaxy A20", Stock = 34, Almacen = almacenQuito, Marca = samsung, Proveedor = proveedor2 };
            Producto samsungA10 = new() { Modelo = "Galaxy A10", Stock = 35, Almacen = almacenQuito, Marca = samsung, Proveedor = proveedor1 };
            Producto samsungA50 = new() { Modelo = "Galaxy A50", Stock = 1, Almacen = almacenQuito, Marca = samsung, Proveedor = proveedor2 };
            Producto samsungS21 = new() { Modelo = "Galaxy S21", Stock = 15, Almacen = almacenQuito, Marca = samsung, Proveedor = proveedor1 };
            Producto samsungS20 = new() { Modelo = "Galaxy S20", Stock = 30, Almacen = almacenQuito, Marca = samsung, Proveedor = proveedor2 };
            List<Producto> listaProductos = new() { samsungA10, samsungA20, samsungS21, samsungS20, samsungA50 };
            datos.Add(ListaTipo.Producto, listaProductos);

            Movimiento movimiento1 = new() { TipoMovimiento = "salida", Estado = "pendiente", FechaInicio = DateTime.Now };

            Pedido pedido1 = new() { Producto = samsungA20, Cantidad = 10 };
            Pedido pedido2 = new() { Producto = samsungA50, Cantidad = 10 };
            Pedido pedido3 = new() { Producto = samsungS20, Cantidad = 30 };
            List<Pedido> listaPedidos1 = new() { pedido1, pedido2, pedido3 };
            movimiento1.Pedidos = listaPedidos1;

            Movimiento movimiento2 = new() { TipoMovimiento = "entrada", Estado = "pendiente", FechaInicio = DateTime.Now };

            Pedido pedido4 = new() { Producto = samsungA20, Cantidad = 15 };
            Pedido pedido5 = new() { Producto = samsungA10, Cantidad = 15 };
            Pedido pedido6 = new() { Producto = samsungS21, Cantidad = 50 };
            List<Pedido> listaPedidos2 = new() { pedido4, pedido5, pedido6 };
            movimiento2.Pedidos = listaPedidos2;

            List<Pedido> listapedidos = new() { pedido1, pedido2, pedido3, pedido4, pedido5, pedido6 };
            datos.Add(ListaTipo.Pedido,listapedidos);

            List<Movimiento> listaMovimientos = new() { movimiento1, movimiento2 };
            datos.Add(ListaTipo.Movimiento, listaMovimientos);
            return datos;
        }
    }
}
