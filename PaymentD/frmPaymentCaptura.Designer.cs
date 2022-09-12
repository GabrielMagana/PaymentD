namespace PaymentD
{
    partial class frmPaymentCaptura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorpuse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.cmbMpago = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.cmbAsignado = new System.Windows.Forms.ComboBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNumeroNomina = new System.Windows.Forms.TextBox();
            this.dtFechaPayment = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnB2b = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lstCC = new System.Windows.Forms.ListView();
            this.idCentroCostos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CentroCostos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMonto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColMoneda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInv = new System.Windows.Forms.Button();
            this.btnFa = new System.Windows.Forms.Button();
            this.btnAgregarCC = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cmbCcostos = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkCaja = new System.Windows.Forms.CheckBox();
            this.chkpago = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Porpuse";
            // 
            // txtPorpuse
            // 
            this.txtPorpuse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorpuse.Location = new System.Drawing.Point(156, 15);
            this.txtPorpuse.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorpuse.Multiline = true;
            this.txtPorpuse.Name = "txtPorpuse";
            this.txtPorpuse.Size = new System.Drawing.Size(467, 42);
            this.txtPorpuse.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Request Area";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Request by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Metodo de pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Comentarios";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 386);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Estatus";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 305);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Moneda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 347);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Asignado a";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 265);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Fecha de pago";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 196);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 19);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Es proveedor?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 225);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Beneficiario";
            // 
            // cmbArea
            // 
            this.cmbArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(156, 78);
            this.cmbArea.Margin = new System.Windows.Forms.Padding(4);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(467, 24);
            this.cmbArea.TabIndex = 13;
            // 
            // cmbMpago
            // 
            this.cmbMpago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMpago.FormattingEnabled = true;
            this.cmbMpago.Location = new System.Drawing.Point(156, 167);
            this.cmbMpago.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMpago.Name = "cmbMpago";
            this.cmbMpago.Size = new System.Drawing.Size(467, 24);
            this.cmbMpago.TabIndex = 14;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(156, 222);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(413, 24);
            this.cmbCliente.TabIndex = 15;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(155, 222);
            this.cmbEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(467, 24);
            this.cmbEmpleado.TabIndex = 16;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(156, 302);
            this.cmbMoneda.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(467, 24);
            this.cmbMoneda.TabIndex = 17;
            this.cmbMoneda.SelectedIndexChanged += new System.EventHandler(this.cmbMoneda_SelectedIndexChanged);
            // 
            // cmbAsignado
            // 
            this.cmbAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAsignado.FormattingEnabled = true;
            this.cmbAsignado.Location = new System.Drawing.Point(156, 343);
            this.cmbAsignado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAsignado.Name = "cmbAsignado";
            this.cmbAsignado.Size = new System.Drawing.Size(467, 24);
            this.cmbAsignado.TabIndex = 18;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(156, 383);
            this.cmbEstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(467, 24);
            this.cmbEstatus.TabIndex = 19;
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentario.Location = new System.Drawing.Point(156, 428);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(467, 86);
            this.txtComentario.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.chkpago);
            this.groupBox1.Controls.Add(this.chkCaja);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtNumeroNomina);
            this.groupBox1.Controls.Add(this.dtFechaPayment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbEstatus);
            this.groupBox1.Controls.Add(this.txtPorpuse);
            this.groupBox1.Controls.Add(this.cmbAsignado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMoneda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbEmpleado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbMpago);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 107);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(649, 591);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.BackColor = System.Drawing.Color.Lavender;
            this.btnCrear.Location = new System.Drawing.Point(230, 542);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(216, 28);
            this.btnCrear.TabIndex = 24;
            this.btnCrear.Text = "Crear Payment";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(297, 122);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(325, 20);
            this.txtNombre.TabIndex = 23;
            // 
            // txtNumeroNomina
            // 
            this.txtNumeroNomina.Location = new System.Drawing.Point(156, 122);
            this.txtNumeroNomina.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroNomina.Name = "txtNumeroNomina";
            this.txtNumeroNomina.Size = new System.Drawing.Size(117, 20);
            this.txtNumeroNomina.TabIndex = 22;
            // 
            // dtFechaPayment
            // 
            this.dtFechaPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFechaPayment.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtFechaPayment.CustomFormat = "dd-MM-yyyy";
            this.dtFechaPayment.Enabled = false;
            this.dtFechaPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaPayment.Location = new System.Drawing.Point(156, 257);
            this.dtFechaPayment.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaPayment.Name = "dtFechaPayment";
            this.dtFechaPayment.Size = new System.Drawing.Size(467, 20);
            this.dtFechaPayment.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnB2b);
            this.groupBox2.Controls.Add(this.btnPayment);
            this.groupBox2.Controls.Add(this.lstCC);
            this.groupBox2.Controls.Add(this.btnInv);
            this.groupBox2.Controls.Add(this.btnFa);
            this.groupBox2.Controls.Add(this.btnAgregarCC);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.cmbCcostos);
            this.groupBox2.Location = new System.Drawing.Point(665, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(612, 683);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Location = new System.Drawing.Point(376, 143);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(163, 28);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnB2b
            // 
            this.btnB2b.BackColor = System.Drawing.Color.Lavender;
            this.btnB2b.Location = new System.Drawing.Point(376, 634);
            this.btnB2b.Margin = new System.Windows.Forms.Padding(4);
            this.btnB2b.Name = "btnB2b";
            this.btnB2b.Size = new System.Drawing.Size(163, 28);
            this.btnB2b.TabIndex = 26;
            this.btnB2b.Text = "4. B2B";
            this.btnB2b.UseVisualStyleBackColor = false;
            this.btnB2b.Click += new System.EventHandler(this.btnB2b_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.Lavender;
            this.btnPayment.Location = new System.Drawing.Point(79, 634);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(163, 28);
            this.btnPayment.TabIndex = 25;
            this.btnPayment.Text = "2. Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lstCC
            // 
            this.lstCC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idCentroCostos,
            this.CentroCostos,
            this.colMonto,
            this.ColMoneda});
            this.lstCC.HideSelection = false;
            this.lstCC.Location = new System.Drawing.Point(8, 178);
            this.lstCC.Margin = new System.Windows.Forms.Padding(4);
            this.lstCC.Name = "lstCC";
            this.lstCC.Size = new System.Drawing.Size(595, 415);
            this.lstCC.TabIndex = 5;
            this.lstCC.UseCompatibleStateImageBehavior = false;
            this.lstCC.View = System.Windows.Forms.View.Details;
            // 
            // idCentroCostos
            // 
            this.idCentroCostos.Text = "idCC";
            this.idCentroCostos.Width = 50;
            // 
            // CentroCostos
            // 
            this.CentroCostos.Text = "Centro de Costos";
            this.CentroCostos.Width = 210;
            // 
            // colMonto
            // 
            this.colMonto.Text = "Monto";
            this.colMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMonto.Width = 168;
            // 
            // ColMoneda
            // 
            this.ColMoneda.Text = "Moneda";
            this.ColMoneda.Width = 108;
            // 
            // btnInv
            // 
            this.btnInv.BackColor = System.Drawing.Color.Lavender;
            this.btnInv.Location = new System.Drawing.Point(376, 602);
            this.btnInv.Margin = new System.Windows.Forms.Padding(4);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(163, 28);
            this.btnInv.TabIndex = 24;
            this.btnInv.Text = "3. Invoice";
            this.btnInv.UseVisualStyleBackColor = false;
            this.btnInv.Click += new System.EventHandler(this.btnInv_Click);
            // 
            // btnFa
            // 
            this.btnFa.BackColor = System.Drawing.Color.Lavender;
            this.btnFa.Location = new System.Drawing.Point(79, 602);
            this.btnFa.Margin = new System.Windows.Forms.Padding(4);
            this.btnFa.Name = "btnFa";
            this.btnFa.Size = new System.Drawing.Size(163, 28);
            this.btnFa.TabIndex = 6;
            this.btnFa.Text = "1. FA";
            this.btnFa.UseVisualStyleBackColor = false;
            this.btnFa.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAgregarCC
            // 
            this.btnAgregarCC.BackColor = System.Drawing.Color.Lavender;
            this.btnAgregarCC.Location = new System.Drawing.Point(159, 143);
            this.btnAgregarCC.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarCC.Name = "btnAgregarCC";
            this.btnAgregarCC.Size = new System.Drawing.Size(163, 28);
            this.btnAgregarCC.TabIndex = 4;
            this.btnAgregarCC.Text = "Agregar";
            this.btnAgregarCC.UseVisualStyleBackColor = false;
            this.btnAgregarCC.Click += new System.EventHandler(this.btnAgregarCC_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 81);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Monto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Centro de costos";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(220, 78);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(249, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // cmbCcostos
            // 
            this.cmbCcostos.FormattingEnabled = true;
            this.cmbCcostos.Location = new System.Drawing.Point(220, 32);
            this.cmbCcostos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCcostos.Name = "cmbCcostos";
            this.cmbCcostos.Size = new System.Drawing.Size(249, 24);
            this.cmbCcostos.TabIndex = 0;
            this.cmbCcostos.SelectedIndexChanged += new System.EventHandler(this.cmbCcostos_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PaymentD.Properties.Resources.oficial;
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(641, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // chkCaja
            // 
            this.chkCaja.AutoSize = true;
            this.chkCaja.Location = new System.Drawing.Point(165, 196);
            this.chkCaja.Margin = new System.Windows.Forms.Padding(4);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(88, 19);
            this.chkCaja.TabIndex = 25;
            this.chkCaja.Text = "Caja Chica";
            this.chkCaja.UseVisualStyleBackColor = true;
            // 
            // chkpago
            // 
            this.chkpago.AutoSize = true;
            this.chkpago.Location = new System.Drawing.Point(297, 196);
            this.chkpago.Margin = new System.Windows.Forms.Padding(4);
            this.chkpago.Name = "chkpago";
            this.chkpago.Size = new System.Drawing.Size(116, 19);
            this.chkpago.TabIndex = 26;
            this.chkpago.Text = "Pago inmediato";
            this.chkpago.UseVisualStyleBackColor = true;
            this.chkpago.CheckedChanged += new System.EventHandler(this.chkpago_CheckedChanged);
            // 
            // frmPaymentCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1293, 708);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPaymentCaptura";
            this.Text = "Captura de Payment";
            this.Load += new System.EventHandler(this.frmPaymentCaptura_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorpuse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.ComboBox cmbMpago;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.ComboBox cmbAsignado;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFechaPayment;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNumeroNomina;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstCC;
        private System.Windows.Forms.Button btnAgregarCC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cmbCcostos;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnB2b;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.ColumnHeader idCentroCostos;
        private System.Windows.Forms.ColumnHeader CentroCostos;
        private System.Windows.Forms.ColumnHeader colMonto;
        private System.Windows.Forms.Button btnInv;
        private System.Windows.Forms.Button btnFa;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader ColMoneda;
        private System.Windows.Forms.CheckBox chkpago;
        private System.Windows.Forms.CheckBox chkCaja;
    }
}