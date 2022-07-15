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
    public partial class Show_Flowers : Form
    {
        public Show_Flowers()
        {
            InitializeComponent();
            var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных списка заказов с меню
            baze.flowerStore.ShowAll(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }
    }
}
