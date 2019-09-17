using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia
{
    public class Criptografia
    {
        protected const string ENCRYPTKEY = "E!32sasfFd234#$w33";

        public static string GetEncryptKey()
        {
            return LerArquivo();
        }

        private static string LerArquivo()
        {
            FileStream x;
            string arquivo = "key.txt";
            x = File.OpenWrite(arquivo);
            x.Close();
            StreamReader leitor = new StreamReader(arquivo);
            string txtChave = leitor.ReadLine();

            if (string.IsNullOrEmpty(txtChave))
            {
                leitor.Close();
                StreamWriter escritor = new StreamWriter(arquivo);
                escritor.WriteLine("E!32sasfFd234#$w33");
                escritor.Close();
                return LerArquivo();
            }
            return txtChave;

        }
    }
}
