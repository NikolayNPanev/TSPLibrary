using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace TSPLibrary
{
    class Connection
    {
        OleDbConnection connect;
        OleDbCommand command;

        private void ConnectionTo()
        {
            connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\TSPLibrary\TSPLibrary\Database1.mdb");
            command = connect.CreateCommand();

        }

        public Connection()
        {
            ConnectionTo();
        }

        public void InsertAuthor(Author author)
        {
            try
            {
                command.CommandText = "INSERT INTO Author(_Author) values ('" + author.author + "');";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }

        public void InsertBook(Book book)
        {
            try
            {
                command.CommandText = "INSERT INTO Books(Author, ISBN, Title, Genre, PubYear) values ('" + book.authorID + "','" + book.ISBN + "','" + book.Title + "'," + book.Genre + "," + book.PubYear + ");";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }

        public void InsertGenre(Genre genre)
        {
            try
            {
                command.CommandText = "INSERT INTO Genre(Genre) values ('" + genre.genre + "');";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

            public void insertVisitor(Visitor visitor)
            {
                try
                {
                    command.CommandText = "INSERT INTO Visitors(FirstName,MiddleName,LastName,Barcode) values ('" + visitor.fname + "','" + visitor.mname + "','" + visitor.lname + "','" + visitor.barcode + "');";
                    command.CommandType = System.Data.CommandType.Text;
                    connect.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }

            }

        public void RentBook(Rent rental) {

            try
            {
                command.CommandText = "INSERT INTO Rent(VisitorBarcode,StartDate,EndDate,BookID) values ('" + rental.visitor.barcode + "','" + rental.startDate.ToString() + "','" + rental.endDate.ToString() + "','" + rental.book.ISBN + "');";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }



        }
    }
