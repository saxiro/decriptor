using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Criptografia
{
    public class Decrypt: Criptografia
    {
        public static string DecryptData(dynamic Message, string chave)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESkey = HashProvider.ComputeHash(UTF8.GetBytes(chave));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESkey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Results = null;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            if(Results == null)
            {
                return "";
            }
            return UTF8.GetString(Results);
        }
    }
}
