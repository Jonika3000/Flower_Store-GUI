using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Store
{
    public class FlowerStor
    {
        public int Wallet = 0;
        List<Flower> AllFlowers = new List<Flower>();
        public List<Flower> Sell(int Roza1, int Romashka1, int Tulpan1)
        {
            List<Flower> all = new List<Flower>();//готовый букет цветов
            for (int i = 0; i < Roza1; i++)
            {
                bool allHas = AllFlowers.Any(s => s.GetType() == typeof(Rose)); //Проверка есть ли в наличии роза
                if (allHas == true)
                    all.Add(new Rose());

            }
            for (int i = 0; i < Romashka1; i++)
            {
                bool allHas = AllFlowers.Any(s => s.GetType() == typeof(Chamomile));//Проверка есть ли в наличии ромашка
                if (allHas == true)
                    all.Add(new Chamomile());
            }
            for (int i = 0; i < Tulpan1; i++)
            {
                bool allHas = AllFlowers.Any(s => s.GetType() == typeof(Tulpan));//Проверка есть ли в наличии тюльпан
                if (allHas == true)
                    all.Add(new Tulpan());
            }
            return all;//возращаем готовый букет 
        }
        public void ShowAll(ListBox l) //показать все цветы в наличии с помощю ListBox
        {
            for (int i = 0; i < AllFlowers.Count; i++)
            {
                if (AllFlowers[i].GetType() == typeof(Chamomile))
                {
                    l.Items.Add("Chamomile");
                }
                if (AllFlowers[i].GetType() == typeof(Rose))
                {
                    l.Items.Add("Rose");
                }
                if (AllFlowers[i].GetType() == typeof(Tulpan))
                {
                    l.Items.Add("Tulpan");
                }
            }
        }
        void DeleteRose()
        {
            for (int i = 0; i < AllFlowers.Count; i++)
            {
                if (AllFlowers[i].GetType() == typeof(Rose))
                {
                    AllFlowers.Remove(AllFlowers[i]);
                    break;
                }
            }
        }
        void DeleteTulpan()
        {
            for (int i = 0; i < AllFlowers.Count; i++)
            {
                if (AllFlowers[i].GetType() == typeof(Tulpan))
                {
                    AllFlowers.Remove(AllFlowers[i]);
                    break;
                }
            }
        }
        void DeleteChamomile()
        {
            for (int i = 0; i < AllFlowers.Count; i++)
            {
                if (AllFlowers[i].GetType() == typeof(Chamomile))
                {
                    AllFlowers.Remove(AllFlowers[i]);
                    break;
                }
            }
        }
        public List<Flower> sellSequence(int Roza, int Romashka, int Tulpan)
        {
            List<Flower> all = new List<Flower>();// букет цветов
            int vsego = Roza + Romashka + Tulpan;//всего цветов
            for (int i = 0; i < vsego; i++)
            {
                if (Roza != 0)
                {
                    all.Add(new Rose());
                    Roza--;
                }
                if (Romashka != 0)
                {
                    all.Add(new Chamomile());
                    Romashka--;
                }
                if (Tulpan != 0)
                {
                    all.Add(new Tulpan());
                    Tulpan--;
                }
            }
            return all;//готовый букет цветов
        }
        public void Del(Order r) //обработать заказ , удаляя со склада нужные цветы и получая деньги
        {
            for (int i = 0; i < r.flowers.Count; i++)
            {
                if (r.flowers[i].GetType() == typeof(Rose))
                {
                    DeleteRose();
                    Wallet += r.flowers[i].Price;
                }
                if (r.flowers[i].GetType() == typeof(Chamomile))
                {
                    DeleteChamomile();
                    Wallet += r.flowers[i].Price;
                }
                if (r.flowers[i].GetType() == typeof(Tulpan))
                {
                    DeleteTulpan();
                    Wallet += r.flowers[i].Price;
                }
            }
        }
        public void AddFlower(int r, int c , int t)//добавления цветов, принимает количество каждого типа цветка
        {
            for (int i = 0; i < r; i++)
                AllFlowers.Add(new Rose());
            for (int i = 0; i < c; i++)
                AllFlowers.Add(new Chamomile());
            for (int i = 0; i < t; i++)
                AllFlowers.Add(new Tulpan());
        }
    }
}
 