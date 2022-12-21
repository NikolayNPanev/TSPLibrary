using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Book
    {
        public String ISBN { get; set; }
        public String Title { get; set; }
        public int authorID { get; set; }
        public String PubYear { get; set; }
        public String Genre{ get; set; }
      //  this.lightingsTableAdapter.Fill(this.databaseDataSet.Lightings);
        public Book(String ISBN, String Title, int authorID, String PubYear, String Genre)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.authorID = authorID;
            this.PubYear = PubYear;
            this.Genre = Genre;
          
        }
    }
}
