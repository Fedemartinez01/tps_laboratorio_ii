using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class Cliente
    {
        #region Atributos

        string nombre;
        string apellido;
        int dni;
        string plan;
        int cantGrupoFamiliar;
        string localidad;


        #endregion

        #region Propiedades
      

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Plan { get => plan; set => plan = value; }
        public int CantFamilia { get => cantGrupoFamiliar; set => cantGrupoFamiliar = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string NombreCompleto
        {
            get { return this.Nombre + " " + this.Apellido; }
        }
        public string IdentificadorCliente
        {
            get { return this.NombreCompleto + " " + this.Dni; }
        }
        public int Dni { get => dni; set => dni = value; }



        #endregion

        #region Métodos

        public Cliente()
        {

        }

        public Cliente(string nombre, string apellido, int dni, string plan, int cantGrupoFamiliar, string localidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Plan = plan;
            this.CantFamilia = cantGrupoFamiliar;
            this.Localidad = localidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Nombre+" ");
            sb.Append(Apellido + " ");
            sb.Append(Dni + " ");
            sb.Append(Plan + " ");
            sb.Append(CantFamilia + " ");
            sb.Append(Localidad + "\n");

            return sb.ToString();
        }





        #endregion

    }
}
