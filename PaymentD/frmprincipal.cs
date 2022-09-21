using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentD
{
    public partial class frmprincipal : Form
    {

        string _usuario, _nombre, _correo;
        int _tipo,_nomina;
        public frmprincipal(string Usuario,string Nombre,int Nomina,int tipo,string correo)
        {
            InitializeComponent();
            _usuario = Usuario;
            _nombre = Nombre;
            _tipo = tipo;
            _nomina = Nomina;
            _correo = correo;

        }

        private void consultarPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCaptura fr = new frmConsultaCaptura(_tipo,_nomina,_correo);
            fr.Show();
        }

        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(1, _usuario);
            fr.Text = "Catálogo de áreas";
            fr.Show();
        }

        private void centroDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(3, _usuario);
            fr.Text = "Catálogo de Centro de costos";
            fr.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(4, _usuario);
            fr.Text = "Catálogo de beneficiarios";
            fr.Show();
        }

        private void cnceptosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(5, _usuario);
            fr.Text = "Catálogo de Tipo de pago";
            fr.Show();
        }

        private void estatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(6, _usuario);
            fr.Text = "Catálogo de estatus";
            fr.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmUsuario fr = new frmUsuario(_usuario);
            fr.Text = "Catálogo de usuarios";
            fr.Show();
        }

        private void monedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(7, _usuario);
            fr.Text = "Catálogo de moneda";
            fr.Show();
        }

        private void tipoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(9, _usuario);
            fr.Text = "Catálogo de tpo de usuario";
            fr.Show();
        }

        private void tipoDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos fr = new frmCatalogos(8, _usuario);
            fr.Text = "Catálogo de tipo de docuemento";
            fr.Show();
        }

        private void newPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentCaptura fr = new frmPaymentCaptura(_nomina,_usuario,_nombre, _correo);
            fr.Show();

        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {
            if (_tipo == 1)
            {
                catalogosToolStripMenuItem.Visible = true;

            }
            else
            {

                catalogosToolStripMenuItem.Visible = false;
            }


        }
    }
}
