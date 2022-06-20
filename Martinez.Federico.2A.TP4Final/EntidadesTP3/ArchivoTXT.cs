using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class ArchivoTXT
    {

        static string carpeta = @"../../../../EntidadesTP3/ARCHIVOS TP3/";
        static string rutaCompleta;

        public void EscribirTxt(string datos, string archivo)
        {
            rutaCompleta = carpeta + archivo;
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                File.WriteAllText(rutaCompleta, datos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
