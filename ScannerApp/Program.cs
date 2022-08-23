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
                        ScannerAControls.ModeloA modeloA = new ScannerAControls.ModeloA();
                        WrapperScannerA scannerA = new WrapperScannerA(modeloA)
                        {
                            Resolucion = Utils.Utils.ImageResolution.DPI_200,
                            DirDestino = @"C:\Users\D78650\Desktop\scans",
                        };
                        ScannerTest.Test(scannerA);
                        break;
                    case 2:
                        ScannerBControls.ModeloB modeloB = new ScannerBControls.ModeloB();
                        WrapperScannerB scannerB = new WrapperScannerB(modeloB)
                        {
                            Resolucion = Utils.Utils.ImageResolution.DPI_200,
                            DirDestino = @"C:\Users\D78650\Desktop\scans",
                        };
                        ScannerTest.Test(scannerB);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.StackTrace}{e?.InnerException}");
            }
            Console.ReadKey();
        }
    }
}