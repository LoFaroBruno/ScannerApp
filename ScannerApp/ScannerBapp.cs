using System;
using ScannerBControls;

namespace ScannerApp
{
    static class ScannerBapp
    {
        public static void TestScannerB()
        {
            ModeloB scanner = new ModeloB();
            string CMC7;
            try
            {
                scanner.Scan(out CMC7);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (!scanner.TestScan())
                scanner.Initialize();
            byte[] imageBytes = scanner.Scan(out CMC7);
            Console.WriteLine(imageBytes.Length);
            scanner.Close();
        }
    }
}
