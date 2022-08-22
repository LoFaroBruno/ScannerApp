﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ScannerBControls
{
    public class ModeloB
    {
        private bool IsActive = false;
        public Utils.Utils.ImageResolution imageResolution;
        public string OriginDirectory { get; set; } = @"..\..\images\Img_Cheques\300_DPI\";
        public string DestinationDirectory { get; set; } = @"./";
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
            return ImageToByteArray(GetRandomImage());
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