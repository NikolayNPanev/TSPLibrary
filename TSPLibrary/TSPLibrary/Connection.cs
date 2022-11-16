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

        public void InsertVisitor(Visitor visitor)
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

        public void RentBook(Rent rental)
        {

            try
            {
                command.CommandText = "INSERT INTO Rent(VisitorBarcode,StartDate,EndDate,BookID) values ('" + rental.visitorBarcode + "','" + rental.startDate.ToString() + "','" + rental.endDate.ToString() + "','" + rental.BookID + "');";
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

        public Rent[] GetVisitorRentals(Visitor visitor)
        {
            Rent[] returnRent = new Rent[1000];
            try
            {
                
                command.CommandText = "SELECT BookID FROM Rent WHERE VisitorBarcode = '" + visitor.barcode + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> result = new List<String>();
                List<String> BookIDs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                        foreach(String res in result) {
                            BookIDs.Add(res);
                        }
                    }
                    connect.Close();
                }


                command.CommandText = "SELECT VisitorBarcode FROM Rent WHERE VisitorBarcode = '" + visitor.barcode + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Barcodes = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                        foreach (String res in result)
                        {
                            Barcodes.Add(res);
                        }
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT StartDate FROM Rent WHERE VisitorBarcode = '" + visitor.barcode + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> StartDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("MM/dd/yyyy"));
                        foreach (String res in result)
                        {
                            StartDates.Add(res);
                        }
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT EndDate FROM Rent WHERE VisitorBarcode = '" + visitor.barcode + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> EndDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("MM/dd/yyyy"));
                        foreach (String res in result)
                        {
                            EndDates.Add(res);
                        }
                    }
                    connect.Close();
                }

                for (int i = 0; i < result.Count; i++) {
                    String date = StartDates[i];
                    returnRent[i] = new Rent(Barcodes[i], DateTime.Parse(StartDates[i]), DateTime.Parse(EndDates[i]), BookIDs[i]);

                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
            connect.Close();
            return returnRent;

        }



    }
    }
