using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrenamiento.Datos
{
    internal class AccesoDatos
    {
        string cadenaConexion = "Data Source=IVO\\SQLTUP;Initial Catalog=Personas;User ID=sa;Password=SQLTUP;Encrypt=False";
        SqlConnection conexion;
        SqlCommand comando;

        public AccesoDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public DataTable ConsultarTabla(string nombreTabla)
        {
            DataTable table = new DataTable();
            this.Conectar();
            comando.CommandText = $"SELECT * FROM {nombreTabla}";
            table.Load(comando.ExecuteReader());
            this.Desconectar();
            return table;
        }
        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.Conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            this.Desconectar();
            return tabla;
        }
        public int ActuralizarTabla(string consultaSql)
        {
            int filasAfectadas = 0;
            this.Conectar();
            comando.CommandText = consultaSql;
            filasAfectadas = comando.ExecuteNonQuery();
            this.Desconectar();
            return filasAfectadas;
        }

        public int ActualizarBD(string consultaSQL, List<Parametro> lista)
        {
            int filasAfectadas = 0;
            this.Conectar();
            comando.CommandText = consultaSQL;
            foreach (Parametro p in lista)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            filasAfectadas = comando.ExecuteNonQuery();
            this.Desconectar();
            return filasAfectadas;
        }
    }
}
