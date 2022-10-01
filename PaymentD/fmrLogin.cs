using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Data.SqlClient;
namespace PaymentD
{
    public partial class fmrLogin : Form
    {

        string Usuario, NombreCompleto;
        string correo = string.Empty;
        int Nomina, Permiso=0;
        public fmrLogin()
        {
            InitializeComponent();
        }

        private void fmrLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Favor de capturar el usuario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Favor de capturar la contraseña", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = new DataTable();
            if (txtUsuario.Text.Contains("mmvouser"))
            {
                try
                {
                    
                    dt = Proc.ValidarUsuarios(txtUsuario.Text, txtPassword.Text);

                    Usuario = dt.Rows[0]["Usuario"].ToString().Trim();
                    NombreCompleto = dt.Rows[0]["NomUsuario"].ToString().Trim();
                    Nomina = int.Parse(dt.Rows[0]["ClaUsuario"].ToString().Trim());
                    correo = dt.Rows[0]["email"].ToString().Trim();

                    if (string.IsNullOrEmpty(dt.Rows[0]["ClaTipoUsuario"].ToString().Trim()) == true)
                    {
                        Permiso = 0;
                        MessageBox.Show("Favor de comunicarse al área de finanzas para poder acceder al programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        Permiso = int.Parse(dt.Rows[0]["ClaTipoUsuario"].ToString().Trim());
                        frmprincipal frm = new frmprincipal(Usuario, NombreCompleto, Nomina, Permiso, correo);
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Favor de comunicarse al área de finanzas para poder acceder al programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (AutenticatheUser(txtUsuario.Text, txtPassword.Text))
                {


                    frmprincipal frm = new frmprincipal(Usuario, NombreCompleto, Nomina, Permiso, correo);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();

                }
            }
        }
       
        private bool AutenticatheUser(String userName, String password)
        {
            bool ret = false;
            string NombreCompleto, NTusername;

            try
            {
                DirectoryEntry de = new DirectoryEntry(GetCurrentDomainPath(), userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                dsearch.Filter = "sAMAccountName=" + userName + "";
                SearchResult results = null;

                results = dsearch.FindOne();

                NombreCompleto = results.GetDirectoryEntry().Properties["DisplayName"].Value.ToString();
                NTusername = results.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
                correo = results.GetDirectoryEntry().Properties["mail"].Value.ToString();//correo

                GetNTuser(txtUsuario.Text);

                if (Permiso!=0)
                {
                  ret = true;

                }
                else
                {
                    MessageBox.Show("La información proporcionada en correcta,\n pero su usuario no tiene permiso para utilizar el sistema.\nFavor de contactar al administrador del Sistema.");
                }
            }
            catch (Exception ex)
            {
                ret = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ret;

        }
        private string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");
            //DAP://na.miempresa.com
            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
        }
         
        //private void txtPassword_Enter(object sender, EventArgs e)
        //{
        //    btnLogin.PerformClick();
        //}

        bool status = false;
        public void GetNTuser(string NTuserAD)
        {
            DataTable dt = new DataTable();
            dt = Proc.ValidarUsuarios(NTuserAD,"");
            Usuario = dt.Rows[0]["Usuario"].ToString().Trim();
            NombreCompleto = dt.Rows[0]["NomUsuario"].ToString().Trim();
            Nomina = int.Parse(dt.Rows[0]["ClaUsuario"].ToString().Trim());

            if(string.IsNullOrEmpty(dt.Rows[0]["ClaTipoUsuario"].ToString().Trim())==true)
            {
                Permiso = 0;
            }
            else
            {
                Permiso = int.Parse(dt.Rows[0]["ClaTipoUsuario"].ToString().Trim());
            }
            


        }

    
    }
}
