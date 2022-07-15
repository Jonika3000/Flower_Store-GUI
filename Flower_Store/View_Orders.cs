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
    public partial class View_Orders : Form
    {
        string selected;
        public View_Orders()
        {
            InitializeComponent();
            Shown += First;
            comboBox1.SelectedIndexChanged += ComBoxChange;
        }
        void First(object sender, EventArgs e)//добавления заказов к combox 
        {
            var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных об заказ с меню
            foreach (var c in baze.orders)
            {
                comboBox1.Items.Add($"{c.id}");
            }
            HideText();

        }
        void ComBoxChange(object sender, EventArgs e)
        {
            selected = comboBox1.SelectedItem.ToString();
            var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных об заказ с меню
            for (int i = 0; i < baze.orders.Count; i++)
            {
                if (baze.orders[i].id == Convert.ToInt32(selected) && baze.orders[i].Status == false)
                {
                    label1.Text = ($"ID: {baze.orders[i].id}");
                    var r_Count = baze.orders[i].flowers.Where(a => a.GetType() == typeof(Rose)).Count(); // Сколько роз в заказе
                    label5.Text = r_Count.ToString();
                    var с_Count = baze.orders[i].flowers.Where(a => a.GetType() == typeof(Chamomile)).Count(); // Сколько ромашек в заказе
                    label6.Text = с_Count.ToString();
                    var t_Count = baze.orders[i].flowers.Where(a => a.GetType() == typeof(Tulpan)).Count(); // Сколько тюльпанов в заказе
                    label7.Text = t_Count.ToString();
                    break;
                }

            }
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //order.Status = true;
            //flowerStore.Del(order);
            if (selected != null)
            {
                var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных списка заказов с меню

                baze.orders.Where(c => c.id == Convert.ToInt32(selected)).Select(c => { c.Status = true; return c; }).ToList();  //изменения статуса заказа
                baze.flowerStore.Del(baze.orders.Where(c => c.id == Convert.ToInt32(selected)).FirstOrDefault());//удаления цветов со склада
                comboBox1.Items.Remove(selected);// удаления заказа с массива
                HideText();

            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                var baze = Application.OpenForms.OfType<Login>().FirstOrDefault();//для получения данных списка заказов с меню
                baze.orders.Remove(baze.orders.Where(c => c.id == Convert.ToInt32(selected)).FirstOrDefault());//удаления заказа со списка
                comboBox1.Items.Remove(baze.orders.Where(c => c.id == Convert.ToInt32(selected)).FirstOrDefault());// удаления заказа с массива
                HideText();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var baze = Application.OpenForms.OfType<Admin_Menu>().FirstOrDefault();
            baze.UpdateMoney();//обновления счета магазина
            this.Close();
            Application.OpenForms[1].Visible = true;
            
        }
        void HideText()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }
    }
}
