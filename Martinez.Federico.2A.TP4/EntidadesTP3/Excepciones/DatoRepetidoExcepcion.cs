using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    class DatoRepetidoExcepcion : Exception
    {
        public DatoRepetidoExcepcion() : this(null)
        {

        }
        public DatoRepetidoExcepcion(Exception exception) : base("\nTratando de agregar un cliente ya existente", exception)
        {

        }
    }
}
