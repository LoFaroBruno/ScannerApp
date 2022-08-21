using System;

namespace ScannerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select: " +
                                "\n1- Scanner A." +
                                "\n2- Scanner B.");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ScannerAapp.TestScannerA();
                        break;
                    case 2:
                        ScannerBapp.TestScannerB();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}