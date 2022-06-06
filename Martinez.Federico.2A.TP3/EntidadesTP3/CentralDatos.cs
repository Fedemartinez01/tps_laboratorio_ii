using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTP3;

namespace EntidadesTP3
{
    public class CentralDatos
    {
        #region Atributos

        List<Cliente> clientes;

        #endregion

        #region Propiedades

        public List<Cliente> Clientes
        {
            get { return this.clientes; }
            set { this.clientes = value; }
        }

        #endregion

        #region Métodos

        public CentralDatos()
        {
            clientes = new List<Cliente>();   
        }

        /// <summary>
        /// Agrega cliente a la lista
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool AgregarCliente(Cliente cliente)
        {
            bool retorno = false;

            if(cliente is not null)
            {
                retorno = true;
                clientes.Add(cliente);
            }
            return retorno;
        }

        /// <summary>
        /// Saca un cliente de la lista
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool BajaCliente(Cliente cliente)
        {
            bool retorno = false;

            if(cliente is not null)
            {
                this.Clientes.Remove(cliente);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Busca un cliente y si lo encuentra lo retorna
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Cliente DevolverCliente(string idCliente)
        {
            
            foreach(Cliente cliente in this.clientes)
            {
                if(cliente.IdentificadorCliente == idCliente)
                {
                    return cliente;
                }
            }
            return null;
        }

        /// <summary>
        /// valida que haya clientes ingresados
        /// </summary>
        /// <returns>true or false</returns>
        public bool ValidarCantidadClientes()
        {
            if (this.Clientes.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
