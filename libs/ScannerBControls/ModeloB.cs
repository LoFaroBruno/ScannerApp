using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ScannerBControls
{
    public class ModeloB
    {
        private bool IsActive = false;
        private enum ImageResolution { DPI_200, DPI_300 }
        public string OriginDirectory { get; set; } = @"..\..\images\Img_Cheques\300_DPI\";

        public void Initialize()
        {
            IsActive = true;
            Console.WriteLine("Intializing Scanner");
        }

        public bool TestScan()
        {
            if (!IsActive)
                return false;
            return true;
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
            byte[] imageArray;
            try
            {
                CMC7 = GenerateCMC7();
                imageArray = ImageToByteArray(GetRandomImage());
            }
            catch (Exception e)
            {
                throw new Exception("Failed scan", e);
            }
            return imageArray;
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