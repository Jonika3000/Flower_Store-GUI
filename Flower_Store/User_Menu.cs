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
    public partial class User_Menu : Form
    {
        User user = new User();
        public User_Menu()
        {
            InitializeComponent();
        }
        public User_Menu(User q)
        {
            InitializeComponent();
            user = q;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Visible = true ;
             
        }

        private void button1_Click(object sender, EventArgs e)//сделать заказ
        {
            this.Hide();
            Create_Order m = new Create_Order();
            m.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Change_Password m = new Change_Password(user);
            m.ShowDialog();
        }
    }
}
