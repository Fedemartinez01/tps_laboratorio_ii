using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public interface IArchivos<T>
    {

        void EscribirLista(T lista, string archivo);

        T LeerLista(string archivo);
    }
}
