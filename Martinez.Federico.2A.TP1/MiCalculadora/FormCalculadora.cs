using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor calculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia todas las cajas de texto
        /// </summary>
        void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        
        /// <summary>
        /// Boton encargado de mandar a realizar la operacion asignada
        /// </summary>
        /// <param name="numero1">Numero 1</param>
        /// <param name="numero2">Numero 2</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            char opChar;
            char.TryParse(operador, out opChar);
        
            return Calculadora.Operar(num1, num2, opChar);     
        }

        /// <summary>
        /// Boton encargado de llamar al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton encargado de llamar al metodo Operar
        /// y cambiar los textos de resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            double resultado = 0;

            if(num1 == "")
            {
                num1 = "0";
            }
            if(num2 == "")
            {
                num2 = "0";
            }
            if(operador == "")
            {
                operador = "+";
            }

            resultado = Operar(num1, num2, operador);
            if (resultado == double.MinValue)
                this.lblResultado.Text = "No es posible dividir por 0";
            else
            {
                this.lblResultado.Text = "" + resultado;
                this.lstOperaciones.Items.Add(num1 + " " + operador + " " + num2 + " = " + this.lblResultado.Text);

                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Boton encargado de confirmar la finalizacion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Evento que se activa apenas abris el progama y llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton encargado de confirmar la finalizacion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCerrar_Click(sender, e);
        }

        /// <summary>
        /// Boton encargado de llamar al metodo BinarioDecimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            this.lblResultado.Text = operando.BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Boton encargado de llamar al metodo DecimalBinario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();          
            this.lblResultado.Text = operando.DecimalBinario(this.lblResultado.Text);

            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = true;
        }
    }
}
