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
    public partial class Абонементы : Form
    {
        public Абонементы()
        {
            InitializeComponent();
        }

        public string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb";

        private void Абонементы_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString)) //connString - строка подключения
            {
                string commText = "SELECT * FROM [Абонементы]";
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
                        comboBox1.Items.Add("Выберите  Id_абонемента");
                        string strSQL = "SELECT [Абонементы.Код_абонемента] FROM [Абонементы]";
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

        //Добавить
        private void button5_Click(object sender, EventArgs e)
        {
            using (var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
            {
                cn.Open();
                using (OleDbCommand Number = cn.CreateCommand())
                {
                    Number.CommandText = "INSERT INTO [Абонементы] (Описание, Цена) values" +
                        " ('" + textBox1.Text + "','" + textBox2.Text + "');";
                    int numberOfUpdatedItems = Number.ExecuteNonQuery();
                }
                cn.Close();
                string commText = "SELECT * FROM [Абонементы]";
                OleDbCommand comm = new OleDbCommand(commText, cn);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        //Удаление
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
            {
                cn.Open();
                using (OleDbCommand Number = cn.CreateCommand())
                {
                    Number.CommandText = "DELETE FROM [Абонементы] WHERE [Абонементы.Код_абонемента] =" + dataGridView1.SelectedRows[0].Cells[0].Value; //Возвращает значение первой ячейки выбранной строки
                    int numberOfUpdatedItems = Number.ExecuteNonQuery();
                }
                cn.Close();
                string commText = "SELECT * FROM [Абонементы]";
                OleDbCommand comm = new OleDbCommand(commText, cn);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Меню a = new Меню();
            a.Show();
            this.Hide();
        }
    }
}
