using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace LibraryProject
{
    class Connection
    {
        ////////////////////
        ///              ///
        ///  CONNECTION  ///
        ///              ///
        ////////////////////
        OleDbConnection connect;
        OleDbCommand command;

        private void ConnectionTo()
        {
            connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Alexandra\source\repos\LibraryProject\Database1.mdb");
            command = connect.CreateCommand();
        }

        public Connection()
        {
            ConnectionTo();
        }

        ////////////////////
        ///              ///
        ///     AUTHOR   ///
        ///              ///
        ////////////////////
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

        ///////////////////////////
        ///                     ///
        ///  BOOK DB FUNCTIONS  ///
        ///                     ///
        ///////////////////////////

        public void InsertBook(Book book)
        {
            try
            {
                command.CommandText = "INSERT INTO Books(ISBN,Title,Author,PubYear,Genre) " +
                    "values ('" + book.ISBN + "','" + book.Title + "'," + book.authorID + "," +
                    book.PubYear + "," + book.Genre + ");";
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

        // ////////////////////////////////
        public void DeleteBook(String ISBN)
        {
            try
            {
                if (!ISBN.Equals(""))
                {
                    command.CommandText = "DELETE FROM Books WHERE ISBN='" + ISBN + "';";
                    command.CommandType = System.Data.CommandType.Text;
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("No ISBN entered!");
                }

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

        // //////////////////////////////////////
        public void UpdateBook(String ISBN, String Title)//, String AuthorID, String PubYear, String Genre
        {
            try
            {
                if (!ISBN.Equals("") && ISBN!=null )
                {
                    if (!Title.Equals("") && Title!=null)
                    {
                        command.CommandText = "UPDATE Books SET Title = '" + Title +
                            "' WHERE ISBN='" + ISBN + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                    //if (!AuthorID.Equals("") && AuthorID != null)
                    //{
                    //    command.CommandText = "UPDATE Books SET Author = '" + AuthorID + "' WHERE ISBN='" + ISBN + "';";
                    //    command.CommandType = System.Data.CommandType.Text;
                    //    connect.Open();
                    //    command.ExecuteNonQuery();
                    //}
                    //if (!PubYear.Equals("") && PubYear != null)
                    //{
                    //    command.CommandText = "UPDATE Books SET PubYear = '" + PubYear + "' WHERE ISBN='" + ISBN + "';";
                    //    command.CommandType = System.Data.CommandType.Text;
                    //    connect.Open();
                    //    command.ExecuteNonQuery();
                    //}
                    //if (!Genre.Equals("") && Genre != null)
                    //{
                    //    command.CommandText = "UPDATE Books SET Genre = '" + Genre + "' WHERE ISBN='" + ISBN + "';";
                    //    command.CommandType = System.Data.CommandType.Text;
                    //    connect.Open();
                    //    command.ExecuteNonQuery();
                    //}
                }
                else
                {
                    throw new Exception("No ISBN entered!");
                }
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
        public void Spravka1(String genre)
        {
            try
            {
                if (genre != "") { 
                //if(genre==)
                
                }
            
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

        ////////////////////////////
        ///                      ///
        ///  GENRE DB FUNCTIONS  ///
        ///                      ///
        ////////////////////////////

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

        //////////////////////////////
        ///                        ///
        ///  VISITOR DB FUNCTIONS  ///
        ///                        ///
        //////////////////////////////

        public void InsertVisitor(Visitor visitor)
        {
            try
            {
                if (!visitor.barcode.Equals("") && !visitor.fname.Equals("") && !visitor.mname.Equals("") && !visitor.lname.Equals("") && !visitor.age.Equals("") && !visitor.gender.Equals("") && !visitor.EGN.Equals(""))
                {
                    command.CommandText = "INSERT INTO Visitors(EGN,FirstName,MiddleName,LastName,Barcode,Gender,Age) values ('"
                        + visitor.EGN + "','"
                        + visitor.fname + "','"
                        + visitor.mname + "','"
                        + visitor.lname + "','"
                        + visitor.barcode + "','"
                        + visitor.gender + "','"
                        + visitor.age + "');";
                    // "INSERT INTO Visitors(FirstName,MiddleName,LastName,Barcode,Age,Gender,EGN)
                    // values ('" + visitor.fname + "','"+ visitor.mname + "','"
                    //+visitor.lname + "','"
                    //+ visitor.barcode + "',"
                    //+ visitor.age + "','"
                    //+  visitor.gender ",'";

                    command.CommandType = System.Data.CommandType.Text;
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("All fields must be filled to create a new Visitor!");
                }

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

        public void UpdateVisitor( String EGN,String fname, String mname, String lname, String barcode, String gender, String age)
        {
            try
            {
                if (!barcode.Equals(""))
                {
                    if (!fname.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET FirstName = '" + fname + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                    if (!mname.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET MiddleName = '" + mname + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                    if (!lname.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET LastName = '" + lname + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                    if (!age.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET Age = '" + age + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                    if (!EGN.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET EGN = '" + EGN + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                    if (!gender.Equals(""))
                    {
                        command.CommandText = "UPDATE Visitors SET Gender = '" + gender + "' WHERE Barcode='" + barcode + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new Exception("No barcode entered!");
                }


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

        public void DeleteVisitor(String barcode)
        {
            try
            {
                if (!barcode.Equals(""))
                {
                    command.CommandText = "DELETE FROM Visitors WHERE Barcode='" + barcode + "';";
                    command.CommandType = System.Data.CommandType.Text;
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("No barcode entered!");
                }

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

        ///////////////////////////
        ///                     ///
        ///  RENT DB FUNCTIONS  ///
        ///                     ///
        ///////////////////////////

        //public void RentBook(Rent rental)
        public void RentBook(Rent rental)
        {

            try
            {
                command.CommandText = "INSERT INTO Rent(VisitorBarcode,StartDate,EndDate,BookID,isReturned) values ('" 
                    + rental.visitorBarcode + "','" + rental.startDate.ToString() + "','" + rental.endDate.ToString() 
                    + "','" + rental.BookID + "',FALSE);";
                //command.CommandText = "INSERT INTO Rent([VisitorBarcode],[StartDate],[EndDate],[BookID],isReturned) values ('" + barcode + "','" + start.ToString() + "','" + end.ToString() + "','" + ISBN + "',FALSE);";
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

        public void ReturnBook(String barcode, String BookID)
        {

            try
            {
                command.CommandText = "UPDATE Rent SET isReturned = TRUE WHERE BookID = '" 
                    + BookID +"' AND VisitorBarcode = '" + barcode + "';";
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

        public Rent[] GetVisitorRentals(String visitor)
        {
            Rent[] returnRent = new Rent[1000];
            try
            {

                command.CommandText = "SELECT BookID FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> result = new List<String>();
                List<String> BookIDs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        BookIDs.Add(res);
                    }
                    connect.Close();
                }


                command.CommandText = "SELECT VisitorBarcode FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Barcodes = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        Barcodes.Add(res);
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT isReturned FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<bool> Returned = new List<bool>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetBoolean(0).ToString());
                    }
                    foreach (String res in result)
                    {
                        Returned.Add((Boolean.Parse(res)));
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT StartDate FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> StartDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("dd/MM/yyyy"));////!!!
                    }
                    foreach (String res in result)
                    {
                        StartDates.Add(res);
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT EndDate FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> EndDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("dd/MM/yyyy"));/////
                    }
                    foreach (String res in result)
                    {
                        EndDates.Add(res);
                    }
                    connect.Close();
                }

                for (int i = 0; i < result.Count; i++)
                {
                    String date = StartDates[i];
                    returnRent[i] = new Rent(Barcodes[i], DateTime.Parse(StartDates[i]), DateTime.Parse(EndDates[i]),
                     BookIDs[i], Returned[i]);//,    DateTime.ParseExact(StartDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                              // DateTime.ParseExact(EndDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture)

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
        public Rent[] OverdueRentals() {
            Rent[] overdueRentals = new Rent[1000];
            try
            {

                command.CommandText = "SELECT BookID FROM Rent WHERE  isReturned= '" + false + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> result = new List<String>();
                List<String> BookIDs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        BookIDs.Add(res);
                    }
                    connect.Close();
                }


                command.CommandText = "SELECT VisitorBarcode FROM Rent WHERE  isReturned= '" + false + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Barcodes = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        Barcodes.Add(res);
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT isReturned FROM Rent WHERE  isReturned= '" + false + "';";
                connect.Open();
                List<bool> Returned = new List<bool>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetBoolean(0).ToString());
                    }
                    foreach (String res in result)
                    {
                        Returned.Add((Boolean.Parse(res)));
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT StartDate FROM Rent WHERE isReturned= '" + false + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> StartDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("dd/MM/yyyy"));////!!!
                    }
                    foreach (String res in result)
                    {
                        StartDates.Add(res);
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT EndDate FROM Rent WHERE isReturned= '" + false + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> EndDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("dd/MM/yyyy"));/////
                    }
                    foreach (String res in result)
                    {
                        EndDates.Add(res);
                    }
                    connect.Close();
                }

                for (int i = 0; i < result.Count; i++)
                {
                    String date = StartDates[i];
                    overdueRentals[i] = new Rent(Barcodes[i], DateTime.Parse(StartDates[i]), DateTime.Parse(EndDates[i]),
                     BookIDs[i], Returned[i]);//,    DateTime.ParseExact(StartDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                              // DateTime.ParseExact(EndDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture)

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
            return overdueRentals;

        }

        ////////////////////////////
        ///                      ///
        ///  FETCH DB FUNCTIONS  ///
        ///                      ///
        ////////////////////////////
        public Book[] Books()
        {
            Book[] returnBooks;
            try
            {

                command.CommandText = "SELECT DISTINCT Books.ISBN FROM Books;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> result = new List<String>();
                List<String> ISBNs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));

                    }
                    foreach (String res in result)
                    {
                        ISBNs.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

                command.CommandText = "SELECT Books.Title FROM Books;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Titles = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        Titles.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

                command.CommandText = "SELECT Books.Author FROM Books;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<int> AuthorIDs = new List<int>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());
                    }
                    foreach (String res in result)
                    {
                        
                        AuthorIDs.Add(Int32.Parse(res));
                    }
                    connect.Close();
                }

                result.Clear();
                command.CommandText = "SELECT Books.PubYear FROM Books;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> PubYears = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());

                        foreach (String res in result)
                        {
                            PubYears.Add(res);

                        }
                    }
                    connect.Close();
                }

                command.CommandText = "SELECT Books.Genre FROM Books;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Genres = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());
                    }
                    foreach (String res in result)
                    {
                        Genres.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

            
                returnBooks = new Book[ISBNs.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    returnBooks[i] = new Book(ISBNs[i], Titles[i],AuthorIDs[i], PubYears[i], Genres[i]);
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
            return returnBooks;

        }

        // ///////////////////////////////////////////////////////////////////////

        public Visitor[] Visitors()
        {
            Visitor[] returnVisitors;
            try
            {

                command.CommandText = "SELECT DISTINCT Visitors.EGN FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> result = new List<String>();
                List<String> EGNs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));

                    }
                    foreach (String res in result)
                    {
                        EGNs.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

                command.CommandText = "SELECT Visitors.FirstName FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> FNames = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        FNames.Add(res);
                    }
                    connect.Close();
                }
                result.Clear();
                command.CommandText = "SELECT Visitors.MiddleName FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> MNames = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        MNames.Add(res);
                    }
                    connect.Close();
                }


                result.Clear();

                command.CommandText = "SELECT Visitors.LastName FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> LNames = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        LNames.Add(res);
                    }
                    connect.Close();
                }
                result.Clear();



                command.CommandText = "SELECT Barcode FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Barcodes = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));

                    }
                    foreach (String res in result)
                    {
                        Barcodes.Add(res);

                    }
                    connect.Close();
                }
                result.Clear();



                command.CommandText = "SELECT Visitors.Gender FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Genders = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    foreach (String res in result)
                    {
                        Genders.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

                command.CommandText = "SELECT Visitors.Age FROM Visitors;";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> Ages = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());

                    }
                    foreach (String res in result)
                    {
                        Ages.Add(res);

                    }
                    connect.Close();
                }


                returnVisitors = new Visitor[Barcodes.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    returnVisitors[i] = new Visitor(EGNs[i], FNames[i], 
                        MNames[i], LNames[i], Barcodes[i],  Genders[i], Ages[i]);
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
            return returnVisitors;

        }



    }
}
