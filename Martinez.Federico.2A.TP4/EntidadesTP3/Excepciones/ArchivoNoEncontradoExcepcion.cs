using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4.Excepciones
{
    public class ArchivoNoEncontradoExcepcion : Exception
    {
        public ArchivoNoEncontradoExcepcion() : this(null)
        {

        }
        public ArchivoNoEncontradoExcepcion(Exception exception) : base("\nNo se ha encontrado el archivo", exception)
        {

        }
    }
}
