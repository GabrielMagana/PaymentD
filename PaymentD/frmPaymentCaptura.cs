using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaymentD;

namespace PaymentD
{
    public partial class frmPaymentCaptura : Form
    {
        string _usuario, _nomcompleto,_correo;
        int _nnomina,escaja,espago;
        string[] name = new string[5];
        string[] ext = new string[5];

        byte[] _streamFA, _streamP, _streamInvpdf, _streamxml, _streamb2b;
        string _nameFA, _nameP, _nameInvpdf, _nameInvxml, _nameb2b;
        string _extFA, _extP, _extnvpdf, _extInvxml, _extb2b;
        bool PaymentU = false;

        public frmPaymentCaptura(int NNomina, string Usuario, string NomCompleto,string correo)
        {
            InitializeComponent();
            Proc.combos(cmbArea, 1);
            Proc.combos(cmbMpago, 5);
            Proc.combos(cmbMoneda, 3);
            Proc.combos(cmbEstatus, 2);
            Proc.combos(cmbCliente, 7);
            Proc.combos(cmbAsignado, 8);
          
            Proc.combos(cmbCcostos, 4);
            cmbArea.SelectedValue = 1;
            cmbMpago.SelectedValue = 1;
            cmbMoneda.SelectedValue = 1;
            cmbCliente.SelectedValue = 1;
            cmbAsignado.SelectedValue = 0;
         
            cmbCcostos.SelectedValue = 1;
            checkBox1.Checked = true;
            checkBox1.Enabled = false;
            cmbCliente.Visible = true;
            label10.Visible = true;
            cmbEstatus.Enabled = false;
            _nnomina = NNomina;
            _usuario = Usuario;
            _nomcompleto = NomCompleto;
            _correo = correo;
            lstCC.Columns[0].Width = 0;
            chkCaja.Visible = false;
            chkpago.Visible = false;
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
        }

