using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace СтажировкаDeeplay
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        OleDbCommand command = new OleDbCommand();
        OleDbConnection connection = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\..\БДDeeplay.mdb";

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДDeeplayDataSet.Руководители". При необходимости она может быть перемещена или удалена.
            this.руководителиTableAdapter.Fill(this.бДDeeplayDataSet.Руководители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДDeeplayDataSet.Подразделение". При необходимости она может быть перемещена или удалена.
            this.подразделениеTableAdapter.Fill(this.бДDeeplayDataSet.Подразделение);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДDeeplayDataSet.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.бДDeeplayDataSet.Должности);


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                
                connection.Open();
                string query = "delete from Сотрудники where Код="+ id1.Text+"";
                MessageBox.Show(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Сотрудники (Код,ДатаРождения,ФИО,Пол,Руководитель,Должность) values('" + id1.Text + "','" + date1.Text + "','" + fio1.Text + "','" + gender1.Text + "','" + director1.Text + "','" + post1.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = metroGrid2.Rows[e.RowIndex];
            id1.Text = row.Cells[0].Value.ToString();
            fio1.Text = row.Cells[2].Value.ToString();
            date1.Text = row.Cells[1].Value.ToString();
            gender1.Text = row.Cells[3].Value.ToString();
            post1.Text = row.Cells[5].Value.ToString();
            director1.Text = row.Cells[4].Value.ToString();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = metroGrid1.Rows[e.RowIndex];
            id2.Text = row.Cells[0].Value.ToString();
            fio2.Text = row.Cells[1].Value.ToString();
            date2.Text = row.Cells[2].Value.ToString();
            gender2.Text = row.Cells[3].Value.ToString();
            post2.Text = row.Cells[5].Value.ToString();
            podr1.Text = row.Cells[4].Value.ToString();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.Connection = connection;
            string query = "SELECT * from Сотрудники";
            command.CommandText = query;

            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            metroGrid2.DataSource = dt;
            connection.Close();

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.Connection = connection;
            string query = "SELECT * from Руководители";
            command.CommandText = query;

            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            metroGrid1.DataSource = dt;
            connection.Close();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
        
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void id1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                id1.Text = row.Cells[0].Value.ToString();
                date1.Text = row.Cells[1].Value.ToString();
                fio1.Text = row.Cells[2].Value.ToString();
                gender1.Text = row.Cells[3].Value.ToString();
                post1.Text = row.Cells[5].Value.ToString();
                director1.Text = row.Cells[4].Value.ToString();
            }
        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                id2.Text = row.Cells[0].Value.ToString();
                fio2.Text = row.Cells[1].Value.ToString();
                date2.Text = row.Cells[2].Value.ToString();
                gender2.Text = row.Cells[3].Value.ToString();
                post2.Text = row.Cells[5].Value.ToString();
                podr1.Text = row.Cells[4].Value.ToString();
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Руководители (Код,ФИО,ДатаРождения,Пол,Подразделение,Должность) values('" + id2.Text + "','" + fio2.Text + "','" + date2.Text + "','" + gender2.Text + "','" + podr1.Text + "','" + post2.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                string query = "update Сотрудники set ДатаРождения='" + date1.Text + "' ,ФИО='" + fio1.Text + "' ,Пол='" + gender1.Text + "' ,Руководитель='" + director1.Text + "' ,Должность='" + post1.Text + "' where Код="+ id1.Text +"";
                MessageBox.Show(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }

        private void edit2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                string query = "update Руководители set ФИО='" + fio2.Text + "' ,ДатаРождения='" + date2.Text + "' ,Пол='" + gender2.Text + "' ,Подразделение='" + podr1.Text + "' ,Должность='" + post2.Text + "' where Код=" + id2.Text + "";
                MessageBox.Show(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                string query = "delete from Руководители where Код=" + id2.Text + "";
                MessageBox.Show(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
                connection.Close();
            }
        }
    }
}
