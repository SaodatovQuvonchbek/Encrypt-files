using Guna.UI2.WinForms;
using OutlookDemo.Properties;
using OutlookDemo.USercontrol;
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
using System.Web.UI;
using System.Windows.Forms;

namespace OutlookDemo
{
    public partial class Form1 : Form
    {
       

        public Form1(string login, string name)
        {
            InitializeComponent();
            guna2HtmlLabel2.Text = "Xush kelibsiz, " + login + "!";
            Namelb.Text = "Familiyangiz: " + name;

        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;

        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void addUserControl(System.Windows.Forms.UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

     
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //EncryptedData uc = new EncryptedData();
            //addUserControl(uc);
            panel3.Visible = false;
            panel4.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //EncryptedData uc = new EncryptedData();
            //addUserControl(uc);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {


            //Encryptcontrol uc = new Encryptcontrol();
            //addUserControl(uc);

            panel3.Visible = true;
            panel4.Visible = false;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {

          
        }

        private void guna2Button9_DoubleClick(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button10_MouseHover(object sender, EventArgs e)
        {
            Mualliflar.Visible = true;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_MouseLeave(object sender, EventArgs e)
        {
            Mualliflar.Visible = false;
        }

        private void guna2HtmlLabel5_MouseHover(object sender, EventArgs e)
        {

        }

        private void guna2Button6_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel5.Visible = true;
        }

        private void guna2Button6_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel5.Visible = false;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button9_MouseLeave(object sender, EventArgs e)
        {
            til.Visible = false;
        }

        private void guna2Button9_MouseHover(object sender, EventArgs e)
        {
            til.Visible = true;
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }


        private void malumotdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

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
    } 
  }
 

//}