using System;

namespace Lab3Variant6
{
    public interface IDisplayable
    {
        void PrintInfo();
    }
    public class Child1 : IDisplayable, IComparable<Child1>
    {
        public double Income { get; set; }     
        public int TaxRate { get; set; } = 18;   

        public double CalculateTax()
        {
            return Income * (TaxRate / 100.0);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Доход={Income,-6} ставка={TaxRate} Налог={CalculateTax():F2}");
        }
        public int CompareTo(Child1 other)
        {
            if (other == null) return 1;
            return Income.CompareTo(other.Income);
        }
    }

    public class Child2 : IDisplayable, IComparable<Child2>
    {
        public double Revenue { get; set; }           
        public double Cost { get; set; }               
        public double ExtraExpenses { get; set; }      
        public int TaxRate { get; set; } = 20;         

        public double CalculateTax()
        {
            double profit = Revenue - Cost - ExtraExpenses;
            return profit > 0 ? profit * (TaxRate / 100.0) : 0;
        }

     
        public void PrintInfo()
        {
            Console.WriteLine($"Выручка={Revenue,-6} себестоимость={Cost,-4} доп расходы={ExtraExpenses,-5} ставка={TaxRate} Налог={CalculateTax():F1}");
        }

     
        public int CompareTo(Child2 other)
        {
            if (other == null) return 1;
            return CalculateTax().CompareTo(other.CalculateTax());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();

            Console.WriteLine("-----Физическое лицо-----");

            Child1[] physicalPersons = new Child1[3];
            for (int i = 0; i < physicalPersons.Length; i++)
            {
                physicalPersons[i] = new Child1
                {
                    Income = rnd.Next(20000, 50000)
                };
                physicalPersons[i].PrintInfo();
            }

            Array.Sort(physicalPersons);

            Console.WriteLine("-----сортировка по доходу-------");
            foreach (var person in physicalPersons)
            {
                person.PrintInfo();
            }

            Console.WriteLine();

            Console.WriteLine("-----Юридическое лицо-----");
            Child2[] legalEntities = new Child2[3];
            for (int i = 0; i < legalEntities.Length; i++)
            {
                legalEntities[i] = new Child2
                {
                    Revenue = rnd.Next(250000, 500000),
                    Cost = rnd.Next(5000, 8000),
                    ExtraExpenses = rnd.Next(10000, 20000)
                };
                legalEntities[i].PrintInfo();
            }
            Array.Sort(legalEntities);

            Console.WriteLine("-----сортировка по налогу-------");
            foreach (var entity in legalEntities)
            {
                entity.PrintInfo();
            }

            Console.ReadLine(); 
        }
    }
}