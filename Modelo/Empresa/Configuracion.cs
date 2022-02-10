using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Empresa
{
    public class Configuracion : IDBEntity
    {
        public int ConfiguracionId { get; set; }
        public string NombreEmpresa { get; set; }
                
        public float Stockminimo { get; set; }
    }
}
