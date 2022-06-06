using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesTP3;
using EntidadesTP3.Excepciones;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        private CentralDatos central;

        Serializacion<List<Cliente>> serializacion = new Serializacion<List<Cliente>>();
        SerializarJSON<List<Cliente>> serializarJSON = new SerializarJSON<List<Cliente>>();


        public CentralDatos Central
        {
            get { return this.central; }
        }
        public FormPrincipal()
        {
            InitializeComponent();
            central = new CentralDatos();

           
            try
            {
                Central.Clientes = serializacion.LeerLista(@"\TP3.xml");
                serializacion.EscribirLista(Central.Clientes, @"\TP3.xml");
                serializarJSON.EscribirLista(Central.Clientes, @"\TP3.json");
            }
            catch (ArchivoNoEncontradoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_AltaCliente frm_AltaCliente = new Frm_AltaCliente(this.Central);
            frm_AltaCliente.Show();

        }
        private void verClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                central.Clientes = serializacion.LeerLista(@"\TP3.xml");

                if (Central.ValidarCantidadClientes())
                {
                    ListadoUsuarios listadoUsuarios = new ListadoUsuarios(this.Central);
                    listadoUsuarios.Show();
                }
                else
                {
                    throw new NoHayClientesExcepcion();
                }
            }
            catch (NoHayClientesExcepcion ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoUsuarios listadoUsuarios = new ListadoUsuarios(this.Central);
            listadoUsuarios.Show();
        }
        private void bajaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Central.ValidarCantidadClientes())
                {
                    Frm_BajaCliente frm_BajaCliente = new Frm_BajaCliente(central);
                    frm_BajaCliente.Show();
                }
                else
                {
                    throw new NoHayClientesExcepcion();
                }
            }
            catch (NoHayClientesExcepcion ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        private void cerrarAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
