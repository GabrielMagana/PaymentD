namespace PaymentD
{
    partial class frmprincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cnceptosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogosToolStripMenuItem,
            this.paymentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catalogosToolStripMenuItem
            // 
            this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areasToolStripMenuItem,
            this.centroDeCostosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.cnceptosDePagoToolStripMenuItem,
            this.estatusToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.monedaToolStripMenuItem,
            this.tipoUsuariosToolStripMenuItem,
            this.tipoDeDocumentosToolStripMenuItem});
            this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
            this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.catalogosToolStripMenuItem.Text = "Catalogos";
            // 
            // areasToolStripMenuItem
            // 
            this.areasToolStripMenuItem.Name = "areasToolStripMenuItem";
            this.areasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.areasToolStripMenuItem.Text = "Areas";
            this.areasToolStripMenuItem.Click += new System.EventHandler(this.areasToolStripMenuItem_Click);
            // 
            // centroDeCostosToolStripMenuItem
            // 
            this.centroDeCostosToolStripMenuItem.Name = "centroDeCostosToolStripMenuItem";
            this.centroDeCostosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.centroDeCostosToolStripMenuItem.Text = "Centro de Costos";
            this.centroDeCostosToolStripMenuItem.Click += new System.EventHandler(this.centroDeCostosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.clientesToolStripMenuItem.Text = "Beneficiarios";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // cnceptosDePagoToolStripMenuItem
            // 
            this.cnceptosDePagoToolStripMenuItem.Name = "cnceptosDePagoToolStripMenuItem";
            this.cnceptosDePagoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cnceptosDePagoToolStripMenuItem.Text = "Conceptos de pago";
            this.cnceptosDePagoToolStripMenuItem.Click += new System.EventHandler(this.cnceptosDePagoToolStripMenuItem_Click);
            // 
            // estatusToolStripMenuItem
            // 
            this.estatusToolStripMenuItem.Name = "estatusToolStripMenuItem";
            this.estatusToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.estatusToolStripMenuItem.Text = "Estatus";
            this.estatusToolStripMenuItem.Click += new System.EventHandler(this.estatusToolStripMenuItem_Click);
            // 
            // monedaToolStripMenuItem
            // 
            this.monedaToolStripMenuItem.Name = "monedaToolStripMenuItem";
            this.monedaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.monedaToolStripMenuItem.Text = "Moneda";
            this.monedaToolStripMenuItem.Click += new System.EventHandler(this.monedaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // tipoUsuariosToolStripMenuItem
            // 
            this.tipoUsuariosToolStripMenuItem.Name = "tipoUsuariosToolStripMenuItem";
            this.tipoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.tipoUsuariosToolStripMenuItem.Text = "Tipo de usuarios";
            this.tipoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.tipoUsuariosToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPaymentToolStripMenuItem,
            this.consultarPaymentsToolStripMenuItem});
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // newPaymentToolStripMenuItem
            // 
            this.newPaymentToolStripMenuItem.Name = "newPaymentToolStripMenuItem";
            this.newPaymentToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.newPaymentToolStripMenuItem.Text = "New Payment";
            this.newPaymentToolStripMenuItem.Click += new System.EventHandler(this.newPaymentToolStripMenuItem_Click);
            // 
            // consultarPaymentsToolStripMenuItem
            // 
            this.consultarPaymentsToolStripMenuItem.Name = "consultarPaymentsToolStripMenuItem";
            this.consultarPaymentsToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.consultarPaymentsToolStripMenuItem.Text = "Consultar Payments";
            this.consultarPaymentsToolStripMenuItem.Click += new System.EventHandler(this.consultarPaymentsToolStripMenuItem_Click);
            // 
            // tipoDeDocumentosToolStripMenuItem
            // 
            this.tipoDeDocumentosToolStripMenuItem.Name = "tipoDeDocumentosToolStripMenuItem";
            this.tipoDeDocumentosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.tipoDeDocumentosToolStripMenuItem.Text = "Tipo de Documentos";
            this.tipoDeDocumentosToolStripMenuItem.Click += new System.EventHandler(this.tipoDeDocumentosToolStripMenuItem_Click);
            // 
            // frmprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmprincipal";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmprincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cnceptosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeDocumentosToolStripMenuItem;
    }
}