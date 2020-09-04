using System;
using System.Collections.Generic;

namespace PA1
{
    public class Postutils
    {
        public static void PrintAllPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            { //use foreach loop to read through a list and don't have to keep up with a count
               Console.WriteLine(post.ToString());
            }
        }

        public static void PrintAllPostsDelete(List<Post> posts)
        {
            foreach(Post post in posts)
            { //use foreach loop to read through a list and don't have to keep up with a count
               Console.WriteLine(post.DeleteToString());
            }
        }
    }
}