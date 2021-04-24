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
    public partial class Меню : Form
    {
        public Меню()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Клиенты a = new Клиенты();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Абонементы a = new Абонементы();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Тренеры a = new Тренеры();
            a.Show();
            this.Hide();
        }

        
    }
}
