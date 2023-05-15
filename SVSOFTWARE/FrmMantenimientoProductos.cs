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
    public partial class FrmMantenimientoProductos : FrmMantenimiento
    {
        public FrmMantenimientoProductos()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoProductos_Load(object sender, EventArgs e)
        {

        }

        public override bool Guardar()
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string Insertar = string.Format("EXEC ActualizarProductos '{0}','{1}','{2}'", TxtIdProducto.Text.Trim(), TxtDescripcion.Text.Trim(), TxtPrecio.Text.Trim());
                    Biblioteca.Herramientas(Insertar);
                    MessageBox.Show("Producto Guardado Correctamente");
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
                string Eliminar = string.Format("EXEC EliminarProductos '{0}'", TxtIdProducto.Text.Trim());
                Biblioteca.Herramientas(Eliminar);
                MessageBox.Show("El producto sea eliminado correctamente");
            }
            catch (Exception Error)
            {

                MessageBox.Show("ocurrio un error:" + Error); ;
            }
            
        }

        private void TxtIdProducto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIdProducto.Text.Trim()) == false && string.IsNullOrEmpty(TxtDescripcion.Text.Trim()) == false && string.IsNullOrEmpty(TxtPrecio.Text.Trim()) == false)
            {
                TxtIdProducto.Text = "";
                TxtDescripcion.Text = "";
                TxtPrecio.Text = "";
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            FrmConsultarProducto frmConsultarProducto = new FrmConsultarProducto();
            frmConsultarProducto.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
