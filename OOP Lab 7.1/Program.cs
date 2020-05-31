using System;
using System.Collections;



namespace OOP_Lab_7._1
{
    public class PoultryFarm : IComparable
    {
        public string name;
        public double weight;
        public float cena;
        public int number;
        public float height;



        public PoultryFarm(string name, double weight, float cena, int number, float height)
        {
            this.name = name;
            this.weight = weight;
            this.cena = cena;
            this.number = number;
            this.height = height;
        }

        public class SortByCena : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                PoultryFarm p1 = (PoultryFarm)ob1;
                PoultryFarm p2 = (PoultryFarm)ob2;
                if (p1.cena > p2.cena) return 1;
                if (p1.cena < p2.cena) return -1;
                return 0;
            }
        }

        public int CompareTo(object pers)
        {
            PoultryFarm p = (PoultryFarm)pers;
            if (this.weight > p.weight) return 1;
            if (this.weight < p.weight) return -1; return 0;
        }
        public void Info()
        {

            Console.WriteLine("{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", name, weight, cena, number, height);
        }
    }

    class Chiken : IEnumerable
    {
        public string name;
        public double weight;
        public float cena;
        public int number;
        public float height;



        public Chiken(string name, double weight, float cena, int number, float height)
        {
            this.name = name;
            this.weight = weight;
            this.cena = cena;
            this.number = number;
            this.height = height;
        }

        protected int size;
        protected PoultryFarm[] container;
    
        public Chiken()
        {
            size = 10;
            container = new PoultryFarm[size];
            FillContainer();
        }

        public Chiken(int size)
        {
            this.size = size;
            container = new PoultryFarm[size];
            FillContainer();
        }
        public Chiken(PoultryFarm[] container)
        {
            this.container = container;
            size = container.Length;
        }
        void FillContainer()
        {
            
            
                PoultryFarm p1 = new PoultryFarm("Курки", 5, 130, 20, 22);
                PoultryFarm p2 = new PoultryFarm("Качки", 7, 150, 20, 28);
                PoultryFarm p3 = new PoultryFarm("Перепілки", 2, 300, 13, 10);
                PoultryFarm p4 = new PoultryFarm("Курчата", 0.2, 330, 100, 8);
                PoultryFarm p5 = new PoultryFarm("Голуби", 1, 310, 50, 13);
                PoultryFarm p6 = new PoultryFarm("Страуси", 50, 500, 20, 200);
                PoultryFarm p7 = new PoultryFarm("Індики", 12, 160, 10, 40);
                PoultryFarm p8 = new PoultryFarm("Гуси", 10, 100, 18, 39);
                PoultryFarm p9 = new PoultryFarm("Фазани", 11, 200, 6, 15);
                PoultryFarm p10 = new PoultryFarm("Куріпка", 8, 220, 23, 11);
                PoultryFarm[] pn = new PoultryFarm[10];
                pn[0] = p1;
                pn[1] = p2;
                pn[2] = p3;
                pn[3] = p4;
                pn[4] = p5;
                pn[5] = p6;
                pn[6] = p7;
                pn[7] = p8;
                pn[8] = p9;
                pn[9] = p10;
            
            

        }
        public IEnumerator GetEnumerator()
        {
            Array.Sort(container);
            return container.GetEnumerator();
        }
       
    }



    class Program
    {
       static void Main(string[] args)
       {
            PoultryFarm p1 = new PoultryFarm("Курки", 5, 130, 20, 22);
            PoultryFarm p2 = new PoultryFarm("Качки", 7, 150, 20, 28);
            PoultryFarm p3 = new PoultryFarm("Перепілки", 2, 300, 13, 10);
            PoultryFarm p4 = new PoultryFarm("Курчата", 0.2, 330, 100, 8);
            PoultryFarm p5 = new PoultryFarm("Голуби", 1, 310, 50, 13);
            PoultryFarm p6 = new PoultryFarm("Страуси", 50, 500, 20, 200);
            PoultryFarm p7 = new PoultryFarm("Індики", 12, 160, 10, 40);
            PoultryFarm p8 = new PoultryFarm("Гуси", 10, 100, 18, 39);
            PoultryFarm p9 = new PoultryFarm("Фазани", 11, 200, 6, 15);
            PoultryFarm p10 = new PoultryFarm("Куріпка", 8, 220, 23, 11);
            PoultryFarm[] pn = new PoultryFarm[10];
            pn[0] = p1;
            pn[1] = p2;
            pn[2] = p3;
            pn[3] = p4;
            pn[4] = p5;
            pn[5] = p6;
            pn[6] = p7;
            pn[7] = p8;
            pn[8] = p9;
            pn[9] = p10;
            Array.Sort(pn);

            Console.WriteLine("\t\t\tПорівняння порід птахів за вагою\n{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", "Тварини", "Вага", "Ціна", "Кількість", "Зріст");
            foreach (PoultryFarm elem in pn) elem.Info();
            Console.WriteLine("\n\t\t\tСортувати за ціною м’яса за 1 кг");
            Array.Sort(pn, new PoultryFarm.SortByCena());
            foreach (PoultryFarm elem in pn) elem.Info();

            int size = 10;
            Chiken chic = new Chiken(size);

            Console.WriteLine("\t\t\tПорівняння порід птахів за вагою");
            foreach (Chiken chics in chic)
            {
                Console.WriteLine("{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", chic.name, chic.weight, chic.cena, chic.number, chic.height);
            }





       }
    }
}
