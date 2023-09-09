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
        string IdLogin;
        public AdminForm()
        {
            InitializeComponent();

            populate();



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
            if (NameTXT.Text == "" && LasnameTxt.Text == "" && PassTxt.Text == "" && LoginTxt.Text == "")
            {
                MessageBox.Show("Ma'lumotni to'liq  kiriting", "Ma'lumot");
            }
            else
            {

                using (SQLiteConnection con = new SQLiteConnection(dba))


                using (SQLiteCommand com = new SQLiteCommand("INSERT INTO Login(  Name, LastName,Password ,Login ,Guid)values (  @Name, @LastName, @Password, @Login, @Guid) ", con))
                {
                    con.Open();
                    com.Parameters.AddWithValue("Name", NameTXT.Text);
                    com.Parameters.AddWithValue("LastName", LasnameTxt.Text);
                    com.Parameters.AddWithValue("Login", LoginTxt.Text);
                    com.Parameters.AddWithValue("Password", PassTxt.Text);
                    com.Parameters.AddWithValue("Guid", guid.ToString());

                    com.ExecuteNonQuery();
                    con.Close();


                    Empty();
                   

                }
                populate();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            MalumotDb.Columns[0].Visible = false;
            MalumotDb.Columns[3].Visible = false;
            MalumotDb.Columns[4].Visible = false;
            MalumotDb.Columns[5].Visible = false;

        }
        private void Empty()
        {
            NameTXT.Text = "";
            LasnameTxt.Text = "";
            PassTxt.Text = "";
            LoginTxt.Text = "";

        }
        private void MalumotDb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MalumotDb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = MalumotDb.Rows[e.RowIndex];

                NameTXT.Text = row.Cells[1].Value.ToString();
                LasnameTxt.Text = row.Cells[2].Value.ToString();
                LoginTxt.Text = row.Cells[5].Value.ToString();
                PassTxt.Text = row.Cells[3].Value.ToString();
                IdLogin = row.Cells[0].Value.ToString();    
            }
        }

        private void DeleteBt_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(dba))
                try
                {
                    if (NameTXT.Text == "")
                    {
                        MessageBox.Show("O'chirmoqchi bo'lgan ma'lumotingizni tanlang");
                    }

                    else
                    {
                        con.Open();
                    string query = "DELETE FROM Login WHERE Id = '" + IdLogin + "'";

                    SQLiteCommand cmd = new SQLiteCommand(query, con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ma'lumot o'chirildi");
                    con.Close();
                    populate();
                    Empty();
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
