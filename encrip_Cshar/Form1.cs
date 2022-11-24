using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace encrip_Cshar
{

    public partial class Form1 : Form
    {
        string[] Extencionescompatibles = { "txt", "log" };//, "docx", "pdf" };

        const int bytes = 8;
        byte[] Textobyte = null;
        string subrutaguarda;
        string Textochange;
        string Extencionesg, NombreArchivo, Key, path;

        bool Unicad = false, cargado = false;
        bool Documento_exite = false, Clave_existe = false, Procesado = false, Guardado = false;
        int Encriptaciones = 0;

        public Form1()
        {
            InitializeComponent();
            Controlbotones();
            BloquearBarras();
            Clave.PasswordChar = '*';
            No_encriptaciones.Text = "-";
            Muestra_texto.ForeColor = Color.Red;
        }

        private void Buscar_Archivo_Click(object sender, EventArgs e)
        {
            Buscar_Archivo.Enabled = false;

            if (Procesado && !Guardado)
            {
                if (Mensajebox( "Cambios no guardados. Desea Guardarlos", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation ) == DialogResult.Yes)
                    buscarutaG();
                else
                    BuscaArchivo();
            }
            else
                BuscaArchivo();

            Buscar_Archivo.Enabled = true;
        }

        public void BuscaArchivo()
        {
            OpenFileDialog buscar = new OpenFileDialog();

            //buscar.InitialDirectory = "c:\\";
            buscar.Filter = "All files (*.*)|*.*" + "|" + "TXT(*.txt)|*.txt"; // "PDF(*.pdf)|*.pdf|" + |DOCX(*.docx)|*.docx
            buscar.FilterIndex = 2;
            //buscar.RestoreDirectory = true;

            if ( buscar.ShowDialog() == DialogResult.OK )
            {
                Muestra_texto.ForeColor = Color.Black;
                Archivo_Base.Text = buscar.FileName;
                Encriptaciones = 0;
                No_encriptaciones.Text = "# " + Encriptaciones;

                if (comprobararchivo())
                {
                    Thread cargaArchivo = new Thread( cargar );
                    cargaArchivo.Start();
                }
                else
                {
                    Muestra_texto.ForeColor = Color.Red;
                    Muestra_texto.Text = "\nArchivo  \"" + NombreArchivo + "." + Extencionesg + "\" no aceptado.";
                }
            }
        }

        public void cargar()
        {
            cargado = false;
                                                  //unicas,  guardar, encriptar, desencriptar,   Buscar_Archivo 
            Invoke(new Action(() => controlbotonesg( false,    false,     false,        false,            false) ));

            
            Invoke(new Action( () =>
            {
                if (Extencionesg == "txt")
                    Muestra_texto.Text = Leer();
                else
                    Muestra_texto.Text = "Archivo "+ Extencionesg + " cargado";
            }));

            Invoke(new Action(() => Controlbotones() ));

            cargado = true;
        }

        public bool comprobararchivo() // verifica la compatibilidad
        {
            bool cumple = false;

            try
            {
                NombreArchivo = path.Substring(path.LastIndexOf(((char)92)) + 1);
                int index = NombreArchivo.LastIndexOf('.');
                Extencionesg = NombreArchivo.Substring(index + 1);
                NombreArchivo = NombreArchivo.Substring(0, index);

                if (File.Exists(path))
                    for (int i = 0; i < Extencionescompatibles.Length; i++)
                        if (Extencionesg == Extencionescompatibles[i])
                        {
                            cumple = true;
                            break;
                        }
            }
            catch (Exception e)
            {
                Procesado = false;
                Estado.ForeColor = Color.Red;
                Muestra_texto.ForeColor = Color.Red;
                Estado.Text = "Error";
                Muestra_texto.Text = "\n\t=-=-=-=-=-=-=\'" + path + "\' No es una ruta Correcta=-=-=-=-=-=-=\n" + e.ToString();
            }

            return cumple;
        }

        private void Archivo_Base_TextChanged(object sender, EventArgs e)
        {
            path = Archivo_Base.Text;
            if (Archivo_Base.Text == string.Empty)
                Documento_exite = false;
            else
                Documento_exite = true;
            Controlbotones();
        }

        private void Clave_TextChanged(object sender, EventArgs e)
        {
            Key = Clave.Text;
            if (Clave.Text == string.Empty)
                Clave_existe = false;
            else
                Clave_existe = true;
            Controlbotones();
        }

        private void Controlbotones()
        {
            if (Clave_existe && Documento_exite)
                              //unicas, guardar, encriptar, desencriptar,  Buscar_Archivo     
                controlbotonesg(  true,    true,      true,         true,            true );
            else
            {
                unica.Checked = true;
                              //unicas,  guardar, encriptar, desencriptar,   Buscar_Archivo 
                controlbotonesg( false,    false,     false,        false,             true );
            }
            unicochec();
        }

        public void controlbotonesg(bool unicas, bool guardar, bool encriptar, bool desencriptar, bool buscararch)
        {
            unica.Enabled = unicas;
            Guardar.Enabled = guardar;
            Encriptar.Enabled = encriptar;
            Desencriptar.Enabled = desencriptar;
            Buscar_Archivo.Enabled = buscararch;
        }

        private void Encriptar_Click(object sender, EventArgs e)
        {
            if (!comprobararchivo())
            {
                Estado.ForeColor = Color.Red;
                Mensajebox("No se encontro el archivo o no es txt", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Guardado = false;
                Muestra_texto.ForeColor = Color.Black;

                Thread IniciaEncriptacion = new Thread( tipoencriptacion );
                IniciaEncriptacion.Start( true );
            }
        }

        public void tipoencriptacion( object tipos )
        {
            bool tipo = Convert.ToBoolean( tipos );

            try
            {
                cargado = false;
                Thread proce = new Thread( indicaproceso );
                proce.Start();

                string mensaje = "", titulo = "";
                Color color;

                if ( Unicad && tipo ) // encriptacion unica
                {
                    Textochange = BinTexto( Cfradoxor( TexBinario( System.Text.Encoding.UTF8.GetString( Textobyte ) ), TexBinario( Key ) ) );
                    Textobyte = Encoding.ASCII.GetBytes(Textochange);
                    mensaje = "procesado"; titulo = "Aviso"; color = Color.Green;
                    Encriptaciones = 0;
                }
                else if ( !Unicad && tipo )
                {
                    Textochange = Cfradoxor( TexBinario( System.Text.Encoding.UTF8.GetString( Textobyte ) ), TexBinario(Key));
                    Textobyte = Encoding.ASCII.GetBytes(Textochange);
                    mensaje = "encriptado"; titulo = "Aviso"; color = Color.Green;
                    Encriptaciones++;
                }
                else
                {
                    Textochange = BinTexto(Cfradoxor(System.Text.Encoding.UTF8.GetString(Textobyte), TexBinario(Key)));
                    Textobyte = Encoding.ASCII.GetBytes(Textochange);
                    mensaje = "desencriptado"; titulo = "Aviso"; color = Color.Orange;
                    Encriptaciones--;
                }

                cargado = true;
                Procesado = true;

                Invoke(new Action(() =>
                {
                    if (Extencionesg == "txt")
                        Muestra_texto.Text = Textochange;
                    else
                        Muestra_texto.Text = "Archivo " + Extencionesg + " Procesado";
                }));

                Mensajebox(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Invoke(new Action(() => 
                {
                    Progreso.Value = 0;
                    Estado.ForeColor = color;
                    Estado.Text = mensaje; 
                }));

            }
            catch (Exception e)
            {
                cargado = true;
                Guardado = true;
                Procesado = true;

                Invoke(new Action(() =>
                {
                    Muestra_texto.ForeColor = Color.Red;
                    Muestra_texto.Text = e.ToString();
                }));
            }
        }

        public void indicaproceso()
        {
                                                  //unicas,  guardar, encriptar, desencriptar,   Buscar_Archivo
            Invoke(new Action(() => controlbotonesg( false,    false,     false,        false,            false ) ));

            Invoke(new Action(() => Estado.ForeColor = Color.Black ));

            while (!cargado)
            {
                Invoke(new Action(() => Estado.Text = "Procesando: |"));
                if (!cargado)
                    Thread.Sleep(100);

                Invoke(new Action(() => Estado.Text = "Procesando: /"));
                if (!cargado)
                    Thread.Sleep(100);

                Invoke(new Action(() => Estado.Text = "Procesando: ---"));

                if (!cargado)
                    Thread.Sleep(100);

                Invoke(new Action(() => Estado.Text = "Procesando: \\"));
                if (!cargado)
                    Thread.Sleep(100);
            }
                Invoke(new Action(() =>
            {                  //unicas,  guardar, encriptar, desencriptar,   Buscar_Archivo
                controlbotonesg(   true,     true,      true,         true,             true);
                unicochec();
                BloquearBarras();
                No_encriptaciones.Text = "# " + Encriptaciones;
            }));
        }
        
        public string Leer()//abre el archivo
        {
            Textobyte = File.ReadAllBytes( path );   //para futuros archivos

            return System.Text.Encoding.UTF8.GetString( Textobyte );
        }

        public void Escribe()
        {                                                                  //Extencionesg
            File.WriteAllBytes( subrutaguarda +"\\" + NombreArchivo + "." + "txt", Textobyte );
        }

        private string TexBinario(string texto)
        {
            int digitos_faltantes;
            string binarios = "";

            foreach (char c in texto)
            {
                string textobin_incompleto = Convert.ToString( Convert.ToInt32( ( (int)c ).ToString("X"), 16 ), 2 );
                
                switch(textobin_incompleto.Length)
                {
                    case < bytes:
                        digitos_faltantes = bytes - textobin_incompleto.Length;
                        for (int j = 0; j < digitos_faltantes; j++)
                            binarios += "0";
                    break;
                }
                binarios += textobin_incompleto;
            }
            return binarios;
        }

        private string BinTexto(string texto)//convercion de binario a texto
        {
            List<Byte> byteList = new List<Byte>();

            int i = 0;
            string binarioc = "";
            foreach(char c in texto)
            {
                i++;
                binarioc += c;
                switch (i)
                {
                    case bytes:
                        //byteList.Add(Convert.ToByte(binarioc, 2));
                        byteList.Add(Convert.ToByte(binarioc, 2));
                        i = 0;
                        binarioc = "";
                    break;
                }
            }
            //Encoding.UTF8.GetString( byteList.ToArray() );
            //Encoding.ASCII.GetString( byteList.ToArray() );
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        private string Cfradoxor(string texto, string key)// cifra el texto
        {
            //_maximo de barra de progreso__
            Invoke(new Action(() =>
            {
                Progreso.Value = 0;
                Progreso.Maximum = texto.Length;
            }));
            //______________________________
            string cfrado = "";
            try
            {
                List<string> Clave_binario = new List<string>();
                string texto_a_encriptar;
                int contclav = 0;

                foreach (char c in key)
                    Clave_binario.Add(Convert.ToString(c));

                foreach (char t in texto)
                {
                    texto_a_encriptar = Convert.ToString(t);
                    if (texto_a_encriptar == Clave_binario[contclav])
                        cfrado += "0";
                    else
                        cfrado += "1";

                    contclav++;
                    if (contclav == Clave_binario.Count)
                        contclav = 0;

                    Invoke(new Action(() => Progreso.Value++ ));
                }
                return cfrado;
            }
            catch (Exception e)
            {
                Invoke(new Action(() => Muestra_texto.Text = e.ToString() ));
                return e.ToString();
            }
        }

        private void Desencriptar_Click_1(object sender, EventArgs e)
        {
            if (!comprobararchivo())
            {
                Estado.ForeColor = Color.Red;
                Mensajebox("No se encontro el archivo o no es txt", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Muestra_texto.Text.Any(char.IsLetter))
            {
                Muestra_texto.ForeColor = Color.Black;
                Estado.ForeColor = Color.Red;
                Estado.Text = "No se puede desencriptar";
                Mensajebox("No se puede desencriptar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Guardado = false;
                Muestra_texto.ForeColor = Color.Black;

                Thread IniciaEncriptacion = new Thread(tipoencriptacion);
                IniciaEncriptacion.Start(false);
            }
        }

        public DialogResult Mensajebox(string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            return MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void BloquearBarras()
        {
            if (Encriptaciones > 0)
            {
                Clave.Enabled = false;
                Archivo_Base.Enabled = false;
            }
            else
            {
                Clave.Enabled = true;
                Archivo_Base.Enabled = true;
            }
        }

        private void Muestra_texto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Titulo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            this.FormClosing += new FormClosingEventHandler(cerrar);
        }

        private void cerrar(object sender, EventArgs e)
        {
            opcionsalir();
        }

        private void No_encriptaciones_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            unicochec();
        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void unicochec()
        {
            if (unica.Checked == true)
            {
                Desencriptar.Enabled = false;
                Encriptar.Text = "Enc/Desc.";
                Unicad = true;
            }
            else
            {
                Desencriptar.Enabled = true;
                Encriptar.Text = "Encriptar.";
                Unicad = false;
            }
        }

        private void Estado_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarutaG();
        }

        public void buscarutaG()
        {
            FolderBrowserDialog buscar = new FolderBrowserDialog();
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                subrutaguarda = buscar.SelectedPath;
                guardar();
            }
        }

        public void guardar()
        {
            if (comprobararchivo())
            {
                Muestra_texto.ForeColor = Color.Green;
                Escribe();
                Guardado = true;
                Mensajebox("Datos guardado en: " + subrutaguarda + "\\" + NombreArchivo + "." + Extencionesg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                Mensajebox("No se puede Guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void opcionsalir()
        {
            if (Procesado && !Guardado)
            {
                if (Mensajebox("Cambios no guardados. Desea Guardarlos", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    buscarutaG();
            }
            Environment.Exit(Environment.ExitCode);
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            opcionsalir();
        }
    }
}