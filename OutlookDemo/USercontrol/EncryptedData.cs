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
using System.Windows.Forms;

namespace OutlookDemo.USercontrol
{
    public partial class EncryptedData : UserControl
    {
        public EncryptedData()
        {
            InitializeComponent();
        }

        private void EncryptedData_Load(object sender, EventArgs e)
        {
            string folderPath = @"D:\Yangi";


            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Belirtilen klasör bulunamadı!");
                return;
            }



            DataTable dtFiles = new DataTable();
            dtFiles.Columns.Add("Id", typeof(int));
            dtFiles.Columns.Add("Ico", typeof(Image));
            dtFiles.Columns.Add("Nomi");
            dtFiles.Columns.Add("url", typeof(string));
            dtFiles.Columns.Add("Hajmi (byte)", typeof(long));
            dtFiles.Columns.Add("Vaqt", typeof(DateTime));





            string[] files = Directory.GetFiles(folderPath);
            Array.Sort(files);


            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                Icon fileIcon = Icon.ExtractAssociatedIcon(file);
                FileInfo fileInfo = new FileInfo(file);

                Bitmap resizedIcon = new Bitmap(fileIcon.ToBitmap(), new Size(16, 16));


                dtFiles.Rows.Add(i + 1, resizedIcon, fileInfo.Name, fileInfo.FullName, fileInfo.Length, fileInfo.LastWriteTime);

            }
            malumotdg.DataSource = dtFiles;
            malumotdg.Columns["Id"].Width = 30;
            malumotdg.Columns["Ico"].Width = 25;
            malumotdg.Columns["Hajmi (byte)"].Width = 100;
            malumotdg.Columns["Vaqt"].Width = 160;
            malumotdg.Columns["url"].Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Btndg";
            btn.Name = "Btndg";
            btn.Text = "Deshifrlash";
            btn.UseColumnTextForButtonValue = true;
            malumotdg.Columns.Add(btn);
            malumotdg.Columns[6].Width = 90;


            malumotdg.RowTemplate.Height = 50;
            malumotdg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void malumotdg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == malumotdg.Columns["Btndg"].Index)
            {
                //    if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                //    {

                DataGridViewCell cell = malumotdg.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string sourceFilePath = cell.OwningRow.Cells["url"].Value.ToString();
                //  string sourceFilePath = @"D:\yangi\1.mp4";
                string fileName = Path.GetFileName(sourceFilePath);
                // SaveFileDialog yaratamiz va sozlamalarni belgilaymiz
                SaveFileDialog saveFileDialog = new SaveFileDialog();

            //    saveFileDialog.Filter = "Deshifrlash files (*.mp4)|*.mp4";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string targetFilePath = (saveFileDialog.FileName);
                        File.Move((sourceFilePath), targetFilePath);
                        MessageBox.Show("Fayl muvaffaqiyatli saqlandi!", "Muvaffaqiyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xatolik: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                malumotdg.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void DecryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch { }
        }
    }
    }

