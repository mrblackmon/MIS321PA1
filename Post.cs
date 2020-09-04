using System;
namespace PA1
{
    public class Post : IComparable<Post>
    {
        public int id{get;set;}

        public string text{get;set;}

        public DateTime dateTime{get;set;} 

        public int CompareTo(Post temp)
        {
            return this.dateTime.CompareTo(temp.dateTime);
        }

        public override string ToString() //use override function because we have to override the standard tostring
        {
            return this.text + "  " + this.dateTime;
        }

        public string DeleteToString() //use override function because we have to override the standard tostring
        {
            return this.id + " " + this.text + "  " + this.dateTime;
        }


        public string ToFile()
        {
            return id + "#" + text + "#" + dateTime;
        }
    }
}