        private void chkCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCaja.Checked)
            { escaja = 1; }
            else
            { escaja = 0; }
        }

        private void frmPaymentCaptura_Load(object sender, EventArgs e)
        {

            Proc.Determinarfecha(dtFechaPayment);
            txtNumeroNomina.Text = _nnomina.ToString();
            txtNumeroNomina.Enabled = false;
            txtNombre.Text = _nomcompleto;
            txtNombre.Enabled = false;
        }
       

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.GetItemText(cmbCliente.SelectedItem) == "PROVEEDORES VARIOS")
            { chkCaja.Visible = true; }
            else { chkCaja.Visible = false; chkCaja.Checked = false; }

            if (cmbCliente.GetItemText(cmbCliente.SelectedItem) == "PROVEEDORES VARIOS" || cmbCliente.GetItemText(cmbCliente.SelectedItem) == "ANTICIPO PCR" || cmbCliente.GetItemText(cmbCliente.SelectedItem) == "SI VALE MEXICO SA DE CV" )
            {
                chkpago.Visible = true;
            }
            else
            {
                chkpago.Visible = false;
                chkpago.Checked = false;
                
            }

            if (cmbCliente.GetItemText(cmbCliente.SelectedItem) == "LICENCIAS" || cmbCliente.GetItemText(cmbCliente.SelectedItem) == "PROVEEDORES VARIOS" || cmbCliente.GetItemText(cmbCliente.SelectedItem) == "SECRETARIA DE HACIENDA Y CREDITO PUBLICO" || cmbCliente.GetItemText(cmbCliente.SelectedItem) == "SECRETARIA DE FINANZAS, INVERSION Y ADMINISTRACION")
            {
                PaymentU = true;
               
            }
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCC.Items.Count>0)
            {
                MessageBox.Show("Ya tienes centros de costo para un tipo de moneda, si quieres cambiar limpia el listado e ingresa de nuevo", "warning", MessageBoxButtons.OK);
            }
        }

        private void chkpago_CheckedChanged(object sender, EventArgs e)
        {
            if(chkpago.Checked==true)
            {
                espago = 1;
               
                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(1);
                            break;
                        case DayOfWeek.Tuesday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(1);
                            break;
                        case DayOfWeek.Sunday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(1);
                            break;
                
                        case DayOfWeek.Wednesday:

                            dtFechaPayment.Value = DateTime.Now.AddDays(1);
                            break;
                        case DayOfWeek.Thursday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(1);
                            break;
                        case DayOfWeek.Friday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(3);
                            break;
                        case DayOfWeek.Saturday:
                            dtFechaPayment.Value = DateTime.Now.AddDays(2);
                            break;

                    }
                
            }
            else
            {
                Proc.Determinarfecha(dtFechaPayment);
                espago = 0;
            }
        }

    
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               
               
                cmbCliente.Visible = true;
                label10.Visible = true;
            }
            else
            {
               
              
                cmbCliente.Visible = false;
                label10.Visible = true;
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            int cmbClientea=0, cmbempleado,onlypay=0;
            bool check=false;

            if (string.IsNullOrWhiteSpace(txtPorpuse.Text) || string.IsNullOrEmpty(txtPorpuse.Text))
            {
                MessageBox.Show("Favor de Capturar el titulo del Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbArea.SelectedIndex ==-1 || cmbArea.Text =="")
            {
                MessageBox.Show("Favor de Capturar el área del Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbMpago.SelectedIndex == -1 || cmbMpago.Text =="")
            {
                MessageBox.Show("Favor de Capturar el metodo de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkBox1.Checked)
            {
                if (cmbCliente.SelectedIndex == -1 || cmbCliente.Text == "")
                {
                    MessageBox.Show("Favor de Capturar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                cmbClientea = int.Parse(cmbCliente.SelectedValue.ToString());
                cmbempleado = 0;
            }
        
            



            if (cmbMoneda.SelectedIndex == -1 || cmbMoneda.Text =="")
            {
                MessageBox.Show("Favor de Capturar la moneda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            if (cmbAsignado.SelectedIndex == -1 || cmbAsignado.Text =="")
            {
                MessageBox.Show("Favor de Capturar el usuario de finanzas asignado del Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                                        
            if (cmbEstatus.SelectedIndex == -1 || cmbEstatus.Text == "")
            {
                MessageBox.Show("Favor de Capturar el Estatus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lstCC.Items.Count==0)
            {
                MessageBox.Show("Favor de Capturar los centros de costos del payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (PaymentU == false)
            {
                if (string.IsNullOrWhiteSpace(_nameFA))
                {
                    MessageBox.Show("Favor de cargar el formato de aprobación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_nameP))
                {
                    MessageBox.Show("Favor de cargar el formato de Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (chkCaja.Checked == true || cmbMpago.GetItemText(cmbMpago.SelectedItem) == "Transferencia Internacional")
                {
                    if (string.IsNullOrWhiteSpace(_nameInvpdf))
                    {
                        MessageBox.Show("Favor de cargar el formato de factura pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(_nameInvpdf) || string.IsNullOrWhiteSpace(_nameInvxml))
                    {
                        MessageBox.Show("Favor de cargar el formato de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else
            {
                onlypay = 1;
                if (string.IsNullOrWhiteSpace(_nameP))
                {
                    MessageBox.Show("Favor de cargar el formato de Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                
                }

            }



           if (checkBox1.Checked)
            {
                check = true;
            }
          

            Proc.GeneraPayment(check,onlypay, lstCC, txtPorpuse.Text, int.Parse(cmbArea.SelectedValue.ToString()),dtFechaPayment.Value, int.Parse(cmbAsignado.SelectedValue.ToString()), cmbClientea,  int.Parse(cmbMpago.SelectedValue.ToString()), int.Parse(cmbMoneda.SelectedValue.ToString()),_usuario, int.Parse(cmbEstatus.SelectedValue.ToString()), txtComentario.Text,  _nnomina, _streamFA,_streamP, _streamInvpdf, _streamxml, _streamb2b, name, ext,_correo,escaja,espago) ;
            txtPorpuse.Text = string.Empty;
            txtComentario.Text = string.Empty; 
            txtMonto.Text = string.Empty;
            cmbAsignado.Text = string.Empty;
            btnLimpiar.PerformClick();
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            _nameP = "";
            _nameInvpdf = "";
            _nameInvxml = "";
            _nameFA = "";
            _nameb2b = "";
            PaymentU = false;
            cmbCliente.Text = string.Empty;



        }
        private void btnAgregarCC_Click(object sender, EventArgs e)
        {
            bool Existe = false;
            decimal valor;
            if (!string.IsNullOrWhiteSpace(txtMonto.Text))
            {

                if (lstCC.Items.Count == 0)
                {
                    ListViewItem lista = new ListViewItem(cmbCcostos.SelectedValue.ToString());
                    lista.SubItems.Add(cmbCcostos.Text);
                    lista.SubItems.Add(txtMonto.Text);
                    lista.SubItems.Add(cmbMoneda.GetItemText(cmbMoneda.SelectedItem));
                    lstCC.Items.Add(lista);
                }
                else
                {
                    for (int i = 0; i < lstCC.Items.Count; i++)
                    {
                        int ii = 1;
                        if (cmbCcostos.SelectedValue.ToString() == lstCC.Items[i].SubItems[0].Text)
                        {
                            if (string.IsNullOrWhiteSpace(lstCC.Items[i].SubItems[2].Text))
                            { lstCC.Items[i].SubItems[2].Text = "0"; }

                            valor = decimal.Parse(lstCC.Items[i].SubItems[2].Text) + decimal.Parse(txtMonto.Text);
                            lstCC.Items[i].SubItems[2].Text = valor.ToString();
                            Existe = true;


                        }

                        //MessageBox.Show(ltvArticulos.Items[i].SubItems[ii].Text);
                        ii++;
                    }

                    if (Existe == false)
                    {
                        ListViewItem lista = new ListViewItem(cmbCcostos.SelectedValue.ToString());
                        lista.SubItems.Add(cmbCcostos.Text);
                        lista.SubItems.Add(txtMonto.Text);
                        lista.SubItems.Add(cmbMoneda.GetItemText(cmbMoneda.SelectedItem));
                        lstCC.Items.Add(lista);
                    }

                }
                Existe = false;

                lstCC.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            }
            else
            {

                MessageBox.Show("Favor de capturar un monto", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void cmbCcostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonto.Text = "";
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstCC.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string _nomdocument, _extdocumento, _tipoDocuemnto,path;
            
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "(*.pdf)|*.pdf";
            openFileDialog1.FilterIndex = 1;
         
           


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    _streamFA = ms.ToArray();
                }

                _nameFA = Path.GetFileName(openFileDialog1.FileName);
                _extFA = Path.GetExtension(openFileDialog1.FileName);
                name[0] = _nameFA;
                ext[0] = _extFA;
                label11.Visible = true;
                label11.Text = _nameFA;
            }
           

        }
        private void btnB2b_Click(object sender, EventArgs e)
        {
            string _nomdocument, _extdocumento, _tipoDocuemnto, path;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "(*.pdf)|*.pdf";
            openFileDialog1.FilterIndex = 1;
            



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    _streamb2b = ms.ToArray();
                }

                _nameb2b = Path.GetFileName(openFileDialog1.FileName);
                _extb2b = Path.GetExtension(openFileDialog1.FileName);
                name[4] = _nameb2b;
                ext[4] = _extb2b;
                label17.Visible = true;
                label17.Text = _nameb2b;

            }
           
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            string _nomdocument, _extdocumento, _tipoDocuemnto, path;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "(*.pdf)|*.pdf|(*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
   




            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);

                    switch (Path.GetExtension(openFileDialog1.FileName))
                    {
                        case ".pdf":
                            _streamInvpdf = ms.ToArray();
                            break;
                        case ".xml":
                            _streamxml = ms.ToArray();
                            break;
                    }
                }


                switch (Path.GetExtension(openFileDialog1.FileName))
                {
                    case ".pdf":
                        _nameInvpdf = Path.GetFileName(openFileDialog1.FileName);
                        _extnvpdf = Path.GetExtension(openFileDialog1.FileName);
                        label14.Visible = true;
                        label14.Text = _nameInvpdf;
                        name[2] = _nameInvpdf;
                        ext[2] = _extnvpdf;
                        break;
                    case ".xml":
                        _nameInvxml = Path.GetFileName(openFileDialog1.FileName);
                        _extInvxml = Path.GetExtension(openFileDialog1.FileName);
                        label16.Visible = true;
                        label16.Text = _nameInvxml;
                        name[3] = _nameInvxml;
                        ext[3] = _extInvxml;
                        break;
                }
            

            }
        }


        private void btnPayment_Click(object sender, EventArgs e)
        {
            string _nomdocument, _extdocumento, _tipoDocuemnto, path;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "(*.pdf)|*.pdf";
            openFileDialog1.FilterIndex = 1;
   


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    _streamP = ms.ToArray();
                }

                _nameP = Path.GetFileName(openFileDialog1.FileName);
                _extP = Path.GetExtension(openFileDialog1.FileName);
                name[1] = _nameP;
                ext[1] = _extP;
                label15.Visible = true;
                label15.Text = _nameP;
            }

           

        }
    }
}
