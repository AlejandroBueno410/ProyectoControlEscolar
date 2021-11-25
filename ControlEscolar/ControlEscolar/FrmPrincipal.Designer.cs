
namespace ControlEscolar
{
    partial class FrmPrincipal
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
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnMaestros = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(186, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Escolar";
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAlumnos.Location = new System.Drawing.Point(4, 69);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(184, 32);
            this.btnAlumnos.TabIndex = 2;
            this.btnAlumnos.Text = "Alumnos";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnMaestros
            // 
            this.btnMaestros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnMaestros.Location = new System.Drawing.Point(4, 107);
            this.btnMaestros.Name = "btnMaestros";
            this.btnMaestros.Size = new System.Drawing.Size(184, 32);
            this.btnMaestros.TabIndex = 3;
            this.btnMaestros.Text = "Maestros";
            this.btnMaestros.UseVisualStyleBackColor = true;
            this.btnMaestros.Click += new System.EventHandler(this.btnMaestros_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCerrarSesion.Location = new System.Drawing.Point(483, 315);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(88, 32);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 348);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnMaestros);
            this.Controls.Add(this.btnAlumnos);
            this.Controls.Add(this.label1);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnMaestros;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}