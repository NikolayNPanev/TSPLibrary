using System;
using System.Collections.Generic;
using System.Text;

namespace TSPLibrary
{
    class Rent
    {
        public Visitor visitor { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Book book { get; set; }

        public Rent(Visitor visitor, DateTime startDate, DateTime endDate, Book book)
        {
            this.visitor = visitor;
            this.startDate = startDate;
            this.endDate = endDate;
            this.book = book;
        }
    }
}
