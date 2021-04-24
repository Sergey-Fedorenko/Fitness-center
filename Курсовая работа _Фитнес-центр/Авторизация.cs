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
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        
        //Кнопка назад
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Логин";
            textBox2.Text = "Пароль";
        }

        public string dostup, parol, FIO;

        //Авторизация
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

                        string strSQL = "SELECT Пользователь.Пароль,Пользователь.Доступ,Пользователь.ФИО FROM Пользователь WHERE Пользователь.Логин='" + textBox1.Text + "'";
                        OleDbCommand myCommand = new OleDbCommand(strSQL, cn);
                        OleDbDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            parol = dr[0].ToString();
                            dostup = dr[1].ToString();
                            FIO = dr[2].ToString();
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
            if (parol == null || dostup == null || FIO == null)
            {
                MessageBox.Show("Данного пользователя не существует, проверьте БД!");
            }
            else
            {
                if (parol == textBox2.Text)
                {
                    switch (dostup)
                    {
                        case "Администратор":
                            MessageBox.Show("Добро пожаловать, " + FIO + " !" + Environment.NewLine + "Вы:" + " " + dostup + "!");
                            
                            Меню form4 = new Меню();

                            form4.Show();
                            break;                
                    }
                }
                else
                {
                    MessageBox.Show("Пароль неверный , проверь правильность написания!");
                }
            }
        }
    }
}
