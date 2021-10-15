namespace WindowsLiderEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(32, 60);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(200, 55);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Location = new System.Drawing.Point(624, 72);
            this.lblTiempoTotal.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(0, 32);
            this.lblTiempoTotal.TabIndex = 1;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(400, 72);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(181, 32);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "Tiempo Total";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1219, 480);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 138);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1187, 65);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 765);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblTiempoTotal);
            this.Controls.Add(this.btnCalcular);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Prueba Lider";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblTiempoTotal;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

