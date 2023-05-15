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
    public partial class FrmAdministrador : FrmBase
    {
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            string Consulta = "SELECT * FROM Usuario WHERE IdUsuarios ="+FrmLogin.codigo;
            DataSet Data = Biblioteca.Herramientas(Consulta);
            lAdmin.Text = Data.Tables[0].Rows[0]["UserName"].ToString();
            lAdminUser.Text = Data.Tables[0].Rows[0]["Account"].ToString();
            lCodigo.Text = Data.Tables[0].Rows[0]["IdUsuarios"].ToString();

            string imagen = Data.Tables[0].Rows[0]["Imagen"].ToString();
            pictureBox1.Image = Image.FromFile(imagen);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmContenedorPrincipal ContenedorPrincipal = new FrmContenedorPrincipal();
            this.Hide();
            ContenedorPrincipal.Show();
        }
    }
}
