using EntidadesTP3.Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesTP3
{
    public class SerializarJSON<T> : IArchivos<T>
    {
        static string carpeta = @"../../../../EntidadesTP3/ARCHIVOS TP3/";
        static string rutaCompleta;


        /// <summary>
        /// Escribe los datos en el archivo XML
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="archivo"></param>
        public void EscribirLista(T lista, string archivo)
        {
            rutaCompleta = carpeta + archivo;
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                string clienteJson = JsonSerializer.Serialize(lista);

                File.WriteAllText(rutaCompleta, clienteJson);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Lee los datos del archivo XML y retorna la lista de personas
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public T LeerLista(string archivo)
        {
            rutaCompleta = carpeta + archivo;
            T personas = default;
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                string archivoJson = File.ReadAllText(rutaCompleta);
                personas = JsonSerializer.Deserialize<T>(archivoJson);

                return personas;
            }
            catch (Exception e)
            {
                throw new ArchivoNoEncontradoExcepcion();
            }
        }
    }
}
