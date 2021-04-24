using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа__Фитнес_центр
{
    public partial class Клиенты : Form
    {
        public Клиенты()
        {
            InitializeComponent();
        }

        private void Администратор_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString)) //connString - строка подключения
            {
                string commText = "SELECT * FROM [Клиенты]";
                OleDbCommand comm = new OleDbCommand(commText, conn);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }


            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb";
                {
                    try
                    {
                        //Открыть подключение
                        cn.Open();
                        comboBox1.Items.Add("Выберите  Id пользователя");
                        string strSQL = "SELECT [Клиенты.Код_клиента] FROM [Клиенты]";
                        OleDbCommand myCommand = new OleDbCommand(strSQL, cn);
                        OleDbDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr[0].ToString());
                        }
                    }
                    catch (OleDbException ex)
                    {

                        // Протоколировать исключение
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // Гарантировать освобождение подключения
                        cn.Close();
                    }
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        public string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb";

        //Кнопка удаления
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
            {
                cn.Open();
                using (OleDbCommand Number = cn.CreateCommand())
                {
                    Number.CommandText = "DELETE FROM [Клиенты] WHERE [Клиенты.Код_клиента] =" + dataGridView1.SelectedRows[0].Cells[0].Value; //Возвращает значение первой ячейки выбранной строки
                    int numberOfUpdatedItems = Number.ExecuteNonQuery();
                }
                cn.Close();
                string commText = "SELECT * FROM [Клиенты]";
                OleDbCommand comm = new OleDbCommand(commText, cn);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        //Кнопка - редактирование
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {

                if (textBox1.Text != null & textBox1.Text != "")
                {
                    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                    {
                        cn.Open();
                        using (OleDbCommand Number = cn.CreateCommand())
                        {
                            Number.CommandText = "UPDATE [Клиенты] SET [Фамилия] ='" + textBox1.Text + "' WHERE [Клиенты.Код_клиента]= " + comboBox1.SelectedItem.ToString();
                            int numberOfUpdatedItems = Number.ExecuteNonQuery();
                        }
                        cn.Close();
                        string commText = "SELECT * FROM [Клиенты]";
                        OleDbCommand comm = new OleDbCommand(commText, cn);
                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

                if (textBox2.Text != null & textBox2.Text != "")
                {
                    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                    {
                        cn.Open();
                        using (OleDbCommand Number = cn.CreateCommand())
                        {
                            Number.CommandText = "UPDATE [Клиенты] SET [Имя] ='" + textBox2.Text + "' WHERE [Клиенты.Код_клиента]= " + comboBox1.SelectedItem.ToString();
                            int numberOfUpdatedItems = Number.ExecuteNonQuery();
                        }
                        cn.Close();
                        string commText = "SELECT * FROM [Клиенты]";
                        OleDbCommand comm = new OleDbCommand(commText, cn);
                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

                if (textBox3.Text != null & textBox3.Text != "")
                {
                    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                    {
                        cn.Open();
                        using (OleDbCommand Number = cn.CreateCommand())
                        {
                            Number.CommandText = "UPDATE [Клиенты] SET [Отчество] ='" + textBox3.Text + "' WHERE [Клиенты.Код_клиента]= " + comboBox1.SelectedItem.ToString();
                            int numberOfUpdatedItems = Number.ExecuteNonQuery();
                        }
                        cn.Close();
                        string commText = "SELECT * FROM [Клиенты]";
                        OleDbCommand comm = new OleDbCommand(commText, cn);
                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

                if (textBox5.Text != null & textBox5.Text != "")
                {
                    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                    {
                        cn.Open();
                        using (OleDbCommand Number = cn.CreateCommand())
                        {
                            Number.CommandText = "UPDATE [Клиенты] SET [Код_тренера] ='" + textBox3.Text + "' WHERE [Клиенты.Код_клиента]= " + comboBox1.SelectedItem.ToString();
                            int numberOfUpdatedItems = Number.ExecuteNonQuery();
                        }
                        cn.Close();
                        string commText = "SELECT * FROM [Клиенты]";
                        OleDbCommand comm = new OleDbCommand(commText, cn);
                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбран Идентификатор пользователя!");
            }
        }

        //Изменить номер телефона
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                if (maskedTextBox1.Text != null & maskedTextBox1.Text != "")
                {
                    using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                    {
                        cn.Open();
                        using (OleDbCommand Number = cn.CreateCommand())
                        {
                            Number.CommandText = "UPDATE [Клиенты] SET [Контактный_телефон] ='" + maskedTextBox1.Text + "' WHERE [Клиенты.Код_клиента]= " + comboBox1.SelectedItem.ToString();
                            int numberOfUpdatedItems = Number.ExecuteNonQuery();
                        }
                        cn.Close();
                        string commText = "SELECT * FROM [Клиенты]";
                        OleDbCommand comm = new OleDbCommand(commText, cn);
                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        //Кнопка - добавить
        private void button5_Click(object sender, EventArgs e)
        {
            using (var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
            {
                cn.Open();
                using (OleDbCommand Number = cn.CreateCommand())
                {
                    Number.CommandText = "INSERT INTO [Клиенты] (Фамилия, Имя, Отчество, Контактный_телефон, Код_тренера, Код_абонемента) values" +
                        " ('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + maskedTextBox1.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "');";
                    int numberOfUpdatedItems = Number.ExecuteNonQuery();
                }
                cn.Close();
                string commText = "SELECT * FROM [Клиенты]";
                OleDbCommand comm = new OleDbCommand(commText, cn);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        //Кнопка - назад
        private void button3_Click(object sender, EventArgs e)
        {
            Меню a = new Меню();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
    }
}
