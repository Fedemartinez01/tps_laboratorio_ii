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

namespace Formularios
{
    public partial class Frm_BajaCliente : Form
    {
        CentralDatos centralDatos;

        Serializacion<List<Cliente>> serializacion = new Serializacion<List<Cliente>>();
        SerializarJSON<List<Cliente>> serializarJSON = new SerializarJSON<List<Cliente>>();

        public Frm_BajaCliente(CentralDatos central)
        {
            this.centralDatos = central;
            InitializeComponent();

            foreach (Cliente cliente in central.Clientes)
            {
                cmb_baja.Items.Add($"{cliente.NombreCompleto} {cliente.Dni}");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string identificadorCliente = cmb_baja.Text;

            try
            {
                if (centralDatos.BajaCliente(centralDatos.DevolverCliente(identificadorCliente)))
                {
                    cmb_baja.Items.Remove(identificadorCliente);
                    MessageBox.Show("Cliente dado de baja");


                    serializacion.EscribirLista(centralDatos.Clientes, @"\TP3.xml");   
                    serializarJSON.EscribirLista(centralDatos.Clientes, @"\TP3.json");
                }
                else
                {
                    throw new CampoInvalidoExcepcion();
                }              
            }
            catch (CampoInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Frm_BajaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
