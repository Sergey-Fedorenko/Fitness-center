using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа__Фитнес_центр
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

       

        //Кнопка выхода из приложения
        private void button3_Click(object sender, EventArgs e)
        {
           
            Application.Exit();

        }
        //Кнопка - авторизации
        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация a = new Авторизация();
            a.Show();
            this.Hide();
        }
        // Кнопка регистрации
        private void button2_Click(object sender, EventArgs e)
        {
            Регистрация a = new Регистрация();
            a.Show();
            this.Hide();
        }
    }
}
