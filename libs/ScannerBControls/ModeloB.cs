using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;

namespace ScannerBControls
{
    public class ModeloB
    {
        private bool IsActive = false;
        public Utils.Utils.ImageResolution imageResolution;
        public string DestinationDirectory { get; set; } = @"C:\Users\D78650\Documents\Scans";
        public string OriginDirectory { get; set; } = @"..\..\images\Img_Cheques\300_DPI\";
        public void Initialize()
        {
            IsActive = true;
            Console.WriteLine("Intializing Scanner");
        }

        public bool TestScan()
        {
            int statusNumber = new Random().Next(0, 2);
            if (statusNumber == 1)
            {
                IsActive = false;
                return IsActive;
            }
            IsActive = true;
            return IsActive;
        }

        public void Close()
        {
            IsActive = false;
            Console.WriteLine("Closing Scanner");
        }

        public byte[] Scan(out string CMC7)
        {
            if (!this.IsActive)
                throw new Exception("ScannerNotInit");
            CMC7 = GenerateCMC7();
            byte[] data = ImageToByteArray(GetRandomImage());
            System.Drawing.Image newImage = Image.FromStream(new MemoryStream(data));
            string destinationFile = DestinationDirectory + '\\' + CMC7 + ".png";
            try
            {
                newImage.Save(destinationFile, ImageFormat.Png);
            }
            catch(Exception e)
            {
                throw new Exception("Scan failure. ",e);
            }
            return data;
        }

        private string GenerateCMC7()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 29)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private Image GetRandomImage()
        {
            Random rand = new Random();
            string[] files = Directory.GetFiles(OriginDirectory, "*.jpg");
            string randomFile = files[rand.Next(files.Length)];
            return Image.FromFile(randomFile);
        }
    }
}