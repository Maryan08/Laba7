using System;
using System.Collections;
using System.IO;

namespace OOP_Lab_7._2
{

    class Program
    {
        static void Main(string[] args)
        {
            Key.KKEY();
        }
    }
    class Shedule : IComparable
    { 
        public int Number;
        public DateTime Data;
        public string Subject;
        public string Surname;
        public string Form;
        public Shedule(int number,DateTime date,string subject,string sur,string form)
        {
            Surname = sur;
           
            Number = number;
            Data = date;
            Subject = subject;
            Form = form;
        }
        public int CompareTo(object obj)
        {
            Shedule p = (Shedule)obj;
            if (this.Data > p.Data) return 1;
            if (this.Data < p.Data) return -1;
            return 0;
        }
        public void Data1(Shedule[] a)
        {
            Console.WriteLine("\nСортування за датою:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "№", "Дата", "Ім'я", "Предмет", "Прізвище", "Форма");
            
         
            Array.Sort(a);
            foreach (Shedule elem in a) elem.Inf();
        }
        public void Inf()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ",Number,Data.ToShortDateString(),Subject, Surname, Form);
        }
        public class SortByDate : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Shedule p1 = (Shedule)ob1;
                Shedule p2 = (Shedule)ob2;
                if (p1.Data > p2.Data) return 1;
                if (p1.Data < p2.Data) return -1;
                return 0;
            }
        }
        public void One(Shedule[] a)
        {
            Console.WriteLine("\nСортування за датою:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "№", "Дата", "Ім'я", "Предмет", "Прізвище", "Форма");
            Array.Sort(a, new Shedule.SortByDate());
            foreach (Shedule elem in a) elem.Info1();
        }
        public void Info1()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", Number, Data.ToShortDateString(), Subject, Surname, Form);
        }

        public class SortByNumber : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Shedule p1 = (Shedule)ob1;
                Shedule p2 = (Shedule)ob2;
                if (p1.Number > p2.Number) return 1;
                if (p1.Number < p2.Number) return -1;
                return 0;
            }
        }
        public void Two(Shedule[] a)
        {
            Console.WriteLine("\nСортування за номером:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "№", "Дата", "Ім'я", "Предмет", "Прізвище", "Форма");
            Array.Sort(a, new Shedule.SortByNumber());
            foreach (Shedule elem in a) elem.Info();
        }
        public void Info()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", Number, Data.ToShortDateString(), Subject, Surname, Form);
        }
       
        public void Add()
        {
            Console.WriteLine("Write data:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Key
    {
        public static void KKEY()
        {
            FileStream file1 = File.OpenRead("text.txt");
            byte[] array = new byte[file1.Length];
            file1.Read(array, 0, array.Length);
            string textfromfile = System.Text.Encoding.Default.GetString(array);
            string[] s = textfromfile.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            file1.Close();
            Shedule[] a = new Shedule[s.Length / 5];
            int c = 0;
            while (a[c] != null)
            {
                ++c;
            }
            for (int i = 0; i < s.Length; i += 5)
            {
                a[c + i / 5] = new Shedule(int.Parse(s[i]), DateTime.Parse(s[i + 1]), s[i + 2], s[i + 3], s[i + 4]);
            }
            bool[] delete = new bool[100];
            Console.WriteLine("Add note: A");
            Console.WriteLine("Edit note: E");
            Console.WriteLine("Remove note: R");
            Console.WriteLine("Show notes: Enter");
            Console.WriteLine("Sort by date: N");
            Console.WriteLine("Sort by number: D");
            Console.WriteLine("Sort by date: S");
            Console.WriteLine("Exit: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    Key.Edit(a);
                    break;

                case ConsoleKey.N:
                    a[0].One(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.D:
                    a[0].Two(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.S:
                    a[0].Data1(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.Enter:
                    Key.Show(a);
                    break;

                case ConsoleKey.A:
                    Key.Add(a, c);
                    break;

                case ConsoleKey.R:
                    Key.Remove(a, delete);
                    break;

                case ConsoleKey.Escape:
                    break;
            }

        }
        public static void Show(Shedule[] a)
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "№", "Дата", "Предмет", "Прізвище", "Форма");

            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);
                }
            }
            Key.KKEY();
        }
        public static void Add(Shedule[] a, int c)
        {
            Console.WriteLine("\nWrite number:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Key.Parse(elements, true, a, c);
            Key.KKEY();
        }

        private static void Save(Shedule m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);

           
           
            save.WriteLine(m.Number);
            save.WriteLine(m.Data);
            save.WriteLine(m.Subject);
            save.WriteLine(m.Surname);
            save.WriteLine(m.Form);
         
            save.Close();
        }

        public static void Parse(string[] elements, bool save, Shedule[] a, int counter)
        {
            for (int i = 0; i < elements.Length; i += 5)
            {
                a[counter + i / 5] = new Shedule(int.Parse(elements[i]), DateTime.Parse(elements[i + 1]), elements[i + 2], elements[i + 3], elements[i + 4]);
                if (save)
                {
                    Save(a[counter + i / 5]);
                }
            }
        }
        public static void Remove(Shedule[] a, bool[] delete)
        {
            Console.Write("\nSubject: ");

            string name = Console.ReadLine();

            bool[] write = new bool[a.Length];
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    if (a[i].Subject == name)
                    {
                        Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);

                        Console.WriteLine("\nDELETE? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {
                            a[i] = null;
                            delete[i] = true;
                            Key.Show(a);
                        }
                        else
                        {
                            delete[i] = false;
                        }
                    }
                }
            }
            Key.KKEY();
        }
        public static void Edit(Shedule[] a)
        {
            Console.WriteLine("\nWhat do you want to edit?(Number, Date, Subgect, Surname, Form)");
            string what = Console.ReadLine();
            switch (what)
            {
                case "Surname":
                    Console.WriteLine("What surname: ");
                    string name1 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Surname == name1)
                            {
                                Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);

                                Console.WriteLine("New surname: ");

                                string str = Console.ReadLine();

                                a[i].Surname = str;

                                Key.Show(a);
                            }
                        }
                    }
                    break;

                case "Date":
                    Console.WriteLine("What subject: ");
                    string name2 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Subject == name2)
                            {
                                Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);

                                Console.WriteLine("New date: ");
                                string str = Console.ReadLine();
                                a[i].Data =DateTime.Parse(str);
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "Subject":
                    Console.WriteLine("What subject: ");
                    string name3 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Subject == name3)
                            {
                                Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);
                                Console.WriteLine("New subject: ");
                                string str = Console.ReadLine();
                                a[i].Subject = str;
                                Key.Show(a);
                            }
                        }

                    }
                    break;
                
                case "Number":
                    Console.WriteLine("What subject: ");
                    string name5 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Subject == name5)
                            {
                                Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);
                                Console.WriteLine("New number: ");
                                int str = int.Parse(Console.ReadLine());
                                a[i].Number = str;
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "Form":
                    Console.WriteLine("What form: ");
                    string name6 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Subject == name6)
                            {
                                Console.WriteLine("{0,-15} {1,-10}\t {2,-10} {3,-20} {4,-20}", a[i].Number, a[i].Data.ToShortDateString(), a[i].Subject, a[i].Surname, a[i].Form);
                                Console.WriteLine("New login: ");
                                string str = Console.ReadLine();
                                a[i].Form = str;
                                Key.Show(a);
                            }
                        }

                    }
                    break;
            }
            Key.KKEY();
        }
    }
}
