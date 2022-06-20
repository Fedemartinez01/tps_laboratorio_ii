using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class MiEvento
    {
        public delegate void CargaCompleta();
        public event CargaCompleta cargaCompletada;

        public event Action<int> actualizacionDatos;

        public MiEvento()
        {

        }

        public void ActualizarDatos_Evento(int segundos)
        {
            Task.Run(() => 
            {
                while(segundos >= 0)
                {
                    actualizacionDatos?.Invoke(segundos);
                    Thread.Sleep(1000);
                    segundos--;
                }
                cargaCompletada.Invoke();

            });
            
        }
    }
}
