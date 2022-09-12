using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentD
{
    public partial class frmCatalogos : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
     
        public static string ConnectionString = ConfigurationManager.AppSettings["ConexionDB"];
        int _TipoCataolgo;
        string _usuario;
        public frmCatalogos(int tipoCataolgo, string usuario)
        {
            InitializeComponent();
            _TipoCataolgo = tipoCataolgo;
            _usuario = usuario; 
        }

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = Proc.llenarCatalogo(_TipoCataolgo,null,1);


            dtgcatalogo.AutoGenerateColumns = false;
            dtgcatalogo.ColumnCount = 4;

            dtgcatalogo.Columns[0].HeaderText = "ID";
            dtgcatalogo.Columns[0].DataPropertyName = "ID";
            dtgcatalogo.Columns[1].HeaderText = "Descripción";
            dtgcatalogo.Columns[1].DataPropertyName = "Descripcion";
            dtgcatalogo.Columns[2].HeaderText = "Detalle";
            dtgcatalogo.Columns[2].DataPropertyName = "Clave";
            dtgcatalogo.Columns[3].HeaderText = "Activo";
            dtgcatalogo.Columns[3].DataPropertyName = "Activo";
            

            dtgcatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgcatalogo.Columns[0].Visible = false;
            bindingSource1.DataSource = dt;
            dtgcatalogo.DataSource = bindingSource1;


            switch (_TipoCataolgo)
            {
                case 1:
                    label1.Text = "Descipción:";
                    label2.Text = "Área";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;
                case 2:
                    label1.Text = "Descipción:";
                    label2.Text = "Budget";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;
                case 3:
                    label1.Text = "Descipción:";
                    label2.Text = "Centro de costos";
                    label3.Text = "Clave:";
                    dtgcatalogo.Columns[2].HeaderText = "Clave";

                    break;
                case 4:
                    label1.Text = "Descipción:";
                    label2.Text = "Beneficiario";
                    label3.Text = "Domicilio";
                    dtgcatalogo.Columns[2].HeaderText = "Domicilio";

                    break;
                case 5:
                    label1.Text = "Descipción:";
                    label2.Text = "Tipo de pago";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;

                case 6:
                    label1.Text = "Descipción:";
                    label2.Text = "Estatus";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;
                case 7:
                    label1.Text = "Descipción:";
                    label2.Text = "Moneda";
                    label3.Text = "Tipo";
                    dtgcatalogo.Columns[2].HeaderText = "Tipo";



                    break;
                case 8:
                    label1.Text = "Descipción:";
                    label2.Text = "Tipo de Documento";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;
                case 9:
                    label1.Text = "Descipción:";
                    label2.Text = "Tipo de usuario";
                    label3.Visible = false;
                    txtDetalles.Visible = false;
                    dtgcatalogo.Columns[2].Visible = false;

                    break;

            }

        }

        private void vtnbuscar_Click(object sender, EventArgs e)
        {

            int activo=0;

            if(chkAct.Checked == true)
            { activo = 1; }

            dtgcatalogo.DataSource = null;
            txtDescripcion.Text = "";
            txtId.Text = "";
            txtDetalles.Text = "";

            DataTable dt = new DataTable();
            dt = Proc.llenarCatalogo(_TipoCataolgo, txtbuscar.Text, activo);


            dtgcatalogo.AutoGenerateColumns = false;
            dtgcatalogo.ColumnCount = 4;

            dtgcatalogo.Columns[0].HeaderText = "ID";
            dtgcatalogo.Columns[0].DataPropertyName = "ID";
            dtgcatalogo.Columns[1].HeaderText = "Descripción";
            dtgcatalogo.Columns[1].DataPropertyName = "Descripcion";
            dtgcatalogo.Columns[2].HeaderText = "Detalle";
            dtgcatalogo.Columns[2].DataPropertyName = "Clave";
            dtgcatalogo.Columns[3].HeaderText = "Activo";
            dtgcatalogo.Columns[3].DataPropertyName = "Activo";


            dtgcatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgcatalogo.Columns[0].Visible = false;
            bindingSource1.DataSource = dt;
            dtgcatalogo.DataSource = bindingSource1;
            txtbuscar.Text = "";
        }

        private void dtgcatalogo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dtgcatalogo.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text= dtgcatalogo.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDetalles.Text= dtgcatalogo.Rows[e.RowIndex].Cells[2].Value.ToString();
            switch(dtgcatalogo.Rows[e.RowIndex].Cells[3].Value.ToString())
            {
                case "Si":
                   chkActivo.Checked = true;

                    break;
                case "No":
                    chkActivo.Checked = false;

                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id;
            if (txtDescripcion.Text == null)
            {
                MessageBox.Show("No se ha ingresado el valor a guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int activo = 0;

            if (string.IsNullOrEmpty(txtId.Text)==true)
            {
                id = 0;

            }
            else
            {
                id = int.Parse(txtId.Text);

            }

            if (chkActivo.Checked == true)
            { activo = 1; }
            Proc.IUCatalogo(_TipoCataolgo,id,txtDescripcion.Text,txtDetalles.Text, activo,_usuario);


            vtnbuscar.PerformClick();

        }
    }
}
