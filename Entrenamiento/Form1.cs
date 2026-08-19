using Entrenamiento.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrenamiento
{
    public enum Modo 
    {
        Nuevo,
        Ver,
        Editar,
        Borrar
    }
 
    public partial class Form1 : Form
    {
        personaServicio oServicio = new personaServicio();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }

      

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?","SALIR",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Detalle frm = new Detalle(Modo.Nuevo,0);
            frm.ShowDialog();
            cargarGrilla();
        }

        private void btnDetalle_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                Detalle frm = new Detalle(Modo.Ver,Id);
                frm.ShowDialog();
                cargarGrilla();
            }
            else { MessageBox.Show("Seleccione una persona primero"); }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                Detalle frm = new Detalle(Modo.Editar, Id);
                frm.ShowDialog();
                cargarGrilla();
            }
            else { MessageBox.Show("Seleccione una persona primero"); }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                Detalle frm = new Detalle(Modo.Borrar, Id);
                frm.ShowDialog();
                cargarGrilla();
            }
            else { MessageBox.Show("Seleccione una persona primero"); }
        }
        private void cargarGrilla()
        {
            dgvClientes.Columns.Clear();
            string filtro = string.Empty;
            if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                filtro = txtNombre.Text.Trim();
            }
            List<Cliente> lista = oServicio.traerCliente(filtro);
            dgvClientes.Columns.Add("Col_Id", "Id");
            dgvClientes.Columns["Col_Id"].Visible = false;
            dgvClientes.Columns.Add("Col_nombre", "Nombre");
            dgvClientes.Columns.Add("Col_apellido", "Apellido");
            dgvClientes.Columns.Add("Col_tp", "Tipo Documento");
            dgvClientes.Columns.Add("Col_documento", "Documento");
            dgvClientes.Columns.Add("Col_Edad", "Edad");
            foreach (Cliente c in lista)
            {
                int edad = DateTime.Today.Year-c.FecNac.Year;
                //if (c.FecNac.Date > hoy.AddYears(-edad)) {edad--;}
                dgvClientes.Rows.Add(c.Id, c.Nombre, c.Apellido, c.TipoDocumento.Tipo, c.Documento,edad);
            }

        }
    }
}
