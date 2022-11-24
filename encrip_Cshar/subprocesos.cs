using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace encrip_Cshar
{
    class subprocesos
    {

        private string TexBinario(string texto)
        {
            int digitos_faltantes;
            string binarios = "";

            foreach (char c in texto)
            {
                string textobin_incompleto = Convert.ToString(Convert.ToInt32(((int)c).ToString("X"), 16), 2);

                switch (textobin_incompleto.Length)
                {
                    case < 8:
                        digitos_faltantes = 8 - textobin_incompleto.Length;
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
            foreach (char c in texto)
            {
                i++;
                binarioc += c;
                switch (i)
                {
                    case 8:
                        byteList.Add(Convert.ToByte(binarioc, 2));
                        i = 0;
                        binarioc = "";
                        break;
                }
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        private string Cfradoxor(string texto, string key)// cifra el texto
        {
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
                }
                return cfrado;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
