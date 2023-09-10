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
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace OutlookDemo
{
    public partial class Login : Form
    {
        private SQLiteConnection connection;
        private const string dba = @"Data Source=Data\LoginDB.db;Version=3;";
        public Login()
        {
            InitializeComponent();
            connection = new SQLiteConnection(@"Data Source=Data\LoginDB.db;Version=3;");

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            if (CheckCredentials(username, password))
            {
                string lastName = GetLastName(username);
                Form1 form1 = new Form1(username, lastName);
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login va kod noto'g'ri!");
            }
        }
        private bool CheckCredentials(string username, string password)
        {
            connection.Open();

            string query = "SELECT COUNT(*) FROM LoginTab  WHERE Login = @Login AND Password = @password  ";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Login", username);
            command.Parameters.AddWithValue("@password", password);
     
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return count > 0;
        }


        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private string GetLastName(string username)
        {
            connection.Open();

            string query = "SELECT LastName FROM Login WHERE Login = @Login";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Login", username);

            string lastName = command.ExecuteScalar().ToString();
            connection.Close();

            return lastName;
        
    }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
