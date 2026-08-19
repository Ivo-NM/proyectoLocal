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
    public partial class Detalle : Form
    {
        personaServicio oServicio = new personaServicio();
        Modo modo;
        int id;
        public Detalle(Modo Modo, int Id)
        {
            InitializeComponent();
            this.modo = Modo;
            this.id = Id;
   ;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Detalle_Load(object sender, EventArgs e)
        {
            if (modo == Modo.Nuevo) 
            {
                cargarCombo();
                txtIdCliente.Enabled = false;
                btnBorrar.Visible = false;
                btnGuardarC.Visible = false;
            }
            else if (modo == Modo.Ver)
            {
                habilitar(false);
                btnBorrar.Visible = false;
                btnGuardarC.Visible = false;
                btnAceptar.Visible = false;
                cargarPersona(id);
            }
            else if (modo == Modo.Editar)
            {
                cargarCombo();
                txtIdCliente.Enabled = false;
                btnBorrar.Visible = false;
                btnAceptar.Visible = false;
                cargarPersona(id);
            }
            else if (modo == Modo.Borrar)
            {
                habilitar(false);
                cargarPersona(id);
                btnGuardarC.Visible=false;
                btnGuardarC.Visible = false;
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Cliente c = crearCliente();
                if (oServicio.crearPersona(c))
                {
                    MessageBox.Show("Exito al crear");
                    this.Dispose();
                }
                else { MessageBox.Show("Error al crear");}
            }
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            Cliente c = crearCliente();
            if (oServicio.editarPersona(c,id))
            {
                MessageBox.Show("Exito al editar");
                this.Dispose();
            }
            else { MessageBox.Show("Error al editar"); }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea borrar esta persona?", "BORRAR",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (oServicio.borrarPersona(id))
                {
                    MessageBox.Show("Exito al borrar");
                    this.Dispose();
                }
                else { MessageBox.Show("Error al borrar"); }
            }
        }

        private void cargarCombo()
        {
            List<TipoDocumento> lista = oServicio.traerCombo();
            cmbDocCliente.DataSource = lista;
            cmbDocCliente.SelectedIndex = -1;
            cmbDocCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void habilitar(bool x)
        {
            txtIdCliente.Enabled = x;
            txtNomCliente.Enabled = x;
            txtApellCliente.Enabled = x;
            cmbDocCliente.Enabled = x;
            txtNroDoc.Enabled = x;
            rdbM.Enabled = x;
            rdbF.Enabled = x;
            cbMorido.Enabled = x;
            dtmFecNac.Enabled = x;
        }
        private bool validar()
        {
            if (string.IsNullOrEmpty(txtNomCliente.Text.Trim()))
            {
                MessageBox.Show("Debe colocar un nombre");
                return false;
            }
            if (string.IsNullOrEmpty(txtApellCliente.Text.Trim()))
            {
                MessageBox.Show("Debe colocar un apellido");
                return false;
            }
            if (cmbDocCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe colocar un Tipo de documento");
                return false;
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text.Trim()))
            {
                MessageBox.Show("Debe colocar un documento");
                return false;
            }
            if (rdbM.Checked == false && rdbF.Checked == false)
            {
                MessageBox.Show("Debe Seleccionar un sexo");
                return false;
            }
            if (dtmFecNac.Value.Year > 2008)
            {
                MessageBox.Show("La persona es menor de edad");
                return false;
            }
            return true;
        }
        private Cliente crearCliente()
        {
            Cliente c = new Cliente();
            c.Nombre = txtNomCliente.Text.Trim();
            c.Apellido = txtApellCliente.Text.Trim();
            c.TipoDocumento = new TipoDocumento();
            c.TipoDocumento = (TipoDocumento)cmbDocCliente.SelectedItem;
            c.Documento = Convert.ToInt32(txtNroDoc.Text.Trim());
            if (rdbM.Checked == true)
            {
                c.Sexo = "Masculino";
            }
            else { c.Sexo = "Femenino";}
            if (cbMorido.Checked == true)
            {
                c.Morido = "Si";
            }
            else { c.Morido = "No"; }
            c.FecNac = dtmFecNac.Value;
            return c;
        }
        private void cargarPersona(int id)
        {
            List<Cliente> lista = oServicio.RecuperarCliente(id);
            foreach (Cliente c in lista)
            {
                txtIdCliente.Text = c.Id.ToString();
                txtNomCliente.Text = c.Nombre.ToString();
                txtApellCliente.Text = c.Apellido.ToString();
                cmbDocCliente.Text = c.TipoDocumento.Tipo.ToString();
                txtNroDoc.Text = c.Documento.ToString();
                if (c.Sexo == "Masculino")
                {
                    rdbM.Checked = true;
                }else { rdbF.Checked = true;}
                if (c.Morido == "Si") { cbMorido.Checked = true; } else { cbMorido.Checked = false; }
                dtmFecNac.Value = c.FecNac;
            }

        }

    }
}
