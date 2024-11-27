
namespace COTIZACIÓN_DE_COMPRA_DE_CONSOLA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblConsola = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3anio = new System.Windows.Forms.RadioButton();
            this.rb2anio = new System.Windows.Forms.RadioButton();
            this.rb1anio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxTransporte = new System.Windows.Forms.CheckBox();
            this.cbxAudifono = new System.Windows.Forms.CheckBox();
            this.cbxControl = new System.Windows.Forms.CheckBox();
            this.cbxConsola = new System.Windows.Forms.ComboBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.btnCotizar = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(50, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(137, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // lblConsola
            // 
            this.lblConsola.AutoSize = true;
            this.lblConsola.Location = new System.Drawing.Point(54, 105);
            this.lblConsola.Name = "lblConsola";
            this.lblConsola.Size = new System.Drawing.Size(67, 20);
            this.lblConsola.TabIndex = 1;
            this.lblConsola.Text = "Consola";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(217, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(178, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3anio);
            this.groupBox1.Controls.Add(this.rb2anio);
            this.groupBox1.Controls.Add(this.rb1anio);
            this.groupBox1.Location = new System.Drawing.Point(77, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 170);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Garantia Extendida";
            // 
            // rb3anio
            // 
            this.rb3anio.AutoSize = true;
            this.rb3anio.Location = new System.Drawing.Point(6, 120);
            this.rb3anio.Name = "rb3anio";
            this.rb3anio.Size = new System.Drawing.Size(150, 24);
            this.rb3anio.TabIndex = 2;
            this.rb3anio.TabStop = true;
            this.rb3anio.Text = "3 años ($89990)";
            this.rb3anio.UseVisualStyleBackColor = true;
            // 
            // rb2anio
            // 
            this.rb2anio.AutoSize = true;
            this.rb2anio.Location = new System.Drawing.Point(6, 77);
            this.rb2anio.Name = "rb2anio";
            this.rb2anio.Size = new System.Drawing.Size(150, 24);
            this.rb2anio.TabIndex = 1;
            this.rb2anio.TabStop = true;
            this.rb2anio.Text = "2 años ($60990)";
            this.rb2anio.UseVisualStyleBackColor = true;
            // 
            // rb1anio
            // 
            this.rb1anio.AutoSize = true;
            this.rb1anio.Location = new System.Drawing.Point(6, 37);
            this.rb1anio.Name = "rb1anio";
            this.rb1anio.Size = new System.Drawing.Size(142, 24);
            this.rb1anio.TabIndex = 0;
            this.rb1anio.TabStop = true;
            this.rb1anio.Text = "1 año ($54990)";
            this.rb1anio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxTransporte);
            this.groupBox2.Controls.Add(this.cbxAudifono);
            this.groupBox2.Controls.Add(this.cbxControl);
            this.groupBox2.Location = new System.Drawing.Point(508, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 170);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Accesorio";
            // 
            // cbxTransporte
            // 
            this.cbxTransporte.AutoSize = true;
            this.cbxTransporte.Location = new System.Drawing.Point(6, 120);
            this.cbxTransporte.Name = "cbxTransporte";
            this.cbxTransporte.Size = new System.Drawing.Size(224, 24);
            this.cbxTransporte.TabIndex = 2;
            this.cbxTransporte.Text = "Bolso Transporte ($30000)";
            this.cbxTransporte.UseVisualStyleBackColor = true;
            // 
            // cbxAudifono
            // 
            this.cbxAudifono.AutoSize = true;
            this.cbxAudifono.Location = new System.Drawing.Point(6, 77);
            this.cbxAudifono.Name = "cbxAudifono";
            this.cbxAudifono.Size = new System.Drawing.Size(240, 24);
            this.cbxAudifono.TabIndex = 1;
            this.cbxAudifono.Text = "Audifono Bluetooth ($60000)";
            this.cbxAudifono.UseVisualStyleBackColor = true;
            // 
            // cbxControl
            // 
            this.cbxControl.AutoSize = true;
            this.cbxControl.Location = new System.Drawing.Point(6, 37);
            this.cbxControl.Name = "cbxControl";
            this.cbxControl.Size = new System.Drawing.Size(240, 24);
            this.cbxControl.TabIndex = 0;
            this.cbxControl.Text = "Control Inalambrico ($50000)";
            this.cbxControl.UseVisualStyleBackColor = true;
            // 
            // cbxConsola
            // 
            this.cbxConsola.FormattingEnabled = true;
            this.cbxConsola.Location = new System.Drawing.Point(218, 97);
            this.cbxConsola.Name = "cbxConsola";
            this.cbxConsola.Size = new System.Drawing.Size(178, 28);
            this.cbxConsola.TabIndex = 6;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(83, 369);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(113, 20);
            this.lblCosto.TabIndex = 7;
            this.lblCosto.Text = "Costo Consola";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(217, 369);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(178, 26);
            this.txtCosto.TabIndex = 8;
            // 
            // btnCotizar
            // 
            this.btnCotizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCotizar.Location = new System.Drawing.Point(423, 365);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(85, 37);
            this.btnCotizar.TabIndex = 9;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = false;
            this.btnCotizar.Click += new System.EventHandler(this.btnCotizar_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(87, 408);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(677, 210);
            this.txtResultado.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 630);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCotizar);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.cbxConsola);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblConsola);
            this.Controls.Add(this.lblNombre);
            this.Name = "Form1";
            this.Text = "Cotizacion de Consola";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblConsola;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb3anio;
        private System.Windows.Forms.RadioButton rb2anio;
        private System.Windows.Forms.RadioButton rb1anio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxTransporte;
        private System.Windows.Forms.CheckBox cbxAudifono;
        private System.Windows.Forms.CheckBox cbxControl;
        private System.Windows.Forms.ComboBox cbxConsola;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Button btnCotizar;
        private System.Windows.Forms.TextBox txtResultado;
    }
}

