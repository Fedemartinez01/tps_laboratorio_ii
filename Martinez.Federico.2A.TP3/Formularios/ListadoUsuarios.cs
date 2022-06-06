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
    public partial class ListadoUsuarios : Form
    {
        private CentralDatos central;

        public CentralDatos Central { get => central; set => central = value; }

        public ListadoUsuarios(CentralDatos central)
        {
            InitializeComponent();
            this.Central = central;
            CargarDatos(central.Clientes);
        }

        /// <summary>
        /// Carga datos en la dataGridView
        /// </summary>
        /// <param name="lista"></param>
        private void CargarDatos(List<Cliente> lista)
        {
            foreach (Cliente cliente in lista)
            {
                int i = this.listado.Rows.Add();

                this.listado.Rows[i].Cells[0].Value = cliente.NombreCompleto;
                this.listado.Rows[i].Cells[1].Value = cliente.Dni;
                this.listado.Rows[i].Cells[2].Value = cliente.Plan;
                this.listado.Rows[i].Cells[3].Value = cliente.CantFamilia;
                this.listado.Rows[i].Cells[4].Value = cliente.Localidad;
            }           
        }

        private void btn_darBaja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + this.listado.SelectedRows);
        }
    }
}
