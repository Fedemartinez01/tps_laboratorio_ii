using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntidadesTP4;

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
            Cliente clienteBaja = centralDatos.DevolverCliente(identificadorCliente);

            try
            {
                if (centralDatos.BajaCliente(clienteBaja))
                {
                    cmb_baja.Items.Remove(identificadorCliente);
                    ClienteSql.Eliminar(clienteBaja.Dni);
                    MessageBox.Show("Cliente dado de baja");

                    ArchivoTXT archivo = new ArchivoTXT();
                    archivo.EscribirTxt(centralDatos.RetornarDatos(), @"\TP4.txt");
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
