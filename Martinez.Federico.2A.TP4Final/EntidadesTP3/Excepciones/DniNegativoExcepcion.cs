using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class DniNegativoExcepcion : Exception
    {
        public DniNegativoExcepcion() : this(null)
        {

        }
        public DniNegativoExcepcion(Exception exception) : base("\nDNI negativo", exception)
        {

        }
    }
}
