using System;
using System.Collections.Generic;

namespace Savage_Lab10_MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to your Movie List.");
            var Aladdin = new Movie("Aladdin", "Animated");
            var JennifersBody = new Movie("Jennifers Body", "Horror");
            var Signs = new Movie("Signs", "Sci-fi");
            var ShesTheMan = new Movie("She's The Man", "Comedy");
            var SpongebobSquarePants = new Movie("The Spongebob Squarepant Movie", "Animated");
            var FreddyVsJason = new Movie("Freddy Vs. Jason", "Horror");
            var TheHeat = new Movie("The Heat", "Comedy");
            var MenInBlack = new Movie("Men In Black", "Sci-fi");
            var PitchPerfect = new Movie("Pitch Perfect", "Comedy");
            var ABugsLife = new Movie("A Bugs Life", "Animated");


            List<Movie> movies = new List<Movie>();
            movies.Add(Aladdin);
            movies.Add(JennifersBody);
            movies.Add(Signs);
            movies.Add(ShesTheMan);
            movies.Add(SpongebobSquarePants);
            movies.Add(FreddyVsJason);
            movies.Add(TheHeat);
            movies.Add(MenInBlack);
            movies.Add(PitchPerfect);

            movies.Add(ABugsLife);

           /* foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Title} is the name of the movie and the genre is {movie.Genre}!");
            }*/

            var askUserTitleOrGenre = AskUserTitleOrGenre();

            Console.WriteLine(askUserTitleOrGenre);
            
            foreach (var input in movies)
            {
                Console.WriteLine($"{input.Title}");
            }
  
        }

        public static string AskUserTitleOrGenre()
        {
            while (true)
            {
                Console.WriteLine("Please search by movie TITLE or movie GENRE:");
                Console.WriteLine("[1]TITLE");
                Console.WriteLine("[2]GENRE");
                if (uint.TryParse(Console.ReadLine(), out uint userSelection) && userSelection < 3)
                {
                    if (userSelection == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please enter the title of the movie you would like to search.");
                            var usersTitleName = Console.ReadLine();
                            if(usersTitleName.Length < 1)
                            {
                                Console.WriteLine("Not a valid movie title. Please try again.");
                            }
                            else
                            {
                                return usersTitleName;
                            }
                        }
                    }
                    else if (userSelection == 2)
                    {
                        Console.WriteLine("Please enter the genre to search for a movie.");
                        var usersGenreName = Console.ReadLine();
                        if (usersGenreName.Length < 1)
                        {
                            Console.WriteLine("Not a valid movie genre. Please try again.");
                        }
                        else
                        {
                            return usersGenreName;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                }
            }
        }
    }

    public class Movie
    {
        public Movie(string movieTitle, string movieGenre)
        {
            Title = movieTitle;
            Genre = movieGenre;

        }
        public string Title { get; set; }

        public string Genre { get; set; }

    }
}
