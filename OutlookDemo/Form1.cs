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
            EncryptedData uc = new EncryptedData();
            addUserControl(uc);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EncryptedData uc = new EncryptedData();
            addUserControl(uc);


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            

            Encryptcontrol uc = new Encryptcontrol();
            addUserControl(uc);


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

        private void malumotdg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void malumotdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    } 
  }
 

//}