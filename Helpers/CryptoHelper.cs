using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLiderEntrega.Helpers
{
    public static class CryptoHelper
    {

        readonly static byte[] IV = Encoding.ASCII.GetBytes("1234567812345678");
        readonly static RijndaelManaged cripto = new RijndaelManaged();

        public static string Desencriptar(string ClaveCifrado, string Cadena)
        {
            //Este metodo no se requiere estructurar / optimizar
            byte[] Clave = Encoding.ASCII.GetBytes(ClaveCifrado);

            byte[] inputBytes = Convert.FromBase64String(Cadena);

            string textoLimpio = String.Empty;

            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }
    }
}
