using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OutlookDemo
{
    public partial class Login : Form
    {
        private const string conn = @"Data Source=Data\LoginDB.db;Version=3;";
        public Login()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            string name;

            //if (username == "admin" && password == "1")
            //{
            //    Form1 form1 = new Form1(username);
            //    form1.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Login failed.");
            //}



           

           
            try
            {

                String querry = ("SELECT *  FROM Login where Login='" + guna2TextBox1.Text + "' AND Password='" + guna2TextBox2.Text + "'");

                SQLiteDataAdapter dt = new SQLiteDataAdapter(querry, conn );
                DataTable dataTable = new DataTable();
                dt.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {

                  //  DataGridViewCell cell = malumotdg.Rows[e.RowIndex].Cells[e.ColumnIndex];
                 //   string sourceFilePath = cell.OwningRow.Cells["url"].Value.ToString();
                   // name = dataTable.Columns[2].ToString();
                    name = dataTable.Columns[2].ToString();
                    username = guna2TextBox1.Text;
                    password = guna2TextBox2.Text;

                    Form1 form1 = new Form1(username, name);
                    form1.Show();
                    this.Hide();

              

                }
                else
                {
                    MessageBox.Show("Login yoki parol noto'g'ri");
                }
            }
            catch
            {
                MessageBox.Show("Login yoki parol noto'g'ri");
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
