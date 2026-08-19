using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrenamiento.Datos
{
    internal class PersonaDao
    {
        AccesoDatos DB = new AccesoDatos();

        internal bool actualizarPersona(Cliente c, int id)
        {
            int filasAfectadas = 0;
            string consultaSql = $" UPDATE PERSONA " +
                $"SET nombre = @nombre, " +
                $"apellido = @apellido, " +
                $"id_tipo = @id_tipo, " +
                $"documento = @documento, " +
                $"sexo = @sexo, " +
                $"fallecido = @fallecido, " +
                $"Fecha_nacimiento = @Fecha_nacimiento " +
                $"WHERE id_persona = {id} ";
            List<Parametro> lista = new List<Parametro>();
            Parametro p;
            lista.Add(p = new Parametro("@nombre", c.Nombre));
            lista.Add(p = new Parametro("@apellido", c.Apellido));
            lista.Add(p = new Parametro("@id_tipo", c.TipoDocumento.ID));
            lista.Add(p = new Parametro("@documento", c.Documento));
            lista.Add(p = new Parametro("@sexo", c.Sexo));
            lista.Add(p = new Parametro("@fallecido", c.Morido));
            lista.Add(p = new Parametro("@Fecha_nacimiento", c.FecNac));
            filasAfectadas = DB.ActualizarBD(consultaSql, lista);
            return filasAfectadas > 0;
        }

        internal bool borrarPersona(int id)
        {
            int filasAfectadas = 0;
            string consultaSql = $" DELETE PERSONA " +
                $"WHERE id_persona = {id}";
            filasAfectadas = DB.ActuralizarTabla(consultaSql);
            return filasAfectadas > 0;
        }

        internal bool crearPersona(Cliente c)
        {
            int filasAfectadas = 0;
            string consultaSql = $"INSERT INTO PERSONA (nombre,apellido,id_tipo,documento,sexo,fallecido,Fecha_nacimiento) " +
                $"VALUES (@nombre,@apellido,@id_tipo,@documento,@sexo,@fallecido,@Fecha_nacimiento) ";
            List<Parametro> lista = new List<Parametro>();
            Parametro p;
            lista.Add(p = new Parametro("@nombre", c.Nombre));
            lista.Add(p = new Parametro("@apellido", c.Apellido));
            lista.Add(p = new Parametro("@id_tipo", c.TipoDocumento.ID));
            lista.Add(p = new Parametro("@documento", c.Documento));
            lista.Add(p = new Parametro("@sexo", c.Sexo));
            lista.Add(p = new Parametro("@fallecido", c. Morido));
            lista.Add(p = new Parametro("@Fecha_nacimiento", c.FecNac));
            filasAfectadas = DB.ActualizarBD(consultaSql,lista);
            return filasAfectadas > 0;
        }

        internal List<Cliente> recuperarCliente(string filtro)
        {
            string consultaSql = $" SELECT P.*, TP.tipo_Documento " +
                $"FROM PERSONA P JOIN TIPO_DOCUMENTO TP " +
                $"ON TP.id_tipo = P.id_tipo ";
            if (!string.IsNullOrEmpty(filtro))
            {
                consultaSql += $"WHERE P.nombre LIKE '%{filtro}%'";
            }
            List<Cliente> lista = new List<Cliente>();
            DataTable tabla = DB.ConsultarBD(consultaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                Cliente c = new Cliente();
                c.Id = Convert.ToInt32(fila[0]);
                c.Nombre = fila[1].ToString();
                c.Apellido = fila[2].ToString();
                c.TipoDocumento = new TipoDocumento();
                c.TipoDocumento.ID = Convert.ToInt32(fila[3]);
                c.Documento = Convert.ToInt32(fila[4]);
                c.Sexo = fila[5].ToString();
                c.Morido = fila[6].ToString();
                c.FecNac = (DateTime)fila[7];
                c.TipoDocumento.Tipo = fila[8].ToString();
                lista.Add(c);
            }
            return lista;
        }
        internal List<Cliente> recuperarCliente(int id)
        {
            string consultaSql = $" SELECT P.*, TP.tipo_Documento " +
                $"FROM PERSONA P JOIN TIPO_DOCUMENTO TP " +
                $"ON TP.id_tipo = P.id_tipo " +
                $"WHERE P.id_persona = {id}";
            List<Cliente> lista = new List<Cliente>();
            DataTable tabla = DB.ConsultarBD(consultaSql);
            foreach (DataRow fila in tabla.Rows)
            {
                Cliente c = new Cliente();
                c.Id = Convert.ToInt32(fila[0]);
                c.Nombre = fila[1].ToString();
                c.Apellido = fila[2].ToString();
                c.TipoDocumento = new TipoDocumento();
                c.TipoDocumento.ID = Convert.ToInt32(fila[3]);
                c.Documento = Convert.ToInt32(fila[4]);
                c.Sexo = fila[5].ToString();
                c.Morido = fila[6].ToString();
                c.FecNac = (DateTime)fila[7];
                c.TipoDocumento.Tipo = fila[8].ToString();
                lista.Add(c);
            }
            return lista;
        }

        internal List<TipoDocumento> recuperarCombo(string tabla)
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();
            DataTable oTabla = DB.ConsultarTabla(tabla);
            foreach (DataRow fila in oTabla.Rows)
            {
                TipoDocumento c = new TipoDocumento();
                c.ID = Convert.ToInt32(fila[0]);
                c.Tipo = fila[1].ToString();
                lista.Add(c);
            }
            return lista;

        }
    }
}
