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
    public partial class FrmConsultas : FrmBase
    {
        public FrmConsultas()
        {
            InitializeComponent();
        }

        public DataSet MostrarInformacion(string Tabla)
        {
            DataSet DS;
            string Cmd = string.Format("SELECT * FROM " + Tabla);
            DS = Biblioteca.Herramientas(Cmd);

            return DS;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DtgConsultas.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
