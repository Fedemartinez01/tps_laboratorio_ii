using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class NoHayClientesExcepcion : Exception
    {
        public NoHayClientesExcepcion() : this(null)
        {

        }
        public NoHayClientesExcepcion(Exception exception) : base("No hay clientes agregados", exception)
        {

        }



    }
}
