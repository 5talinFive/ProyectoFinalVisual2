using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Empresa
{
    public class Proveedor : IDBEntity
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }

        public string Numero { get; set; }

        public string Correo { get; set; }

    }
}
