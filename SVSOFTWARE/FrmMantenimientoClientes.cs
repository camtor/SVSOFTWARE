using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL;

namespace SVSOFTWARE
{
    public partial class FrmMantenimientoClientes : FrmMantenimiento
    {
        public FrmMantenimientoClientes()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoClientes_Load(object sender, EventArgs e)
        {

        }

        public override bool Guardar()
        {
            if (Biblioteca.ValidarFormulario (this, errorProvider1) == false)
            {
                try
                {
                    string Insertar = string.Format("EXEC ActualizarClientes '{0}','{1}','{2}'", TxtIdCliente.Text.Trim(), TxtNombre.Text.Trim(), TxtApellido.Text.Trim());
                    Biblioteca.Herramientas(Insertar);
                    MessageBox.Show("Cliente Guardado Correctamente");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("A ocurrido un error:" + error);
                    return false;
                }
            }
            else
            {
                return false;
            }

           
        }

        public override void Eliminar()
        {
            try
            {
                string Elimina = string.Format("EXEC EliminarClientes '{0}'", TxtIdCliente.Text.Trim());
                Biblioteca.Herramientas(Elimina);
                MessageBox.Show("El Cliente sea eliminado correctamente");
            }
            catch (Exception Error)
            {

                MessageBox.Show("ocurrio un error:" + Error); ;
            }

        }

        private void TxtIdCliente_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIdCliente.Text.Trim()) == false && string.IsNullOrEmpty(TxtNombre.Text.Trim()) == false && string.IsNullOrEmpty(TxtApellido.Text.Trim()) == false)
            {
                TxtIdCliente.Text = "";
                TxtNombre.Text = "";
                TxtApellido.Text = "";
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            FrmConsultarCliente frmConsultarCliente = new FrmConsultarCliente();
            frmConsultarCliente.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
