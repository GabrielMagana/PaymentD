using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentD
{
    public partial class frmConsultaCaptura : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSourceD = new BindingSource();
        private BindingSource bindingSourceDD = new BindingSource();
        public static string ConnectionString = ConfigurationManager.AppSettings["ConexionDB"];
        int _usuario, _tipoUsuario, Idpayment,ClaEstatusPerm;
        string usuariot,_correo;
        public frmConsultaCaptura( int TipoUsuario, int Usuario,string correo)
        {
            InitializeComponent();
            _usuario = Usuario;
            _tipoUsuario = TipoUsuario;
            esCaja.Enabled = false;
            esCaja.Visible = false;
            esinmediato.Enabled = false;
            esinmediato.Visible = false;
        }

        private void dtgPayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            int id,beneficiario=0,empleado=0,proveedor=0,renglon=0;
            renglon = dtgPayment.CurrentRow.Index;
            if (renglon > 0)
            {

                id = int.Parse(dtgPayment.Rows[e.RowIndex].Cells[0].Value.ToString());

                dt = Proc.BuscarEncabezado(id);


                proveedor = int.Parse(dt.Rows[0]["esProveedor"].ToString());

                if (proveedor == 0)
                {
                    beneficiario = 0;
                    checkBox1.Checked = false;
                    cmbBeneficiario.Visible = false;
                    cmbEmpleado.Visible = true;
                    empleado = int.Parse(dt.Rows[0]["claBeneficiario"].ToString());
                }
                else
                {
                    empleado = 0;
                    checkBox1.Checked = true;
                    cmbBeneficiario.Visible = true;
                    cmbEmpleado.Visible = false;
                    beneficiario = int.Parse(dt.Rows[0]["claBeneficiario"].ToString());
                }

                if (bool.Parse(dt.Rows[0]["PagadoSn"].ToString()) == false)
                {
                    esPagado.Checked = false;
                }
                else
                {
                    esPagado.Checked = true;
                }

                if (string.IsNullOrEmpty(dt.Rows[0]["esCajaChica"].ToString()) == true)

                {
                    esCaja.Checked = false;
                    esCaja.Visible = false;

                }
                else
                {

                    if (bool.Parse(dt.Rows[0]["esCajaChica"].ToString()) == false)
                    {
                        esCaja.Checked = false;
                        esCaja.Visible = false;

                    }
                    else
                    {
                        esCaja.Checked = true;
                        esCaja.Visible = true;
                    }
                }

                if (string.IsNullOrEmpty(dt.Rows[0]["esPagoInmediato"].ToString()) == true)

                {
                    esinmediato.Checked = false;
                    esinmediato.Visible = false;

                }
                else
                {
                    if (bool.Parse(dt.Rows[0]["esPagoInmediato"].ToString()) == false)
                    {
                        esinmediato.Checked = false;
                        esinmediato.Visible = false;

                    }
                    else
                    {
                        esinmediato.Checked = true;
                        esinmediato.Visible = true;
                    }
                }




                txtPorpuse.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFolio.Text = dt.Rows[0]["ClavePayment"].ToString();
                txtNumeroNomina.Text = dt.Rows[0]["IdSolicitante"].ToString();
                txtNombre.Text = dt.Rows[0]["NomUsuario"].ToString();
                usuariot = dt.Rows[0]["Usuario"].ToString();
                txtComentario.Text = dt.Rows[0]["txtObservaciones"].ToString();
                cmbArea.SelectedValue = int.Parse(dt.Rows[0]["IdArea"].ToString());
                cmbMpago.SelectedValue = int.Parse(dt.Rows[0]["ClaTipoPago"].ToString());
                cmbMoneda.SelectedValue = int.Parse(dt.Rows[0]["ClaMoneda"].ToString());
                cmbBeneficiario.SelectedValue = beneficiario;
                cmbAsignado.SelectedValue = int.Parse(dt.Rows[0]["IdEmpleadoAsign"].ToString());
                cmbEmpleado.SelectedValue = empleado;
                dtFechaPayment.Value = DateTime.Parse(dt.Rows[0]["DtFechaPago"].ToString());
                cmbEstatus.SelectedValue = int.Parse(dt.Rows[0]["ClaEstatus"].ToString());
                ClaEstatusPerm = int.Parse(dt.Rows[0]["ClaEstatus"].ToString());
                txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                Idpayment = id;



                if (ClaEstatusPerm == 4 || ClaEstatusPerm == 3 || _tipoUsuario == 2)
                {
                    txtComentario.Enabled = false;
                    cmbArea.Enabled = false;
                    cmbMpago.Enabled = false;
                    cmbMoneda.Enabled = false;
                    cmbBeneficiario.Enabled = false;
                    cmbAsignado.Enabled = false;
                    cmbEmpleado.Enabled = false;
                    checkBox1.Enabled = false;
                    cmbEstatus.Enabled = false;
                    btnActualizar.Visible = false;

                }
                else
                {
                    cmbEstatus.Enabled = true;
                    cmbAsignado.Enabled = true;
                    txtComentario.Enabled = true;
                    cmbMoneda.Enabled = true;
                    btnActualizar.Visible = true;
                }

                llenarDetalle(id);
            }
        }

        private void ConsultaCaptura_Load(object sender, EventArgs e)
        {
            Formato(_tipoUsuario);
            
            Proc.combos(cmbArea, 1);
            Proc.combos(cmbMpago, 5);
            Proc.combos(cmbMoneda, 3);
            Proc.combos(cmbEstatus, 2);
            Proc.combos(cmbBeneficiario, 7);
            Proc.combos(cmbEmpleado, 6);
            Proc.combos(cmbAsignado, 8);
            cmbArea.SelectedValue = 0;
            cmbMpago.SelectedValue = 0;
            cmbMoneda.SelectedValue = 0;
            cmbBeneficiario.SelectedValue = 0;
            cmbAsignado.SelectedValue = 0;
            cmbEmpleado.SelectedValue = 0;
            cmbEstatus.SelectedValue = 0;


            DataTable dt = new DataTable();
            dt = Proc.llenarData(_tipoUsuario,_usuario, dtpFecha.Value);


            dtgPayment.AutoGenerateColumns = false;
            dtgPayment.ColumnCount = 9;

            dtgPayment.Columns[0].HeaderText = "ID";
            dtgPayment.Columns[0].DataPropertyName = "idPayment";
            dtgPayment.Columns[1].HeaderText = "Folio";
            dtgPayment.Columns[1].DataPropertyName = "ClavePayment";
            dtgPayment.Columns[2].HeaderText = "Payment Porpuse";
            dtgPayment.Columns[2].DataPropertyName = "PaymentPorpuse";
            dtgPayment.Columns[3].HeaderText = "Solicitante";
            dtgPayment.Columns[3].DataPropertyName = "idSolicitante";
            dtgPayment.Columns[4].HeaderText = "Solicitante";
            dtgPayment.Columns[4].DataPropertyName = "NomSolicitante";
            dtgPayment.Columns[5].HeaderText = "Monto";
            dtgPayment.Columns[5].DataPropertyName = "Amount";
            dtgPayment.Columns[6].HeaderText = "Fecha Pago";
            dtgPayment.Columns[6].DataPropertyName = "dtFechaPago";
            dtgPayment.Columns[7].HeaderText = "Estatus";
            dtgPayment.Columns[7].DataPropertyName = "ClaEstatus";
            dtgPayment.Columns[8].HeaderText = "Estatus";
            dtgPayment.Columns[8].DataPropertyName = "NomEstatus";
      
            dtgPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = dt;
            dtgPayment.DataSource = bindingSource1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(Idpayment == null || Idpayment == 0)
            {
                MessageBox.Show("No se ha seleccionado un Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbMoneda.SelectedIndex == -1 || cmbMoneda.Text == "")
            {
                MessageBox.Show("Favor de Capturar la moneda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAsignado.SelectedIndex == -1 || cmbAsignado.Text == "")
            {
                MessageBox.Show("Favor de Capturar el usuario de finanzas asignado del Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(cmbEstatus.SelectedValue.ToString()) == -1 || cmbEstatus.Text == "")
            {
                MessageBox.Show("Favor de Capturar el Estatus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ClaEstatusPerm == 4 || ClaEstatusPerm == 3)
            {
                MessageBox.Show("Un Payment cerrado/pagado o cancelado no puede modificarse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (int.Parse(cmbEstatus.SelectedValue.ToString()) == 4 && ClaEstatusPerm == 1)
            {
                MessageBox.Show("Un Payment capturado no puede pagarse inmediatamente", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (int.Parse(cmbEstatus.SelectedValue.ToString()) == 1 && ClaEstatusPerm == 2)
                {
                    MessageBox.Show("Un Payment en proceso no puede ponerse como capturado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
           


            Proc.ActualizarPayment(usuariot, Idpayment, txtComentario.Text, int.Parse(cmbEstatus.SelectedValue.ToString()), int.Parse(cmbMoneda.SelectedValue.ToString()), int.Parse(cmbAsignado.SelectedValue.ToString()),txtPorpuse.Text,_correo);
            llenarleer(Idpayment);
            llenarDetalle(Idpayment);

        }

        private void btnActualizarP_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = Proc.llenarData(_tipoUsuario, _usuario, dtpFecha.Value);


            dtgPayment.AutoGenerateColumns = false;


            dtgPayment.Columns[0].HeaderText = "ID";
            dtgPayment.Columns[0].DataPropertyName = "idPayment";
            dtgPayment.Columns[1].HeaderText = "Folio";
            dtgPayment.Columns[1].DataPropertyName = "ClavePayment";
            dtgPayment.Columns[2].HeaderText = "Payment Porpuse";
            dtgPayment.Columns[2].DataPropertyName = "PaymentPorpuse";
            dtgPayment.Columns[3].HeaderText = "Solicitante";
            dtgPayment.Columns[3].DataPropertyName = "idSolicitante";
            dtgPayment.Columns[4].HeaderText = "Solicitante";
            dtgPayment.Columns[4].DataPropertyName = "NomSolicitante";
            dtgPayment.Columns[5].HeaderText = "Monto";
            dtgPayment.Columns[5].DataPropertyName = "Amount";
            dtgPayment.Columns[6].HeaderText = "Fecha Pago";
            dtgPayment.Columns[6].DataPropertyName = "dtFechaPago";
            dtgPayment.Columns[7].HeaderText = "Estatus";
            dtgPayment.Columns[7].DataPropertyName = "ClaEstatus";
            dtgPayment.Columns[8].HeaderText = "Estatus";
            dtgPayment.Columns[8].DataPropertyName = "NomEstatus";

            dtgPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = dt1;
            dtgPayment.DataSource = bindingSource1;
        }

        private void dtgPaymentDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_tipoUsuario == 1)
            {
                if (dtgPaymentDocs.CurrentRow.Index>0)
                {
                    DataTable dtdocs = new DataTable();
                    int IdPayments, iddocs;
                    byte[] archivo = null;

                    string path = "C:\\";
                    string folder = path + "tempDocs\\";
                    string fullfilepath;

                    IdPayments = int.Parse(dtgPaymentDocs.Rows[e.RowIndex].Cells[0].Value.ToString());
                    iddocs = int.Parse(dtgPaymentDocs.Rows[e.RowIndex].Cells[1].Value.ToString());

                    fullfilepath = folder + dtgPaymentDocs.Rows[e.RowIndex].Cells[3].Value;

                    DataTable Ds = new DataTable();

                    string sql = "[dbo].[BuscardocumentoSel]";

                    using (SqlConnection conn1 = new SqlConnection(ConnectionString))
                    {
                        conn1.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn1);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPayment", IdPayments);
                        cmd.Parameters.AddWithValue("@IdArchivo", iddocs);
                        cmd.CommandTimeout = 420;

                        archivo = (byte[])cmd.ExecuteScalar();

                    }

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    if (File.Exists(fullfilepath))
                        File.Delete(fullfilepath);

                    File.WriteAllBytes(fullfilepath, archivo);

                    Process.Start(fullfilepath);


                    MessageBox.Show("El documento fue creado con exito en la ruta: " + fullfilepath, "Descarga exitosa", MessageBoxButtons.OK);
                }
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Formato(int tipo)
        {
            if (tipo == 2)
            {

                txtComentario.Enabled = false;
                cmbArea.Enabled = false;
                cmbMpago.Enabled = false;
                cmbMoneda.Enabled = false;
                cmbBeneficiario.Enabled = false;
                cmbAsignado.Enabled = false;
                cmbEmpleado.Enabled = false;
                checkBox1.Enabled= false;
                cmbEstatus.Enabled=false;
                btnActualizar.Visible = false;


            }

        }

        private void llenarleer(int IdPayment)
        {
            DataTable dt1 = new DataTable();
            dt1 = Proc.llenarData(_tipoUsuario, _usuario, dtpFecha.Value);


            dtgPayment.AutoGenerateColumns = false;
    

            dtgPayment.Columns[0].HeaderText = "ID";
            dtgPayment.Columns[0].DataPropertyName = "idPayment";
            dtgPayment.Columns[1].HeaderText = "Folio";
            dtgPayment.Columns[1].DataPropertyName = "ClavePayment";
            dtgPayment.Columns[2].HeaderText = "Payment Porpuse";
            dtgPayment.Columns[2].DataPropertyName = "PaymentPorpuse";
            dtgPayment.Columns[3].HeaderText = "Solicitante";
            dtgPayment.Columns[3].DataPropertyName = "idSolicitante";
            dtgPayment.Columns[4].HeaderText = "Solicitante";
            dtgPayment.Columns[4].DataPropertyName = "NomSolicitante";
            dtgPayment.Columns[5].HeaderText = "Monto";
            dtgPayment.Columns[5].DataPropertyName = "Amount";
            dtgPayment.Columns[6].HeaderText = "Fecha Pago";
            dtgPayment.Columns[6].DataPropertyName = "dtFechaPago";
            dtgPayment.Columns[7].HeaderText = "Estatus";
            dtgPayment.Columns[7].DataPropertyName = "ClaEstatus";
            dtgPayment.Columns[8].HeaderText = "Estatus";
            dtgPayment.Columns[8].DataPropertyName = "NomEstatus";

            dtgPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = dt1;
            dtgPayment.DataSource = bindingSource1;

            DataTable dt = new DataTable();
            int id, beneficiario = 0, empleado = 0, proveedor = 0;

             dt = Proc.BuscarEncabezado(IdPayment);


            proveedor = int.Parse(dt.Rows[0]["esProveedor"].ToString());

            if (proveedor == 0)
            {
                beneficiario = 0;
                checkBox1.Checked = false;
                cmbBeneficiario.Visible = false;
                cmbEmpleado.Visible = true;
                empleado = int.Parse(dt.Rows[0]["claBeneficiario"].ToString());
            }
            else
            {
                empleado = 0;
                checkBox1.Checked = true;
                cmbBeneficiario.Visible = true;
                cmbEmpleado.Visible = false;
                beneficiario = int.Parse(dt.Rows[0]["claBeneficiario"].ToString());
            }

            if (bool.Parse(dt.Rows[0]["PagadoSn"].ToString()) == false)
            {
                esPagado.Checked = false;
            }
            else
            {
                esPagado.Checked = true;
            }



            txtPorpuse.Text = dt.Rows[0]["Descripcion"].ToString();
            txtFolio.Text = dt.Rows[0]["ClavePayment"].ToString();
            txtNumeroNomina.Text = dt.Rows[0]["IdSolicitante"].ToString();
            txtNombre.Text = dt.Rows[0]["NomUsuario"].ToString();
            usuariot = dt.Rows[0]["Usuario"].ToString();
            txtComentario.Text = dt.Rows[0]["txtObservaciones"].ToString();
            cmbArea.SelectedValue = int.Parse(dt.Rows[0]["IdArea"].ToString());
            cmbMpago.SelectedValue = int.Parse(dt.Rows[0]["ClaTipoPago"].ToString());
            cmbMoneda.SelectedValue = int.Parse(dt.Rows[0]["ClaMoneda"].ToString());
            cmbBeneficiario.SelectedValue = beneficiario;
            cmbAsignado.SelectedValue = int.Parse(dt.Rows[0]["IdEmpleadoAsign"].ToString());
            cmbEmpleado.SelectedValue = empleado;
            dtFechaPayment.Value = DateTime.Parse(dt.Rows[0]["DtFechaPago"].ToString());
            cmbEstatus.SelectedValue = int.Parse(dt.Rows[0]["ClaEstatus"].ToString());
            ClaEstatusPerm = int.Parse(dt.Rows[0]["ClaEstatus"].ToString());
            txtAmount.Text = dt.Rows[0]["Amount"].ToString();
            Idpayment = IdPayment;
            _correo= dt.Rows[0]["email"].ToString();


            if (ClaEstatusPerm == 4 || ClaEstatusPerm == 3)
            {
                txtComentario.Enabled = false;
                cmbArea.Enabled = false;
                cmbMpago.Enabled = false;
                cmbMoneda.Enabled = false;
                cmbBeneficiario.Enabled = false;
                cmbAsignado.Enabled = false;
                cmbEmpleado.Enabled = false;
                checkBox1.Enabled = false;
                cmbEstatus.Enabled = false;

            }
            else
            {
                cmbEstatus.Enabled = true;
                cmbAsignado.Enabled = true;
                txtComentario.Enabled = true;
                cmbMoneda.Enabled = true;
            }


        }
        private void llenarDetalle(int IdPayment)
        {
            DataTable dt = new DataTable();
            DataTable dacs = new DataTable();

            dt = Proc.llenarDetalle(IdPayment);
            dacs= Proc.llenarDetalleDocs(IdPayment);

            if (dt.Rows.Count > 0)
            {

                if (dtgPaymentDet.Rows.Count != 0)
                { dtgPaymentDet.DataSource = null; }
                if (dtgPaymentDocs.Rows.Count != 0)
                { dtgPaymentDocs.DataSource = null; }



                dtgPaymentDet.AutoGenerateColumns = false;
                dtgPaymentDet.ColumnCount = 6;

                dtgPaymentDet.Columns[0].HeaderText = "ID";
                dtgPaymentDet.Columns[0].DataPropertyName = "idPayment";
                dtgPaymentDet.Columns[1].HeaderText = "IdPaymentEnc";
                dtgPaymentDet.Columns[1].DataPropertyName = "PaymentDet";
                dtgPaymentDet.Columns[2].HeaderText = "Id Costo";
                dtgPaymentDet.Columns[2].DataPropertyName = "IdCostCenter";
                dtgPaymentDet.Columns[3].HeaderText = "Clave Centro de Costos";
                dtgPaymentDet.Columns[3].DataPropertyName = "ClaveCentro";
                dtgPaymentDet.Columns[4].HeaderText = "Centro de Costos";
                dtgPaymentDet.Columns[4].DataPropertyName = "NomCostos";
                dtgPaymentDet.Columns[5].HeaderText = "Monto ($)";
                dtgPaymentDet.Columns[5].DataPropertyName = "AmountD";


                dtgPaymentDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceD.DataSource = dt;
                dtgPaymentDet.DataSource = bindingSourceD;


                if (dacs.Rows.Count > 0)
                {
                    dtgPaymentDocs.AutoGenerateColumns = false;
                    dtgPaymentDocs.ColumnCount = 5;

                    dtgPaymentDocs.Columns[0].HeaderText = "ID";
                    dtgPaymentDocs.Columns[0].DataPropertyName = "idPayment";
                    dtgPaymentDocs.Columns[1].HeaderText = "Id Archivo";
                    dtgPaymentDocs.Columns[1].DataPropertyName = "IdArchivo";
                    dtgPaymentDocs.Columns[2].HeaderText = "Tipo Documento";
                    dtgPaymentDocs.Columns[2].DataPropertyName = "NomTipoDocumento";
                    dtgPaymentDocs.Columns[3].HeaderText = "Documento";
                    dtgPaymentDocs.Columns[3].DataPropertyName = "NombreDocumento";
                    dtgPaymentDocs.Columns[4].HeaderText = "Extension";
                    dtgPaymentDocs.Columns[4].DataPropertyName = "ExtensionDocumento";




                    dtgPaymentDocs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    bindingSourceDD.DataSource = dacs;
                    dtgPaymentDocs.DataSource = bindingSourceDD;
                }
            }
            

        }

    }
}
