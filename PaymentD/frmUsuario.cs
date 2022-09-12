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
    public partial class frmUsuario : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
     
        public static string ConnectionString = ConfigurationManager.AppSettings["ConexionDB"];
        
        string _usuario;
        public frmUsuario(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Proc.combos(cmbTipo, 9);
        }

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = Proc.llenarUsuario("",1);


            dtgUsuario.AutoGenerateColumns = false;
            dtgUsuario.ColumnCount = 7;

            dtgUsuario.Columns[0].HeaderText = "Nomina";
            dtgUsuario.Columns[0].DataPropertyName = "ClaUsuario";
            dtgUsuario.Columns[1].HeaderText = "Nombre";
            dtgUsuario.Columns[1].DataPropertyName = "NomUsuario";
            dtgUsuario.Columns[2].HeaderText = "Usuario";
            dtgUsuario.Columns[2].DataPropertyName = "Usuario";
            dtgUsuario.Columns[3].HeaderText = "Mail";
            dtgUsuario.Columns[3].DataPropertyName = "Email";
            dtgUsuario.Columns[4].HeaderText = "T";
            dtgUsuario.Columns[4].DataPropertyName = "claTipoUsuario";
            dtgUsuario.Columns[5].HeaderText = "Tipo Usuario";
            dtgUsuario.Columns[5].DataPropertyName = "NomTipoUsuario";
            dtgUsuario.Columns[6].HeaderText = "Activo";
            dtgUsuario.Columns[6].DataPropertyName = "Activo";


            dtgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgUsuario.Columns[4].Visible = false;
            bindingSource1.DataSource = dt;
            dtgUsuario.DataSource = bindingSource1;
        }

        private void vtnbuscar_Click(object sender, EventArgs e)
        {

            int activo=0;

            if(chkAct.Checked == true)
            { activo = 1; }

            dtgUsuario.DataSource = null;
            txtDescripcion.Text = "";
            txtId.Text = "";
            txtDetalles.Text = "";
            txtEmail.Text = "";

            DataTable dt = new DataTable();
            dt = Proc.llenarUsuario(txtbuscar.Text, 1); ;


       

            dtgUsuario.Columns[0].HeaderText = "Nomina";
            dtgUsuario.Columns[0].DataPropertyName = "ClaUsuario";
            dtgUsuario.Columns[1].HeaderText = "Nombre";
            dtgUsuario.Columns[1].DataPropertyName = "NomUsuario";
            dtgUsuario.Columns[2].HeaderText = "Usuario";
            dtgUsuario.Columns[2].DataPropertyName = "Usuario";
            dtgUsuario.Columns[3].HeaderText = "Mail";
            dtgUsuario.Columns[3].DataPropertyName = "Email";
            dtgUsuario.Columns[4].HeaderText = "T";
            dtgUsuario.Columns[4].DataPropertyName = "claTipoUsuario";
            dtgUsuario.Columns[5].HeaderText = "Tipo Usuario";
            dtgUsuario.Columns[5].DataPropertyName = "NomTipoUsuario";
            dtgUsuario.Columns[6].HeaderText = "Activo";
            dtgUsuario.Columns[6].DataPropertyName = "Activo";


            dtgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
            bindingSource1.DataSource = dt;
            dtgUsuario.DataSource = bindingSource1;
            txtbuscar.Text = "";
            txtDescripcion.Text = "";
            txtId.Text = "";
            txtDetalles.Text = "";
            txtEmail.Text = "";
        }

        private void dtgcatalogo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            txtId.Text = dtgUsuario.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text= dtgUsuario.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDetalles.Text= dtgUsuario.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text= dtgUsuario.Rows[e.RowIndex].Cells[3].Value.ToString();
            switch(dtgUsuario.Rows[e.RowIndex].Cells[6].Value.ToString())
            {
                case "Si":
                   chkActivo.Checked = true;

                    break;
                case "No": 
                    chkActivo.Checked = false;

                    break;
            }
            if(string.IsNullOrEmpty(dtgUsuario.Rows[e.RowIndex].Cells[4].Value.ToString()))
            {
                cmbTipo.SelectedValue = -1;
              
                }
            else
            {
                cmbTipo.SelectedValue = int.Parse(dtgUsuario.Rows[e.RowIndex].Cells[4].Value.ToString());
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == null || txtDescripcion.Text == "")
            {
                MessageBox.Show("No se ha ingresado un valor a guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTipo.SelectedValue==null)
            {
                MessageBox.Show("No se ha ingresado un tipo de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int activo = 0;

            if (chkActivo.Checked == true)
            { activo = 1; }
            Proc.IUUsuario(int.Parse(txtId.Text),int.Parse(cmbTipo.SelectedValue.ToString()),_usuario);

            vtnbuscar.PerformClick();

        }
    }
}
