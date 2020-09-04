using System;
using System.Collections.Generic;
using System.IO;

namespace PA1
{
    public class Postfile
    {//class for handling post related files
        public static List<Post> GetPosts()
        {
            List<Post> myPosts = new List<Post>();
            StreamReader inFile = null;
            //try catch error handling
            try
            {
                inFile = new StreamReader("posts.txt"); 
            }
            catch(FileNotFoundException e) //create an exception variable that we expect to be the error for the catch
            {
                Console.WriteLine("Something went wrong... returning a blank list 0}", e);
                return myPosts;
            }
            string line = inFile.ReadLine(); //reading in the data from posts.txt and putting it into variable line

            while(line!=null) //runs as long as there is still data in the text file
            {
                string[] temp = line.Split("#"); //read data in and split it into temp string array
                myPosts.Add(new Post(){id = int.Parse(temp[0]), text = temp[1], dateTime = DateTime.Parse(temp[2])});
                line = inFile.ReadLine(); //update read
            }   

            inFile.Close();
            return myPosts;
        }

        public static List<Post> AddPosts()
        {
            Console.Clear();
            List<Post> myPosts = new List<Post>();
           
            StreamReader inFile = null;
            //try catch error handling
            try
            {
                inFile = new StreamReader("posts.txt"); 
            }
            catch(FileNotFoundException e) //create an exception variable that we expect to be the error for the catch
            {
                Console.WriteLine("Something went wrong... returning a blank list 0}", e);
                return myPosts;
            }
            string line = inFile.ReadLine(); //reading in the data from posts.txt and putting it into variable line

            if(line != null)
            {
                while(line!=null) //runs as long as there is still data in the text file
            {
                string[] temp = line.Split("#"); //read data in and split it into temp string array
                //DateTime dateTime = DateTime.Parse(temp[2]);
                myPosts.Add(new Post(){id = int.Parse(temp[0]), text = temp[1], dateTime = DateTime.Parse(temp[2])});
                line = inFile.ReadLine(); //update read
            }
            }
            
            Console.WriteLine("You have chosen to add a post. Please type the post below!");
            string newPost = Console.ReadLine();
            myPosts.Add(new Post() {id = myPosts.Count + 1, text = newPost, dateTime = DateTime.Now});   
            inFile.Close();
            SaveAllPosts(myPosts);
            return myPosts;
        }

        public static List<Post> DeletePosts()
        {
            List<Post> myPosts = new List<Post>();
           
            StreamReader inFile = null;
            //try catch error handling
            try
            {
                inFile = new StreamReader("posts.txt"); 
            }
            catch(FileNotFoundException e) //create an exception variable that we expect to be the error for the catch
            {
                Console.WriteLine("Something went wrong... returning a blank list 0}", e);
                return myPosts;
            }
            string line = inFile.ReadLine(); //reading in the data from posts.txt and putting it into variable line

            while(line!=null) //runs as long as there is still data in the text file
            {
                string[] temp = line.Split("#"); //read data in and split it into temp string array
                //DateTime dateTime = DateTime.Parse(temp[2]);
                myPosts.Add(new Post(){id = int.Parse(temp[0]), text = temp[1], dateTime = DateTime.Parse(temp[2])});
                line = inFile.ReadLine(); //update read
            }

            Console.WriteLine("What is the ID of the post you would like to delete?");
            Postutils.PrintAllPostsDelete(myPosts);
            int deleteId = int.Parse(Console.ReadLine());
            myPosts.RemoveAt(deleteId - 1); //-1 so we delete the index of the post the user wants and not the index that is one less in the list
            inFile.Close();
            SaveAllPosts(myPosts);
            return myPosts;

        }

        public static void SaveAllPosts(List<Post> myPosts)
        {
            myPosts.Sort(); //sort posts before saving back to file
            TextWriter tw = new StreamWriter("posts.txt");
            foreach (Post post in myPosts)
            {
                tw.WriteLine(post.ToFile());
            }
            tw.Close();
        }

    }
}