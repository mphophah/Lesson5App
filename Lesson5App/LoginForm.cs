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

namespace Lesson5App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;


            if (username.Trim() == "" && password.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error");
            }
            else
            {
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                SQLiteConnection conn = new SQLiteConnection("Data Source=databaseFile.db; Version=3");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Successfully loged in");
                }
                else
                {
                    MessageBox.Show("Wrong login details");
                }
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username.Trim() == "" && password.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error");
            }
            else
            {
                string query = "insert into users(username,password) values(@username, @password)";
                SQLiteConnection conn = new SQLiteConnection("Data Source=databaseFile.db; Version=3");
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i != 0)
                {
                    MessageBox.Show("Successfully saved");
                }

            }
        }
    }
}
