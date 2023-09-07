using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo
{
    public partial class AdminForm : Form
    {
        private const string dba = @"Data Source=Data\LoginDB.db;Version=3;";
        
        DataTable dt = new DataTable();
        public AdminForm()
        {
            InitializeComponent();
           


          
        }
        private void populate()
        {  //SQLiteDataAdapter da = new SQLiteDataAdapter("select Id, Savol, Ajavob, Bjavob, Cjavob, Djavob, Ejavob from QuesTab", con);
            using (SQLiteConnection con = new SQLiteConnection(dba))
            using (SQLiteCommand com = new SQLiteCommand("SELECT * FROM Login", con))

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(com))
            {
                con.Open();
                com.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                MalumotDb.DataSource = dt;
                con.Close();


            }
        }
            private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            if (NameTXT.Text == ""&& LasnameTxt.Text==""&&PassTxt.Text=="")
            {
                MessageBox.Show("Ma'lumotni to'liq  kiriting","Ma'lumot");
            }
            else
            {

                using (SQLiteConnection con = new SQLiteConnection(dba))


                using (SQLiteCommand com = new SQLiteCommand("INSERT INTO Login(  Name, LastName, Password,Guid)values (  @Name, @LastName, @Password,@Guid) ", con))
                {
                    con.Open();
                    com.Parameters.AddWithValue("Name", NameTXT.Text);
                    com.Parameters.AddWithValue("LastName", LasnameTxt.Text);
                    com.Parameters.AddWithValue("Password", PassTxt.Text);
                    com.Parameters.AddWithValue("Guid",guid.ToString());
              
                    com.ExecuteNonQuery();
                    con.Close();



                    NameTXT.Text = "";
                    LasnameTxt.Text = "";
                    PassTxt.Text = "";
                   
                }
                populate();
            }
        }
    }
}
