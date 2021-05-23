using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СтажировкаDeeplay.Models;
using System.Data.OleDb;

namespace СтажировкаDeeplay
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\..\БДDeeplay.mdb");
                connection.Open();
                OleDbDataReader reader = new OleDbCommand("SELECT Пользователи.Код FROM Пользователи WHERE " +
                    $"Пользователи.Логин='{textBox1.Text}' AND Пользователи.Пароль='{textBox2.Text}'", connection).ExecuteReader();
                if (reader.HasRows)
                {
                    Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}
