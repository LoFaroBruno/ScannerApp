using ScannerAControls;
using System;
using Iscanner;

namespace ScannerApp
{
    public class WrapperScannerA : IScanner
    {
        private ModeloA Scanner;
        public WrapperScannerA(ModeloA scanner)
        {
            Scanner = scanner;
        }
        void IScanner.Digitalizar()
        {
            Console.WriteLine(Scanner.Scan(Utils.Utils.ImageFormat.JPG, Utils.Utils.ImageResolution.DPI_300));
            foreach (string scan in Scanner.MultiScan(2, Utils.Utils.ImageFormat.JPG, Utils.Utils.ImageResolution.DPI_300))
            {
                Console.WriteLine(scan);
            }
        }
        void IScanner.Detener()
        {
            Scanner.Stop();
        }
        bool IScanner.Test()
        {
            Console.WriteLine(Scanner.GetStatus());
            return Scanner.status;
        }
        void IScanner.Init()
        {
            Scanner.Init();
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