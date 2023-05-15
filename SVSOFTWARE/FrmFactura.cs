using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVSOFTWARE
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.DatosDeFactura' Puede moverla o quitarla según sea necesario.
           // this.DatosDeFacturaTableAdapter.Fill(this.DataSet1.DatosDeFactura);

            this.reportViewer1.RefreshReport();
        }
    }
}
