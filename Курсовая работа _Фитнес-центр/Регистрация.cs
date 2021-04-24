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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Логин";     
            textBox2.Text = "Пароль";
            textBox3.Text = "ФИО";

            comboBox1.Items.AddRange(new object[] {
        "Администратор"});
        }

        //Кнопка назад
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        public string check_login;

        //Регистрация
        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb";
                {
                    try
                    {
                        //Открыть подключение
                        cn.Open();

                        string strSQL = "SELECT Пользователь.Логин FROM Пользователь WHERE Пользователь.Логин='" + textBox2.Text + "'";
                        OleDbCommand myCommand = new OleDbCommand(strSQL, cn);
                        OleDbDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            check_login = dr[0].ToString();
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
            if (check_login == null)
            {
                using (var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Fedorenko_Sergey.accdb "))
                {
                    cn.Open();
                    using (OleDbCommand Number = cn.CreateCommand())
                    {
                        Number.CommandText = "INSERT INTO [Пользователь] (Логин,Пароль,ФИО,Доступ) values" +
                            " ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "');";
                        int numberOfUpdatedItems = Number.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                MessageBox.Show(textBox1.Text + ", " + "Поздравляем, вы успешно зарегистрировались!" + Environment.NewLine +
                    "Ваш Логин: " + textBox1.Text + Environment.NewLine + "Ваш Пароль: " + textBox2.Text + 
                    Environment.NewLine + "Вы: " + comboBox1.Text);
                Form1 a = new Form1();
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
        }
    }
}
