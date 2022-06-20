using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class DniExistenteExcepcion : Exception
    {
        public DniExistenteExcepcion() : this(null)
        {

        }
        public DniExistenteExcepcion(Exception exception) : base("Dni existente, por favor ingresar otro", exception)
        {

        }
    }
}
