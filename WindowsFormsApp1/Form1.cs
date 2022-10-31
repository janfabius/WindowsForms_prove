using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private int i = 0;

        public static string SetValueForText1 = "";

        public Form1()
        {
           
            InitializeComponent();
            button1.Text = "click";
            label1.Text = button1.Text;
            button2.Text = "reset";
            button3.Text = "Riavvia Form";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Fabio";
            i++;

            if (i == 2) { button1.Text = "Fabius!"; }
            if (i > 3) {

                button1.Text = i.ToString();

                if (i > 50)
                {

                    progressBar1.Enabled = false;
                    
                                    }

                else
                {
                    progressBar1.Value = i * 2;
                }


                    }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "click";
            label1.Text = button1.Text;
            button3.Text = "Riavvia Form";
            progressBar1.Value = progressBar1.Minimum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // label1.Text = "ENTER";
            if (e.KeyCode == Keys.Enter)
            {
                //button2_Click(this, new EventArgs());
                 label1.Text = "ENTER";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = "check 1 ATTIVATO";
            }
            else {
                label1.Text = "check 1 DISATTIVATO";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label1.Text = "check 2 ATTIVATO";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                label1.Text = "check 2 DISATTIVATO";
            }



        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 3-1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex.Equals(2))
            {
                textBox1.Text = comboBox1.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SetValueForText1 = textBox1.Text;
            //this.Hide();
            Form2 a1 = new Form2();
            a1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bici MiaBici = new bici();
            MiaBici.colore = "Verde";
            MiaBici.FaiUnaPedalata();
            int velocita = MiaBici.DammiVelocita(3);

            label2.Text = "Il colore della bici è " + MiaBici.colore +
                " e " + MiaBici.FaiUnaPedalata();
        }








        // Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a base64 encoded string
        public string Encrypt(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key)));
        }

        public string Decrypt(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }

        public byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        public byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };


        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = Encrypt("fabio", "fabius@");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label4.Text = Decrypt(label3.Text, "fabius@");
        }
    }
}
