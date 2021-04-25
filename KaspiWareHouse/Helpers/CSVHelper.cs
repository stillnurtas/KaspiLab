using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using KaspiWareHouse.Models.WareHouse;

namespace KaspiWareHouse.Helpers
{
    class CSVHelper
    {
        private static readonly string _folderpath = @"C:\Users\Nurtas\Desktop\KaspiLab-master\KaspiWareHouse\CSVFiles\";
        private static string FilePath { get; set; }

        public static void CreateCSV(BaseWareHouse wareHouse, string fileName)
        {
            FilePath = $"{_folderpath}{fileName}.csv";
            CheckForFolderExist();
            CheckForFileExist();
            using (StreamWriter writer = new StreamWriter(new FileStream(FilePath, FileMode.Open, FileAccess.Write)))
            {
                writer.WriteLine("Name, SKU, Description, Price, Quantity");
                wareHouse.ProductList.ForEach(pl => writer.WriteLine($"{pl.Name}, {pl.SKU}, {pl.Description}, {pl.Price}, {pl.Quantity}"));
            }
        }

        private static void CheckForFolderExist()
        {
            if (!Directory.Exists(_folderpath))
            {
                Directory.CreateDirectory(_folderpath);
            }
        }

        private static void CheckForFileExist()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Dispose();
            }
        }
    }
}
