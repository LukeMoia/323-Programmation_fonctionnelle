using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
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
                new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }};
            List<Movie> Filtermovies1 = frenchMovies.Where(p => p.Genre != "Comédie" && p.Genre != "Drame").ToList();
            List<Movie> Filtermovies2 = frenchMovies.Where(f => f.Rating < 7).ToList();
            List<Movie> Filtermovies3 = frenchMovies.Where(f => f.Year < 2000).ToList();
            List<Movie> Filtermovies4 = frenchMovies.Where(f => !f.LanguageOptions.Contains("Français")).ToList();
            List<Movie> Filtermovies5 = frenchMovies.Where(f => !f.StreamingPlatforms.Contains("Netflix")).ToList();
            List<Movie> FiltermoviesULTIME = frenchMovies.Where(p => p.Genre != "Comédie" && p.Genre != "Drame").Where(f => f.Rating < 7).Where(f => f.Year < 2000).Where(f => !f.LanguageOptions.Contains("Français")).Where(f => !f.StreamingPlatforms.Contains("Netflix")).ToList();

            List<string> tempname = new List<string>();

            List<Movie> MoviesUsersSelections = new List<Movie>();

            // valeur récuperer
            foreach (PropertyInfo property in frenchMovies[0].GetType().GetProperties())
            {
                foreach (var movie in frenchMovies)
                {
                    if (property.GetType() != Type.GetType(""))
                    {
                        if (!tempname.Contains(property.GetValue(movie).ToString()))
                        {
                            Console.WriteLine(property.GetValue(movie).ToString());
                            // tempname.Add(property.GetValue(movie));
                        }
                    }
                    else if ("System.String[]" == property.GetValue(movie).ToString()) // tableau
                    {
                        foreach (var v in)
                        {
                            if (!tempname.Contains(property.GetValue(movie)))
                            {
                                Console.WriteLine(property.GetValue(movie));
                                // tempname.Add(property.GetValue(movie));
                            }
                        }
                    }
                    else
                    {
                        if (!tempname.Contains(property.GetValue(movie)))
                        {
                            Console.WriteLine(property.GetValue(movie));
                            // tempname.Add(property.GetValue(movie));
                        }
                    }
                }
                tempname = new List<string>();
            }
            Console.ReadLine();
        }
    }

    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int Year { get; set; }
        public string[] LanguageOptions { get; set; }
        public string[] StreamingPlatforms { get; set; }
    }
}
