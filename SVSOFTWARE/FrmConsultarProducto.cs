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
    public partial class FrmConsultarProducto : FrmConsultas
    {
        public FrmConsultarProducto()
        {
            InitializeComponent();
        }

        private void FrmConsultarProducto_Load(object sender, EventArgs e)
        {
            DtgConsultas.DataSource = MostrarInformacion("Articulos").Tables[0];
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBusqueda.Text.Trim()) == false)
            {
                try
                {
                    DataSet Ds;
                    string Buscar = "SELECT * from Articulos WHERE NombreProducto LIKE ('%"+TxtBusqueda.Text.Trim()+"%')";
                    Ds = Biblioteca.Herramientas(Buscar);
                    DtgConsultas.DataSource = Ds.Tables[0];
                }
                catch (Exception Error)
                {
                    MessageBox.Show("No se puede conectar, Error: ", Error.Message);
                }
            }
        }
    }
}
