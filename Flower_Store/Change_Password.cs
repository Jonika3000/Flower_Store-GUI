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
    public partial class Change_Password : Form
    {
        string newpass = string.Empty;
        User user = new User();
        public Change_Password()
        {
            InitializeComponent();
        }
        public Change_Password(User u)
        {
            InitializeComponent();
            user = u;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newpass = textBox1.Text;
            if (newpass!=string.Empty && newpass.Length>=6)
            {
                user.Password = newpass;
                var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных списка пользувателей с меню
                baze.users.Where(c => c.Login == user.Login).Select(c => { c.Password = newpass; return c; }).ToList();//изменения пароля пользувателя
                if (user.Login=="Admin")
                {
                    baze.adm.Password = newpass;
                }
                this.Close();
                Application.OpenForms[1].Visible = true;
            }
            else
            {
                MessageBox.Show("Error pass", "Error pass", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
