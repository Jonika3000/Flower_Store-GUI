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
           
        }
        public void ShowAll(ListBox l) //показать все цветы в наличии с помощю ListBox
        {
           
             
            
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
           
        }
    }
}
 