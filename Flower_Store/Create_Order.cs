using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flower_Store
{
    public partial class Create_Order : Form
    {
        bool just = true; //какой именно это заказ простой(true) или со комбинацией(false)
        public Create_Order()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//Только цифры в тексте
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//Только цифры в тексте
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)//Только цифры в тексте
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random k = new Random();
            Order or = new Order(k.Next(0, 1000));
            int r=Convert.ToInt32(textBox1.Text);
            int c = Convert.ToInt32(textBox2.Text);
            int t = Convert.ToInt32(textBox3.Text);
            var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных об заказ с меню
            if (just==true)
                or.flowers = baze.flowerStore.Sell(r, c, t);
            else
                or.flowers = baze.flowerStore.sellSequence(r, c, t);
            baze.orders.Add(or);//добавления нового заказа в список
            this.Close();
            Application.OpenForms[1].Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            just = false;
        }
    }
}
