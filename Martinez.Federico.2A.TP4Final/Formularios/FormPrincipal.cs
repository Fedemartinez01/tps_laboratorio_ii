using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesTP4;
using EntidadesTP4.Excepciones;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        private CentralDatos central;


        Serializacion<List<Cliente>> serializacion = new Serializacion<List<Cliente>>();
        SerializarJSON<List<Cliente>> serializarJSON = new SerializarJSON<List<Cliente>>();
        ArchivoTXT archivo = new ArchivoTXT();

        MiEvento evento = new MiEvento();


        public CentralDatos Central
        {
            get { return this.central; }
        }
        public FormPrincipal()
        {
            InitializeComponent();
            central = new CentralDatos();
            Task.Run(() => CargarClientesArchivos());

            this.bajaClienteToolStripMenuItem.Enabled = false;
            this.cerrarAppToolStripMenuItem.Enabled = false;
            this.verClientesToolStripMenuItem1.Enabled = false;
            this.verClientesToolStripMenuItem.Enabled = false;

            evento.actualizacionDatos += ActualizarLabel;
            evento.cargaCompletada += LabelActualizado;

        }
        private async void CargarClientesArchivos()
        {
            try
            {
                await Task.Run(() =>
                {
                    Central.Clientes = ClienteSql.LeerBaseDeDatos(); //Leemos desde sql 
                    serializacion.EscribirLista(Central.Clientes, @"\TP3.xml"); // Escribimos xml
                    serializarJSON.EscribirLista(Central.Clientes, @"\TP3.json"); // Escribimos json 

                    archivo.EscribirTxt(central.RetornarDatos(), @"\TP4.txt");// Escribimos en txt

                    
                    evento.ActualizarDatos_Evento(3); // Mi evento
                });


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
        private void ActualizarLabel(int segundosSimulados)
        {
            if(this.InvokeRequired)
            {
                Action<int> delegado = ActualizarLabel;
                Invoke(delegado, segundosSimulados);
            }
            else
            {
                this.lbl_Cargando.Text = $"Aguarde por favor. Cargando clientes, quedan {segundosSimulados} segundos...";
            }

            
        }
        private void LabelActualizado()
        {
            if (this.InvokeRequired)
            {
                MiEvento.CargaCompleta delegado = LabelActualizado;
                Invoke(delegado);
            }
            else
            {
                this.lbl_Cargando.Text = "¡Aplicacion lista para usar!";
                this.bajaClienteToolStripMenuItem.Enabled = true;
                this.cerrarAppToolStripMenuItem.Enabled = true;
                this.verClientesToolStripMenuItem1.Enabled = true;
                this.verClientesToolStripMenuItem.Enabled = true;
            }           
        }
    }
}
