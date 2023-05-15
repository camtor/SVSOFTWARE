using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibreriaDLL;

namespace SVSOFTWARE
{
    public partial class FrmLogin : FrmBase
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public static string codigo = "";


        private void BtnConexion_Click(object sender, EventArgs e)
        {
            try
            {
                string validar = string.Format("Select * FROM Usuario WHERE Account='{0}' AND Password= '{1}'", TxtUsuario.Text.Trim(), TxtPassword.Text.Trim());
                DataSet Conectar = Biblioteca.Herramientas(validar);

                codigo = Conectar.Tables[0].Rows[0]["IdUsuarios"].ToString().Trim();

                string cuenta = Conectar.Tables[0].Rows[0]["Account"].ToString().Trim();
                string contrasena = Conectar.Tables[0].Rows[0]["Password"].ToString().Trim();


                if (cuenta == TxtUsuario.Text.Trim() && contrasena == TxtPassword.Text.Trim())
                {
                    if (Convert.ToBoolean( Conectar.Tables[0].Rows[0] ["ValidarAdmin"].ToString().Trim()) == true)
                    {
                        FrmAdministrador Admin = new FrmAdministrador();
                        this.Hide();
                        Admin.Show();
                    }
                    else
                    {
                        FrmUsuario Usuario = new FrmUsuario();
                        this.Hide();
                        Usuario.Show();
                    }
                    
                }
                
            }
            catch (Exception error)
            {

                MessageBox.Show("Usario o Contraseña Incorrecto"+ error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegistro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            string text = TxtPassword.Text;
            if (checkBoxShowPassword.Checked)
            {
                TxtPassword.UseSystemPasswordChar = true;
                TxtPassword.Text = text;

            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
                TxtPassword.Text = text;
            }

        }
    }
}
