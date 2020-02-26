using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        string connString = "SERVER = 85.128.231.181; PORT = 3306; DATABASE = [name]; UID = [uid]; PASSWORD = [password];";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connString = "SERVER = 85.128.231.181; PORT = 3306; DATABASE = [name]; UID = [uid]; PASSWORD = [password];";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MessageBox.Show("SQL connection success");

                string query = "SELECT * FROM data";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader read = cmd.ExecuteReader();

                //MySqlDataAdapter

                while (read.Read())
                {
                    richTextBox1.Text += read["id"] + "";
                    richTextBox2.Text += read["name"] + "";
                    richTextBox3.Text += read["surname"] + "";
                    richTextBox4.Text += read["age"] + "";
                }
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connString = "SERVER = 85.128.231.181; PORT = 3306; DATABASE = [name]; UID = [uid]; PASSWORD = [password];";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                

                string query = $"INSERT INTO data (id, name, surname, age) values ('{0}','{1}', '{2}', '{3}')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("SQL connection success");

                
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connString = "SERVER = 85.128.231.181; PORT = 3306; DATABASE = [name]; UID = [uid]; PASSWORD = [password];";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();


                string query = $"UPDATE data SET name = 7, surname = 8 WHERE ID = 10";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("SQL connection success");


                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string age = textBox5.Text;
            string query = $"INSERT INTO test SET id = NULL, name = \"{name}\", surname = \"{surname}\", age = {age}";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string age = textBox5.Text;
            string query = "TRUNCATE TABLE test";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string age = textBox5.Text;
            string query = $"SELECT * FROM test";
            
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            //cmd.Clone();
            while (read.Read())
            {
                richTextBox5.Text += read["name"] + "\n";
                richTextBox6.Text += read["surname"] + "\n";
                richTextBox7.Text += read["age"] + "\n";
            }
            conn.Close();
        }
    }
}
