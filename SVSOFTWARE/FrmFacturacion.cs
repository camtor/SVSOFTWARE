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
    public partial class FrmFacturacion : FrmProcesos
    {
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            string Vendedor = "SELECT * FROM Usuario WHERE IdUsuarios = " + FrmLogin.codigo;

            DataSet ds;

            ds = Biblioteca.Herramientas(Vendedor);

            LbVendedor.Text = ds.Tables[0].Rows[0]["UserName"].ToString().Trim();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("SELECT NombreCliente from Clientes WHERE idClientes = '{0}'", TxtCodigo.Text.Trim());
                DataSet ds = Biblioteca.Herramientas(cmd);

                TxtCliente.Text = ds.Tables[0].Rows[0]["NombreCliente"].ToString().Trim();
                TxtCodigoProducto.Focus();
            }
            catch (Exception Error)
            {

                MessageBox.Show("Ha ocurrido un error: " + Error.Message);
            }
        }

        public static int contadorFila = 0;
        public static double Total;

        private void BtnColocar_Click(object sender, EventArgs e)
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false)
            {
                bool existe = false;
                int numeroFila = 0;

                if (contadorFila == 0)
                {
                    dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);
                    double subTotal = Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[2].Value) * Convert.ToDouble( dataGridView1.Rows[contadorFila].Cells[3].Value);
                    dataGridView1.Rows[contadorFila].Cells[4].Value = subTotal;

                    contadorFila++;
                }
                else
                {
                    foreach (DataGridViewRow Fila  in dataGridView1.Rows)
                    {
                        if (Fila.Cells[0].Value.ToString() == TxtCodigoProducto.Text)
                        {
                            existe = true;
                            numeroFila = Fila.Index;
                        }
                       
                    }

                    if (existe == true)
                    {
                        dataGridView1.Rows[numeroFila].Cells[2].Value = TxtPrecio.Text;
                        dataGridView1.Rows[numeroFila].Cells[3].Value = (Convert.ToDouble(TxtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value)).ToString();
                        double SubTotal = Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value);
                        dataGridView1.Rows[numeroFila].Cells[4].Value = SubTotal;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);
                        double subTotal = Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[3].Value);
                        dataGridView1.Rows[contadorFila].Cells[4].Value = subTotal;

                        contadorFila++;
                    }
                }
                
            }
            Total = 0;
            foreach (DataGridViewRow Fila in dataGridView1.Rows)
            {               
                Total += Convert.ToDouble(Fila.Cells[4].Value);
            }

            LblTotal.Text = "$" + Total.ToString();
        }

        private void BetnEliminar_Click(object sender, EventArgs e)
        {
            if (contadorFila > 0)
            {
                Total = Total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
                LblTotal.Text = "$" + Total.ToString();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                contadorFila --;

            }
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmConsultarCliente consultarClientes = new FrmConsultarCliente();
            consultarClientes.ShowDialog();

            if (consultarClientes.DialogResult == DialogResult.OK)
            {
                TxtCodigo.Text = consultarClientes.DtgConsultas.Rows[consultarClientes.DtgConsultas.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCliente.Text = consultarClientes.DtgConsultas.Rows[consultarClientes.DtgConsultas.CurrentRow.Index].Cells[1].Value.ToString();

                TxtCodigoProducto.Focus();
            }
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            FrmConsultarProducto consultarClientes = new FrmConsultarProducto();
            consultarClientes.ShowDialog();

            if (consultarClientes.DialogResult == DialogResult.OK)
            {
                TxtCodigoProducto.Text = consultarClientes.DtgConsultas.Rows[consultarClientes.DtgConsultas.CurrentRow.Index].Cells[0].Value.ToString();
                TxtDescripcion.Text = consultarClientes.DtgConsultas.Rows[consultarClientes.DtgConsultas.CurrentRow.Index].Cells[1].Value.ToString();
                TxtPrecio.Text = consultarClientes.DtgConsultas.Rows[consultarClientes.DtgConsultas.CurrentRow.Index].Cells[2].Value.ToString();

                TxtCantidad.Focus();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        public override void Nuevo()
        {
            TxtCodigo.Text ="";
            TxtCliente.Text = "";
            TxtCodigoProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            LblTotal.Text = "$ 0";
            dataGridView1.Rows.Clear();
            contadorFila = 0;
            Total = 0;

            TxtCodigo.Focus();
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (contadorFila != 0)
            {
                try
                {
                    string cmd = string.Format("Exec ActualizarFacturas '{0}'",TxtCodigo.Text.Trim());

                    DataSet DS = Biblioteca.Herramientas(cmd);
                    string numeroFactura = DS.Tables[0].Rows[0]["NumeroFactura"].ToString().Trim();

                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        cmd = string.Format("Exec ActualziarDetalles '{0}','{1}',{2},{3}",numeroFactura,Fila.Cells[0].Value.ToString(),Fila.Cells[2].Value.ToString(),Fila.Cells[3].Value.ToString());
                        DS = Biblioteca.Herramientas(cmd);
                    }

                    cmd = "Exec DatosDeFactura " + numeroFactura;

                    DS = Biblioteca.Herramientas(cmd);

                    FrmFactura Fac = new FrmFactura();
                    Fac.reportViewer1.LocalReport.DataSources[0].Value = DS.Tables[0];

                    Fac.ShowDialog();

                    Nuevo();
                }
                catch (Exception Error)
                {

                    MessageBox.Show("Error: * " + Error.Message);
                }
            }
        }
    }    
}
