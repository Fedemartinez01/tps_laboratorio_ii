using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP3
{
    public class CampoInvalidoExcepcion : Exception
    {
        public CampoInvalidoExcepcion() : this(null)
        {

        }
        public CampoInvalidoExcepcion(Exception exception) : base("\nCampo inválido", exception)
        {

        }
    }
}
