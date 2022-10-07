using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace PaymentD
{


    public class Proc
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["ConexionDB"];
        public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string emailsupervisor;
        public static string MailNotify;
        public static string pass;

        string Pc = Environment.MachineName;
        public static void combos(ComboBox obj, int opcion,int opcion2)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand("dbo.combos", conn1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@opcion", opcion);
                cmd.Parameters.AddWithValue("@opcion2", opcion2);

                SqlDataAdapter Lector = new SqlDataAdapter(cmd);
                Lector.Fill(dt);

                obj.DisplayMember = "descripcion";
                obj.ValueMember = "id";
                obj.DataSource = dt;

            }


        }

        public static DataTable ObtenerConfiguraciones(int configuracion)
        {
            DataTable config = new DataTable();

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand("dbo.ConfiguracionSel", conn1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Configuracion", configuracion);

                SqlDataAdapter Lector = new SqlDataAdapter(cmd);
                Lector.Fill(config);
                

            }


            return config;
        }

        public static void  IUCatalogo(int tipo,int id,string desc,string details,int activo,string usuario)
        {

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();

                SqlCommand cmd = conn1.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = conn1.BeginTransaction();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                cmd.Connection = conn1;
                cmd.Transaction = transaction;
                try
                {

                    cmd.CommandText = "dbo.CatalogosUI";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@opcion", tipo);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Clave", details);
                    cmd.Parameters.AddWithValue("@Descripcion", desc);
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                  

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se actualizado correctamente", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show("No se actualizo correctamentr, favor de contactar al personal de Finanzas o de IT");
                }

            }
        }
        public static void IUUsuario(int id, int Tipo, string usuario)
        {

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();

                SqlCommand cmd = conn1.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = conn1.BeginTransaction();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                cmd.Connection = conn1;
                cmd.Transaction = transaction;
                try
                {

                    cmd.CommandText = "dbo.UsuariosUI";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClaUsuario", id);
                    cmd.Parameters.AddWithValue("@TipoUSuario", Tipo);
                    cmd.Parameters.AddWithValue("@usuario", usuario);



                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Se actualizado correctamente", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show("No se actualizo correctamentr, favor de contactar al personal de Finanzas o de IT");
                }

            }
        }
        public static void ActualizarPayment(string usuario,int payment,string comentarios,int estatus,int moneda, int empleado,string porpuse,string usuarioCorreo)
        {
            int tipocorreo=0;
            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();

                SqlCommand cmd = conn1.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = conn1.BeginTransaction();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                cmd.Connection = conn1;
                cmd.Transaction = transaction;
                try
                {

                    cmd.CommandText = "dbo.ActualizarPaymentU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPayment", payment);
                cmd.Parameters.AddWithValue("@comentarios", comentarios);
                cmd.Parameters.AddWithValue("@estatus", estatus);
                cmd.Parameters.AddWithValue("@moneda", moneda);
                cmd.Parameters.AddWithValue("@empleado", empleado);
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Payment actualizado correctamente","Payment",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                    switch (estatus)
                        {
                        case 2:
                            tipocorreo = 2;
                            break;
                        case 3:
                            tipocorreo = 4;
                            break;
                        case 4:
                            tipocorreo = 3;
                            break;
                    }
                 enviocorreo(tipocorreo, usuarioCorreo, porpuse, comentarios);

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show("Payment no se actualizo correctamentr, favor de contactar al personal de Finanzas o de IT");
                }

            }


        }
        public static void GeneraPayment(bool check,int onlypayment,ListView Lcc, string porpuse, int cmbArea,DateTime fechaPago, int cmbEmpleadoAsig,int cmbCliente,int cmbTipoPago,
            int cmbMoneda,string usuario,int cmbEstatus,string Comentarios,int Nomina, byte[] FA, byte[] P, byte[] ipdf, byte[] ixml,byte[] b2b, string[] Name, string[] ext,string usuarioCorreo,int caja, int pagoinm)
        {
            DataTable dt = new DataTable();
            int idpayment, tipod= 0;
            string clavepayment;
            byte[] opcion = null;

            if(check == false)
            { cmbCliente = 0; }
        



            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = conn.BeginTransaction();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText= "dbo.InsertarPayment";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Porpuse", porpuse);
                    cmd.Parameters.AddWithValue("@Area", cmbArea);
                    cmd.Parameters.AddWithValue("@dtFechaPago", fechaPago);
                    cmd.Parameters.AddWithValue("@EmpleadoAsig", cmbEmpleadoAsig);
                    cmd.Parameters.AddWithValue("@cliente", cmbCliente);
                    cmd.Parameters.AddWithValue("@ClatipoPago", cmbTipoPago);
                    cmd.Parameters.AddWithValue("@ClaMoneda", cmbMoneda);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@ClaEstatus", cmbEstatus);
                    cmd.Parameters.AddWithValue("@comentarios", Comentarios);
                    cmd.Parameters.AddWithValue("@Nomina", Nomina);
                    cmd.Parameters.AddWithValue("@esCaja", caja);
                    cmd.Parameters.AddWithValue("@esPagoinme", pagoinm);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                     
                    idpayment = int.Parse(dt.Rows[0]["idPayment"].ToString());
                    clavepayment = dt.Rows[0]["ClavePayment"].ToString();



                    foreach (ListViewItem data in Lcc.Items)
                    {

                        int costo = int.Parse(data.SubItems[0].Text);
                        int idbudget = int.Parse(data.SubItems[5].Text);
                        decimal monto = decimal.Parse(data.SubItems[2].Text);

                        cmd.CommandText="dbo.DetallePayment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idPayment", idpayment);
                        cmd.Parameters.AddWithValue("@idcosto", costo);
                        cmd.Parameters.AddWithValue("@Monto", monto);
                        cmd.Parameters.AddWithValue("@idBudget", idbudget);
                        cmd.Parameters.AddWithValue("@Usuario",usuario);
                        cmd.ExecuteNonQuery();

                    }




                    for(int i= 0; i<4;i++)
                    {
                        switch(i)
                        {
                            case 0:
                                opcion = FA;
                                tipod = 1;
                                break;
                            case 1:
                                opcion = P;
                                tipod = 3;
                                break;
                            case 2:
                                opcion = ipdf;
                                tipod = 2;
                                break;
                            case 3:
                                opcion = ixml;
                                tipod = 2;
                                break;
                            case 4:
                                opcion = b2b;
                                tipod = 4;
                                break;
                        }

                        
                        if ((onlypayment ==1 && opcion == null) )
                        { 
                            goto Salir; 
                        }
                        
                            if (string.IsNullOrEmpty(Name.GetValue(i).ToString()) || string.IsNullOrWhiteSpace(Name.GetValue(i).ToString()))
                            {
                                goto Salir;

                            }
                        

                        cmd.CommandText ="dbo.PaymentDetalleDocumentos";
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idPayment",idpayment);
                        cmd.Parameters.AddWithValue("@Tipo",tipod);
                        cmd.Parameters.AddWithValue("@nomdocumentos", clavepayment + "_" + Name.GetValue(i).ToString());
                        cmd.Parameters.AddWithValue("@Archivo",opcion );
                        cmd.Parameters.AddWithValue("@ext", ext.GetValue(i).ToString() );
                        cmd.ExecuteNonQuery();

                        Salir:;
                    }

                   
                    transaction.Commit();
                    
                
                    MessageBox.Show ("Payment Generado correctamente");
                  //  enviocorreo(1, usuarioCorreo, porpuse,"");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    transaction.Rollback();
                    MessageBox.Show("Payment no se genero, favor de contactar al administrador");
                    return;
                }


            }
        }



        public static DataTable ValidarUsuarios(string usuario, string password)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand("dbo.ProcValidacion", conn1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataAdapter Lector = new SqlDataAdapter(cmd);
                Lector.Fill(dt);
             }

            return dt;

        }

       

        public static void Determinarfecha (DateTimePicker dtp)
        {

            TimeSpan t1 = TimeSpan.Parse("12:00:00");



            if ((DateTime.Now.DayOfWeek == DayOfWeek.Sunday) || (DateTime.Now.DayOfWeek == DayOfWeek.Monday) || (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && DateTime.Now.TimeOfDay < t1))
            {

                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        dtp.Value = DateTime.Now.AddDays(4);
                        break;
                    case DayOfWeek.Tuesday:
                        dtp.Value = DateTime.Now.AddDays(3);
                        break;
                    case DayOfWeek.Sunday:
                        dtp.Value = DateTime.Now.AddDays(5);
                        break;
                }

            }
            else
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Tuesday:
                        dtp.Value = DateTime.Now.AddDays(10);
                        break;
                    case DayOfWeek.Wednesday:

                        dtp.Value = DateTime.Now.AddDays(9);
                        break;
                    case DayOfWeek.Thursday:
                        dtp.Value = DateTime.Now.AddDays(8);
                        break;
                    case DayOfWeek.Friday:
                        dtp.Value = DateTime.Now.AddDays(7);
                        break;
                    case DayOfWeek.Saturday:
                        dtp.Value = DateTime.Now.AddDays(6);
                        break;

                }
            }

        }

        public static DataTable llenarUsuario(string Usuario,int Activo)
        {
            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[CatUsuariosSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", Usuario);
                cmd.Parameters.AddWithValue("@Activo", Activo);
                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);
            }
            return Ds;

        }

        public static DataTable Buscardocumento(int IdPayments, int iddocs)
        {


            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[BuscardocumentoSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPayment", IdPayments);
                cmd.Parameters.AddWithValue("@IdArchivo", iddocs);
                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);
            }
            return Ds;

        }
        public static DataTable llenarCatalogo(int tipo,string descripcion, int activo)
        {


            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[CatalogosSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", tipo);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);
            }
            return Ds;

        }
        

        public static DataTable llenarData(int tipousuario, int Usuario, DateTime Fecha)
        {
            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[PaymentGeneralSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipoUsuario", tipousuario);
                cmd.Parameters.AddWithValue("@ClaUsuario", Usuario);
                cmd.Parameters.AddWithValue("@fechaConsulta", Fecha);
                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);




            }
            return Ds;
        }

        public static DataTable BuscarEncabezado(int idPayment)
        {
            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[PaymentGeneralEncSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPayment", idPayment);
              
                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);




            }
            return Ds;
        }

        public static DataTable llenarDetalle(int idPayment)
        {
            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[PaymentDetSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPayment", idPayment);

                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);




            }
            return Ds;
        }
        public static DataTable llenarDetalleDocs(int idPayment)
        {
            DataTable Ds = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            string sql = "[dbo].[PaymentDetDocsSel]";

            using (SqlConnection conn1 = new SqlConnection(ConnectionString))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(sql, conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPayment", idPayment);

                cmd.CommandTimeout = 420;
                Da = new SqlDataAdapter();
                Da.SelectCommand = cmd;
                Ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Da.Fill(Ds);




            }
            return Ds;
        }

        public static void enviocorreo(int opcion1, string correos, string titulo,string comentarios)
        {

            string description = "", body = "", correo = "";

            int opcion;


            if (opcion1 == 1)
            {

                description = "Generación de Payment: " + titulo ; //aprobacion
                opcion = 1;
                body = "Se ha generado el payment <b>" + titulo + "</b> <br>" +
                       "Favor de dar seguimiento "; //aprobacion
                correo = correos;

            }
            if (opcion1 == 2)
            {
                description = "Se ha puesto en proceso el payment " + titulo; //En proceso
                opcion = 2;
                body = "El payment <b>" + titulo + "</b> <br>" +
                       "Esta en proceso de pago.";
                correo = correos;
            }

            if (opcion1 == 3)
            {
                description = "El payment " + titulo + " fue aprobado"; //Pagado
                opcion = 3;
                body = "El payment<b>" + titulo + "</b> <br>" +
                       "Fue pagado o esta por ser pagado.";
                correo = correos;
            }

            if (opcion1 == 4)
            {
                description = "El payment " + titulo + " fue rechazado"; //Rechazado
                opcion = 4;
                body = "El payment <b>" + titulo + "</b>  fue cancelado/rechazado debido a: <br>" +
                    "<b>" + comentarios+ ".</b><br>" +
                    "Favor de comunicarte con personal de finanzas para una aclaración"; //2 veces se envía
                correo = correos;
            }
            enviarcorreos(description, body, opcion1, correo);

        }
        public static void enviarcorreos(string subject, string body, int opcion, string correo)
        {
            string Destinatario, Servidor, varios;
            int Puerto;
            DataTable Correo = new DataTable();
            DataTable CorreoFin = new DataTable();
            DataTable Supervisor = new DataTable();


            Correo = ObtenerConfiguraciones(1);
            Supervisor = ObtenerConfiguraciones(2);
            CorreoFin = ObtenerConfiguraciones(4);


            emailsupervisor = Supervisor.Rows[0]["Valor1"].ToString().Trim();
            varios = CorreoFin.Rows[0]["Valor1"].ToString().Trim();
            MailNotify = Correo.Rows[0]["Valor2"].ToString().Trim();
            pass = Correo.Rows[0]["Valor3"].ToString().Trim();

            Servidor = Correo.Rows[0]["Valor1"].ToString().Trim();
            Puerto = int.Parse(Correo.Rows[0]["Valor1Num"].ToString().Trim());

            MailMessage Mensaje = new MailMessage();

            foreach (string email in varios.Split(','))
            {
                Mensaje.CC.Add(new MailAddress(email));
            }

            Mensaje.To.Add(new MailAddress(correo));
           
            Mensaje.From = new MailAddress(MailNotify);
            Mensaje.Subject = subject;
            Mensaje.Body = body;
            Mensaje.IsBodyHtml=true;

            //if (!string.IsNullOrEmpty(attachment))
            //{
            //    Attachment data = new Attachment(attachment, MediaTypeNames.Application.Octet);
            //    Mensaje.Attachments.Add(data);
            //}


            SmtpClient ClienteSMTP = new SmtpClient(Servidor, Puerto);

            ClienteSMTP.EnableSsl = true;

            NetworkCredential credentials = new NetworkCredential(MailNotify, pass, "");
            ClienteSMTP.Credentials = credentials;


            try
            {
                ClienteSMTP.Send(Mensaje);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
