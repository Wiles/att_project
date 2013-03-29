using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            var columns = new string[3];
            columns[0 ] = "id";
            columns[1 ] = "name";
            columns[2 ] = "genres";

            var counts = new double[3];
            double count = 0;

            using (var stream = new FileStream(@"C:\Users\T\Desktop\ml-10m\ml-10M100K\movies.dat", FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                string line = reader.ReadLine(); // skip first line
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    if (count % 1000 == 0)
                    {
                        Console.WriteLine(count);
                    }

                    var c = line.Split(new string[] { "::" }, StringSplitOptions.None);

                    for (int i = 0; i < 3; i++)
                    {
                        if (!string.IsNullOrEmpty(c[i]))
                        {
                            counts[i]++;
                        }
                    }
                }
            }

            var list = new List<Model>();

            for (int i = 0; i < 3; i++)
            {
                var m = new Model() { Index = i, Column = columns[i], Count = counts[i] };
                list.Add(m);
            }

            using (var stream = new FileStream("output.txt", FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            {
                foreach (var model in list.OrderByDescending(m => m.Count))
                {
                    Console.WriteLine("{0,-7}  {1,-10}   {2}", model.Index, model.Column, model.Count);
                    writer.WriteLine("{0,-7}  {1,-10}   {2}", model.Index, model.Column, model.Count);
                }
            }

            Console.ReadLine();
        }
    }

    class Model
    {
        public int Index { get; set; }

        public string Column { get; set; }

        public double Count { get; set; }
    }
}