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
    public partial class Frm_AltaCliente : Form
    {
        CentralDatos central;
        public Frm_AltaCliente(CentralDatos central)
        {
            this.central = central;
            InitializeComponent();
        }
        private int ValidarDni(string Sdni)
        {
            if (int.TryParse(Sdni, out int dni))
            {
                foreach (Cliente cliente in central.Clientes)
                {
                    if (dni == cliente.Dni)
                    {
                        throw new DniExistenteExcepcion();
                    }
                }
                return dni;
            }
            else
            {
                return 0;
                throw new CampoInvalidoExcepcion();                   
            }               
            

            
        }
        private void button1_Click(object sender, EventArgs e)
        {           

            try
            {
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                int dni = ValidarDni(txt_dni.Text);
                string plan = cmb_plan.Text;
                int cantGrupoFamiliar = (int)num_familiar.Value;
                string localidad = cmb_localidad.Text;

                if ((string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(plan) || string.IsNullOrEmpty(localidad) || dni == 0))
                {
                    throw new CampoInvalidoExcepcion();
                }
                else
                {
                    Cliente cliente = new Cliente(nombre, apellido, dni, plan, cantGrupoFamiliar, localidad);

                    if (central.AgregarCliente(cliente))
                    {
                        MessageBox.Show("Agregado con éxito");

                        Serializacion<List<Cliente>> serializacion = new Serializacion<List<Cliente>>();
                        serializacion.EscribirLista(central.Clientes, @"\TP3.xml");

                        SerializarJSON<List<Cliente>> serializarJSON = new SerializarJSON<List<Cliente>>();
                        serializarJSON.EscribirLista(central.Clientes, @"\TP3.json");

                        this.Close();
                    }
                }
            }
            catch (CampoInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(DniExistenteExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
