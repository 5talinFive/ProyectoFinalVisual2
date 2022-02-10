using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Empresa
{
    public class Almacen : IDBEntity
    {
        //Atributos
        public int AlmacenId { get; set; }
        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
