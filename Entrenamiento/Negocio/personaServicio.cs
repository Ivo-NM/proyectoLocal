using Entrenamiento.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrenamiento.Negocio
{
    internal class personaServicio
    {
        PersonaDao oDao = new PersonaDao();

        internal bool borrarPersona(int id)
        {
            return oDao.borrarPersona(id);
        }

        internal bool crearPersona(Cliente c)
        {
            return oDao.crearPersona(c);
        }

        internal bool editarPersona(Cliente c, int id)
        {
            return oDao.actualizarPersona(c,id);
        }

        internal List<Cliente> RecuperarCliente(int id)
        {
            return oDao.recuperarCliente(id);
        }

        internal List<Cliente> traerCliente(string filtro)
        {
            return oDao.recuperarCliente(filtro);
        }

        internal List<TipoDocumento> traerCombo()
        {
            string tabla = "TIPO_DOCUMENTO"; 
            return oDao.recuperarCombo(tabla);
        }
    }
}
