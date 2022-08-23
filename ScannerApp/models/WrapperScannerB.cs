﻿using System;
using ScannerBControls;
using Iscanner;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ScannerApp
{
    internal class WrapperScannerB : IScanner
    {
        private ModeloB Scanner;
        public WrapperScannerB(ModeloB scanner)
        {
            Scanner = scanner;
        }
        void IScanner.Digitalizar()
        {
            string CMC7;
            Scanner.Scan(out CMC7);
            Console.WriteLine($"CMC7: {CMC7}");
        }
        void IScanner.Detener()
        {
            Scanner.Close();
        }
        bool IScanner.Test()
        {
            return Scanner.TestScan();
        }
        void IScanner.Init()
        {
            Scanner.Initialize();
        }
        public Utils.Utils.ImageResolution Resolucion
        {
            get { return Scanner.imageResolution; }
            set { Scanner.imageResolution = value; }
        }
        public string DirDestino
        {
            get { return Scanner.DestinationDirectory; }
            set { Scanner.DestinationDirectory = value; }
        }
    }
}