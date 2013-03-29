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
            var genres = new string[20];
            genres[1] = "Action";
            genres[2] = "Adventure";
            genres[3] = "Animation";
            genres[4] = "Children";
            genres[5] = "Comedy";
            genres[6] = "Crime";
            genres[7] = "Documentary";
            genres[8] = "Drama";
            genres[9] = "Fantasy";
            genres[10] = "Film-Noir";
            genres[11] = "Horror";
            genres[12] = "Musical";
            genres[13] = "Mystery";
            genres[14] = "Romance";
            genres[15] = "Sci-Fi";
            genres[16] = "Thriller";
            genres[17] = "War";
            genres[18] = "Western";
            genres[19] = "IMAX";

            using (var mStrIn = new FileStream(@"C:\Users\T\Desktop\ml-10m\ml-10M100K\movies.dat", FileMode.Open))
            using (var reader = new StreamReader(mStrIn))
            using (var mStrOut = new FileStream(@"movie_genre.dat", FileMode.OpenOrCreate))
            using (var genreWriter = new StreamWriter(mStrOut))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var c = line.Split(new string[] { "::" }, StringSplitOptions.None);
                    var g = c[2].Split("|".ToCharArray(), StringSplitOptions.None);
                    var movieId = c[0];

                    for (int i = 0; i < g.Length; i++)
                    {
                        var genreId = Array.IndexOf(genres, g[i]);
                        genreWriter.WriteLine("{0}::{1}", movieId, genreId);
                    }
                }
            }
        }
    }
}
