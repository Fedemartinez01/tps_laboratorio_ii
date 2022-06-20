using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public static class ClienteSql
    {
        #region Atributos

        static string connectionString;
        static SqlCommand sqlCommand;
        static SqlConnection sqlConnection;

        #endregion

        #region Métodos

        static ClienteSql()
        {
            connectionString = "Data Source=.;Initial Catalog=OBRA_SOCIAL;Integrated Security=true";
            sqlCommand = new SqlCommand();
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Connection = sqlConnection;
        }

        public static void Guardar(Cliente cliente)
        {
            try
            {
                
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();
                sqlCommand.CommandText = $"INSERT INTO CLIENTES (nombre, apellido, dni, _plan, cantidadGrupoFamiliar, localidad) VALUES ('{cliente.Nombre}', '{cliente.Apellido}', '{cliente.Dni}', '{cliente.Plan}', '{cliente.CantFamilia}', '{cliente.Localidad}')";

                sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", cliente.Apellido);
                sqlCommand.Parameters.AddWithValue("dni", cliente.Dni);
                sqlCommand.Parameters.AddWithValue("_plan", cliente.Plan);
                sqlCommand.Parameters.AddWithValue("cantidadGrupoFamiliar", cliente.CantFamilia);
                sqlCommand.Parameters.AddWithValue("localidad", cliente.Localidad);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
     
        public static void Eliminar(int dni)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();
                sqlCommand.CommandText = $"DELETE FROM CLIENTES WHERE dni = {dni}";
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static List<Cliente> LeerBaseDeDatos()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT * FROM CLIENTES";

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        clientes.Add(new Cliente(dataReader["nombre"].ToString(), dataReader["apellido"].ToString(), Convert.ToInt32(dataReader["dni"]), dataReader["_plan"].ToString(), Convert.ToInt32(dataReader["cantidadGrupoFamiliar"]), dataReader["localidad"].ToString()));
                    }
                }
                return clientes;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        #endregion
    }
}
