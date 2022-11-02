using System;
using System.Collections.Generic;
using System.Text;

namespace TSPLibrary
{
    class Book
    {
        public String authorID { get; set; }
        public String Title { get; set; }
        public String ISBN { get; set; }
        public String Genre { get; set; }
        public String PubYear { get; set; }

        public Book(String authorID,String Title, String ISBN, String Genre, String PubYear)
        {
            this.authorID = authorID;
            this.Title = Title;
            this.ISBN = ISBN;
            this.Genre = Genre;
            this.PubYear = PubYear;
        }
    }
}
