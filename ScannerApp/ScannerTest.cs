using System;

namespace ScannerApp
{
    static class ScannerTest
    {
        public static void Test(Iscanner.IScanner scanner)
        {
            if (!scanner.Test())
            {
                scanner.Init();
            }
            scanner.Digitalizar();
        }
    }
}
