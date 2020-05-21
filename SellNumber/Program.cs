using System;

namespace SellNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Number : ");
            string number = Console.ReadLine();
            SellNumberCls sellNumberCls = new SellNumberCls(number);
            Console.WriteLine();
            Console.WriteLine("Number : {0} " , sellNumberCls.GetSpell());
            Console.ReadKey();
        }

      
    }
}
