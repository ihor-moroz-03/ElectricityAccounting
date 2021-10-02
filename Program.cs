using System;

namespace ElectricityAccounting
{
    class Program
    {
        static void Main()
        {
            var report = new QuarterReport(@"C:\Users\ihorm\source\repos\ElectricityAccounting\QuarterReport.txt");
            Console.WriteLine(report);
            Console.WriteLine($"{report.GetOwnerWithHighestDebt()} has highest debt");
            if (report.GetFlatWithZeroUsage(out uint zeroUsage))
                Console.WriteLine($"Flat #{zeroUsage} didn't use electricity at all");
            else Console.WriteLine("All flats have been using electricity");
            Console.Read();
        }
    }
}
