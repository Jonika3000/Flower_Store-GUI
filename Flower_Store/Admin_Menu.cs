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
    public partial class Admin_Menu : Form
    {
        User user = new User();
        public Admin_Menu()
        {
            InitializeComponent();
        }
        public Admin_Menu(User q)
        {
            InitializeComponent();
            user = q;
            UpdateMoney();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Visible = true;
        }
      public  void UpdateMoney()//обновления данных о кошельке
        {
            var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных об деньгах магаза
            label2.Text = baze.flowerStore.Wallet.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_flower m = new Add_flower();
            m.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Orders m = new View_Orders();
            m.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Flowers m = new Show_Flowers();
            m.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Change_Password m = new Change_Password(user);
            m.ShowDialog();
        }
    }
}
