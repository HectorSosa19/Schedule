using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
namespace Agenda_Base_de_datos_
{
    public partial class frmAgenda : Form
    {
        private string idAgenda;
        private bool Editarse = false;
        E_Agenda objEntidad = new E_Agenda();
        N_Agenda objNegocio = new N_Agenda();
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }
        public void accionesTabla()
        {
            tablaAgenda.Columns[0].Visible = false;

            tablaAgenda.Columns[1].Width = 60;
            tablaAgenda.Columns[2].Width = 170;
            tablaAgenda.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Agenda objNegocio = new N_Agenda();
            tablaAgenda.DataSource = objNegocio.ListarAgenda(buscar);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (tablaAgenda.SelectedRows.Count > 0)
            {
                objEntidad.IdAgenda = Convert.ToInt32(tablaAgenda.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoAgenda(objEntidad);
                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona la fila que deseas eliminar");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Limpiar()
        {
            Editarse = false;
            txtCod.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaAgenda.SelectedRows.Count > 0)
            {
                Editarse = true;
                idAgenda = tablaAgenda.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = tablaAgenda.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaAgenda.CurrentRow.Cells[2].Value.ToString();
                txtApellido.Text = tablaAgenda.CurrentRow.Cells[3].Value.ToString();
                txtCedula.Text = tablaAgenda.CurrentRow.Cells[4].Value.ToString();
                txtCorreo.Text = tablaAgenda.CurrentRow.Cells[5].Value.ToString();
                txtDireccion.Text = tablaAgenda.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void tablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void topFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Apellido = txtApellido.Text.ToUpper();
                    objEntidad.Cedula = txtCedula.Text.ToUpper();
                    objEntidad.Correo = txtCorreo.Text.ToUpper();
                    objEntidad.Direccion = txtDireccion.Text.ToUpper();
                    objNegocio.InsertandoAgenda(objEntidad);
                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
                if (Editarse == true)
                {
                    try
                    {
                        objEntidad.IdAgenda= Convert.ToInt32(idAgenda);
                        objEntidad.Nombre = txtNombre.Text.ToUpper();
                        objEntidad.Apellido = txtApellido.Text.ToUpper();
                        objEntidad.Cedula = txtCedula.Text.ToUpper();
                        objEntidad.Correo = txtCorreo.Text.ToUpper();
                        objEntidad.Direccion = txtDireccion.Text.ToUpper();
                        objNegocio.InsertandoAgenda(objEntidad);
                        MessageBox.Show("Se edito el registro");
                        mostrarBuscarTabla("");
                        Limpiar();
                        Editarse = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar el registro" + ex);
                    }
                }
            }
        }

    }
}
