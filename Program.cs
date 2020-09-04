using System;
using System.Collections.Generic;
using System.IO;

namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();   
        }

        public static void ShowAllPosts()
        {
            List<Post> myPosts = Postfile.GetPosts();
            myPosts.Sort();
            Postutils.PrintAllPosts(myPosts);
            Console.WriteLine("");
            Console.WriteLine("Would you like to return to the menu? 1 for yes.");
            int userChoice = int.Parse(Console.ReadLine());
            if(userChoice == 1)
            {
                Console.Clear();
                Menu();
            }

        }

        public static void Menu()
        {
            Console.WriteLine("Welcome to the backend of BigAlGoesSocial.");
            Console.WriteLine("Press 1 to show all posts");
            Console.WriteLine("Press 2 to add a post");
            Console.WriteLine("Press 3 to delete a post by ID");
            int menuChoice = int.Parse(Console.ReadLine());

            if(menuChoice == 1)
            {
                ShowAllPosts();
            }
            if(menuChoice == 2)
            {
                Postfile.AddPosts();
                menuChoice = 0;
                Console.Clear();
                Console.WriteLine("Post Added!");
                Menu();
            }
            if(menuChoice == 3)
            {
                Postfile.DeletePosts();
                menuChoice = 0;
                Console.Clear();
                Menu();
            }                  
        }
    }
}
