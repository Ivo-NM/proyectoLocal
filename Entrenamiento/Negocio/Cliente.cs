using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrenamiento
{
    public class Cliente
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}


		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		private TipoDocumento tipoDocumento;

		public TipoDocumento TipoDocumento
		{
			get { return tipoDocumento; }
			set { tipoDocumento = value; }
		}

		private int documento;

		public int Documento
		{
			get { return documento; }
			set { documento = value; }
		}

        private string sexo;

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private string morido;

        public string Morido
        {
            get { return morido; }
            set { morido = value; }
        }

		private DateTime fecNac;

		public DateTime FecNac
		{
			get { return fecNac; }
			set { fecNac = value; }
		}




	}
}
