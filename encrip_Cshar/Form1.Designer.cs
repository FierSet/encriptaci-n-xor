
namespace encrip_Cshar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Titulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Archivo_Base = new System.Windows.Forms.TextBox();
            this.Clave = new System.Windows.Forms.TextBox();
            this.Buscar_Archivo = new System.Windows.Forms.Button();
            this.Encriptar = new System.Windows.Forms.Button();
            this.Desencriptar = new System.Windows.Forms.Button();
            this.Estado = new System.Windows.Forms.Label();
            this.Muestra_texto = new System.Windows.Forms.RichTextBox();
            this.Salir = new System.Windows.Forms.Button();
            this.No_encriptaciones = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.unica = new System.Windows.Forms.CheckBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Location = new System.Drawing.Point(186, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(112, 15);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Encriptador a 1 Byte";
            this.Titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Titulo.Click += new System.EventHandler(this.Titulo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clave";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Archivo_Base
            // 
            this.Archivo_Base.Location = new System.Drawing.Point(68, 69);
            this.Archivo_Base.Name = "Archivo_Base";
            this.Archivo_Base.Size = new System.Drawing.Size(263, 23);
            this.Archivo_Base.TabIndex = 3;
            this.Archivo_Base.TextChanged += new System.EventHandler(this.Archivo_Base_TextChanged);
            // 
            // Clave
            // 
            this.Clave.Location = new System.Drawing.Point(68, 114);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(263, 23);
            this.Clave.TabIndex = 4;
            this.Clave.TextChanged += new System.EventHandler(this.Clave_TextChanged);
            // 
            // Buscar_Archivo
            // 
            this.Buscar_Archivo.Location = new System.Drawing.Point(350, 69);
            this.Buscar_Archivo.Name = "Buscar_Archivo";
            this.Buscar_Archivo.Size = new System.Drawing.Size(98, 23);
            this.Buscar_Archivo.TabIndex = 5;
            this.Buscar_Archivo.Text = "Buscar archivo.";
            this.Buscar_Archivo.UseVisualStyleBackColor = true;
            this.Buscar_Archivo.Click += new System.EventHandler(this.Buscar_Archivo_Click);
            // 
            // Encriptar
            // 
            this.Encriptar.Location = new System.Drawing.Point(350, 113);
            this.Encriptar.Name = "Encriptar";
            this.Encriptar.Size = new System.Drawing.Size(75, 23);
            this.Encriptar.TabIndex = 6;
            this.Encriptar.Text = "Encriptar.";
            this.Encriptar.UseVisualStyleBackColor = true;
            this.Encriptar.Click += new System.EventHandler(this.Encriptar_Click);
            // 
            // Desencriptar
            // 
            this.Desencriptar.Location = new System.Drawing.Point(436, 114);
            this.Desencriptar.Name = "Desencriptar";
            this.Desencriptar.Size = new System.Drawing.Size(88, 23);
            this.Desencriptar.TabIndex = 7;
            this.Desencriptar.Text = "Desencriptar.";
            this.Desencriptar.UseVisualStyleBackColor = true;
            this.Desencriptar.Click += new System.EventHandler(this.Desencriptar_Click_1);
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.BackColor = System.Drawing.Color.Transparent;
            this.Estado.Location = new System.Drawing.Point(174, 146);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(45, 15);
            this.Estado.TabIndex = 8;
            this.Estado.Text = "Estado.";
            this.Estado.Click += new System.EventHandler(this.Estado_Click);
            // 
            // Muestra_texto
            // 
            this.Muestra_texto.Location = new System.Drawing.Point(11, 193);
            this.Muestra_texto.Name = "Muestra_texto";
            this.Muestra_texto.Size = new System.Drawing.Size(513, 266);
            this.Muestra_texto.TabIndex = 9;
            this.Muestra_texto.Text = resources.GetString("Muestra_texto.Text");
            this.Muestra_texto.TextChanged += new System.EventHandler(this.Muestra_texto_TextChanged);
            // 
            // Salir
            // 
            this.Salir.Location = new System.Drawing.Point(485, 465);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(40, 23);
            this.Salir.TabIndex = 10;
            this.Salir.Text = "Salir.";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // No_encriptaciones
            // 
            this.No_encriptaciones.AutoSize = true;
            this.No_encriptaciones.BackColor = System.Drawing.Color.Transparent;
            this.No_encriptaciones.Location = new System.Drawing.Point(68, 175);
            this.No_encriptaciones.Name = "No_encriptaciones";
            this.No_encriptaciones.Size = new System.Drawing.Size(12, 15);
            this.No_encriptaciones.TabIndex = 11;
            this.No_encriptaciones.Text = "-";
            this.No_encriptaciones.Click += new System.EventHandler(this.No_encriptaciones_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::encrip_Cshar.Properties.Resources.proto_3;
            this.pictureBox1.Location = new System.Drawing.Point(449, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(449, 143);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 13;
            this.Guardar.Text = "Guardar.";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // unica
            // 
            this.unica.AutoSize = true;
            this.unica.Location = new System.Drawing.Point(350, 146);
            this.unica.Name = "unica";
            this.unica.Size = new System.Drawing.Size(59, 19);
            this.unica.TabIndex = 14;
            this.unica.Text = "Unica.";
            this.unica.UseVisualStyleBackColor = true;
            this.unica.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(68, 143);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(100, 23);
            this.Progreso.TabIndex = 15;
            this.Progreso.Click += new System.EventHandler(this.progressBar1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 500);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.unica);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.No_encriptaciones);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.Muestra_texto);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.Desencriptar);
            this.Controls.Add(this.Encriptar);
            this.Controls.Add(this.Buscar_Archivo);
            this.Controls.Add(this.Clave);
            this.Controls.Add(this.Archivo_Base);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Titulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Encriptador";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Archivo_Base;
        private System.Windows.Forms.TextBox Clave;
        private System.Windows.Forms.Button Buscar_Archivo;
        private System.Windows.Forms.Button Encriptar;
        private System.Windows.Forms.Button Desencriptar;
        private System.Windows.Forms.Label Estado;
        private System.Windows.Forms.RichTextBox Muestra_texto;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Label No_encriptaciones;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.CheckBox unica;
        private System.Windows.Forms.ProgressBar Progreso;
    }
}

