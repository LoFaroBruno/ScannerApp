﻿using System;
using ScannerAControls;

namespace ScannerApp
{
    static class ScannerAapp
    {
        public static void TestScannerA()
        {
            ModeloA scanner = new ModeloA();
            scanner.DestinationDirectory = @"C:\Users\D78650\Scans";
            Console.WriteLine(scanner.GetStatus());
            Console.WriteLine(scanner.Scan(Utils.Utils.ImageFormat.JPG, Utils.Utils.ImageResolution.DPI_300));
            foreach (string scan in scanner.MultiScan(2, Utils.Utils.ImageFormat.JPG, Utils.Utils.ImageResolution.DPI_300))
            {
                Console.WriteLine(scan);
            }
        }
    }
}
