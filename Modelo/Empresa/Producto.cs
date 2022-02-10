using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Empresa
{
    public class Producto : IDBEntity
    {
        public int ProductoId { get; set; }
        public int Stock { get; set; }
        public string Modelo { get; set; }
        //Relacion con marca
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }
        //relacion con provedores
        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }
        public Almacen Almacen { get; set; }
        public int AlmacenId { get; set; }
    }
}
