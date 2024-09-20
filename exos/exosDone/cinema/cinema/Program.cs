using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Movie> frenchMovies = new List<Movie>() {
            new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
            new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
            new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
            new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
            new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
            };
            //var
            var notComediDrame = frenchMovies.Where(f => f.Genre != "Comédie").Where(f => f.Genre != "Drame").ToList();
            var film2000 = frenchMovies.Where(f => f.Year < 2000).ToList();
            var notDblFrench = frenchMovies.Where(f => !f.LanguageOptions.Contains("Français")).ToList();
            var filmNetflix = frenchMovies.Where(f => !f.StreamingPlatforms.Contains("Netflix")).ToList();

            foreach (var f in notComediDrame)
            {
                Console.WriteLine(f.Title);
            }


            var filteredMovies = frenchMovies
            .Where(f => f.Genre != "Comédie" && f.Genre != "Drame"
            && f.Year < 2000
            && !f.LanguageOptions.Contains("Français")
            && !f.StreamingPlatforms.Contains("Netflix"))
            .ToList();



            Console.ReadLine();
        }



    }

    internal class Movie
    {
        public Movie()
        {
        }

        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int Year { get; set; }
        public string[] LanguageOptions { get; set; }
        public string[] StreamingPlatforms { get; set; }
    }
}
