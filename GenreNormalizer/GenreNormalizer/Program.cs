using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GenreNormalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mStrIn = new FileStream(@"C:\Users\T\Desktop\data\tags.dat", FileMode.Open))
            using (var reader = new StreamReader(mStrIn))
            using (var mStrOut = new FileStream(@"tags.csv", FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(mStrOut))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var c = line.Split(new string[] { "::" }, StringSplitOptions.None);

                    if (c[1] != "8606")
                    {
                        writer.WriteLine("{0}, {1}, '{2}'", c[0], c[1], c[2].Replace("'", "''"));
                    }
                }
            }
        }
    }
}