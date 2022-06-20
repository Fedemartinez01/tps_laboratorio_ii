using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTP4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingTP4
{
    [TestClass]
    public class CentralDatosTest
    {
        [TestMethod]
        public void ValidarCantidadClientes_DeberiaRetornarTrue_CuandoHayClientes()
        {
            bool expected = true;
            CentralDatos central = new CentralDatos();
            central.AgregarCliente(new Cliente());

            bool actual = central.ValidarCantidadClientes();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidarCantidadClientes_DeberiaRetornarFalse_CuandoNoHayClientes()
        {
            bool expected = false;
            CentralDatos central = new CentralDatos();

            bool actual = central.ValidarCantidadClientes();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BajaCliente_DeberiaEliminarClienteYRetornarTrue()
        {
            bool expected = true;
            CentralDatos central = new CentralDatos();

            Cliente cliente = new Cliente("pepe", "pipo", 1, "a", 2, "a");
            central.Clientes.Add(cliente);

            bool actual = central.BajaCliente(cliente);

            foreach(Cliente cliente1 in central.Clientes)
            {
                if(cliente1.Dni == cliente.Dni)
                {
                    actual = false;
                    break;
                }
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
