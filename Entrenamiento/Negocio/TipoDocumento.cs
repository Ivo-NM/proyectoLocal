using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrenamiento
{
    public class TipoDocumento
    {

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string tipo;

		public string Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

        public override string ToString()
        {
			return tipo;
        }



	}
}
