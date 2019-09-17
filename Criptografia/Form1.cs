using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criptografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtChave.Text = Criptografia.GetEncryptKey();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text = Encrypt.EncryptData(txtEntrada.Text, txtChave.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtResultado.Text = Decrypt.DecryptData(txtEntrada.Text, txtChave.Text);
        }
    }
}
