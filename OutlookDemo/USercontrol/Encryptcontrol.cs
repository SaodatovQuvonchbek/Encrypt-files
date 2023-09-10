using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OutlookDemo.USercontrol
{
    public partial class Encryptcontrol : UserControl
    {
        public Encryptcontrol()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //Faylarni qoshish
            OpenFileDialog filepath = new OpenFileDialog();
            filepath.Title = "Select File";
            //  filepath.InitialDirectory = @"C:\";
            filepath.Filter = "All files (*.*)|*.*";
            filepath.Multiselect = true;
            filepath.FilterIndex = 1;
            filepath.ShowDialog();
            foreach (String file in filepath.FileNames)
            {
                listBox1.Items.Add(file);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            //This is for selected files
            if (listBox1.Items.Count > 0)
            {
                for (int num = 0; num < listBox1.Items.Count; num++)
                {
                    string e_file = "" + listBox1.Items[num];
                    if (!e_file.Trim().EndsWith(".!KS") && File.Exists(e_file))
                    {
                        EncryptFile("" + listBox1.Items[num], "" + listBox1.Items[num] + ".!KS", textBox1.Text);
                        File.Delete("" + listBox1.Items[num]);
                    }
                }
            }

            MessageBox.Show("Fayl muvaffaqiyatli saqlandi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////This is for selected folders
            //if (listBox2.Items.Count > 0)
            //{
            //    for (int num = 0; num < listBox2.Items.Count; num++)
            //    {
            //        string d_file = "" + listBox2.Items[num];
            //        string[] get_files = Directory.GetFiles(d_file);
            //        foreach (string name_file in get_files)
            //        {
            //            if (!name_file.Trim().EndsWith(".!LOCKED") && File.Exists(name_file))
            //            {
            //                EncryptFile(name_file, name_file + ".!LOCKED", textBox1.Text);
            //                File.Delete(name_file);
            //            }
            //        }
            //    }
            //}


            char[] mychar = { '!', '.', 'K', 'S' };
        }
        private void EncryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch { }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}