using System;

namespace ElectricityAccounting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new QuarterReport(@"C:\Users\ihorm\source\repos\ElectricityAccounting\QuarterReport.txt"));
            Console.Read();
        }
    }
}
