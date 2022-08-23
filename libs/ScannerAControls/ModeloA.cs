using System;
using System.IO;
using System.Linq;

namespace ScannerAControls
{
    public class ModeloA
    {
        public Utils.Utils.ImageFormat imageFormat;
        public Utils.Utils.ImageResolution imageResolution;
        public string DestinationDirectory { get; set; } = @"C:\Users\D78650\Documents\Scans";
        public string OriginDirectory { get; set; } = @"..\..\images\Img_Cheques";
        public bool status;
        string statusOk = "General Status OK \n Connection: OK \n Port check: OK " +
                        "\n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";
        string statusError = "General Status ERROR \n Connection: OK \n Port check: FAIL " +
                                "\n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";

        public string Scan(Utils.Utils.ImageFormat format, Utils.Utils.ImageResolution resolution = Utils.Utils.ImageResolution.DPI_300)
        {
            string CMC7 = generateCMC7();
            string file;
            try
            {
                file = SaveImage(format, resolution, CMC7);
            }
            catch (Exception e)
            {
                throw new Exception("Failed scan", e);
            }
            return file;
        }

        public string[] MultiScan(int quantity, Utils.Utils.ImageFormat format, Utils.Utils.ImageResolution resolution = Utils.Utils.ImageResolution.DPI_300)
        {
            if (quantity <= 0)
                throw new FormatException("Invalid quantity parameter.");
            string[] savedImages = new string[quantity];
            try
            {
                for (int i = 0; i < quantity; i++)
                    savedImages[i] = SaveImage(format, resolution, generateCMC7());
            }
            catch (Exception e)
            {
                throw new Exception("Failed scan", e);
            }
            return savedImages;
        }

        public void Stop()
        {
            Console.WriteLine("The scanner has stopped.");
        }

        private string generateCMC7()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 29)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string SaveImage(Utils.Utils.ImageFormat format, Utils.Utils.ImageResolution resolution, string CMC7)
        {
            string destinationFile = DestinationDirectory + '\\' + CMC7 + '.' + format.ToString();
            string sourceFile = getRandomImageName(resolution);
            File.Copy(sourceFile, destinationFile, true);
            return destinationFile;
        }

        private string getRandomImageName(Utils.Utils.ImageResolution resolution)
        {
            string ImagesDir = OriginDirectory;
            switch (resolution)
            {
                case Utils.Utils.ImageResolution.DPI_200:
                    ImagesDir += @"\200_DPI\";
                    break;
                case Utils.Utils.ImageResolution.DPI_300:
                    ImagesDir += @"\300_DPI\";
                    break;
                default:
                    break;
            }
            Random rand = new Random();
            string[] files;
            files = Directory.GetFiles(ImagesDir, "*.jpg");
            return files[rand.Next(files.Length)];
        }

        public string GetStatus()
        {
            int statusNumber = new Random().Next(0, 2);
            if (statusNumber == 1)
            {
                status = false;
                return statusError;
            }
            status = true;
            return statusOk;
        }

        public void Init()
        {
            Console.WriteLine("Initializing scanner.");
            Console.WriteLine(statusOk);
            status = true;
        }
    }
}