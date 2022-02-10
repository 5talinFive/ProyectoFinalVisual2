using Modelo;
using Modelo.Empresa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Info
{
    public class AlmacenInfo
    {


        public static void mostrarAlmacen(Almacen almacen)
        {
            string mensaje =  String.Format(
                "ID: {0} \t Nombre: {1}\t Ubicacion: {2}\n",
                almacen.AlmacenId,
                almacen.Nombre,
                almacen.Ubicacion
            );
            
            Console.WriteLine(mensaje);
        }

        public static void mostrarAlmacenes(List<Almacen> listaAlmacen)
        {
            Console.WriteLine("\t\t -Almacenes-");
            foreach (var almacen in listaAlmacen)
            {
                mostrarAlmacen(almacen);
            }
            
        }
    }
}
