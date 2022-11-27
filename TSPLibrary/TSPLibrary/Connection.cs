using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TSPLibrary
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

        ///////////////////////////
        ///                     ///
        ///  BOOK DB FUNCTIONS  ///
        ///                     ///
        ///////////////////////////

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
                else {
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
        public void UpdateBook(String ISBN,String Title,String AuthorID, String PubYear, String Genre)
        {
            try
            {
                if (!ISBN.Equals(""))
                {
                    if (!Title.Equals(""))
                    {
                        command.CommandText = "UPDATE Books SET Title = '" + Title + "' WHERE ISBN='" + ISBN + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                    if (!AuthorID.Equals(""))
                    {
                        command.CommandText = "UPDATE Books SET Author = '" + AuthorID + "' WHERE ISBN='" + ISBN + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                    if (!PubYear.Equals(""))
                    {
                        command.CommandText = "UPDATE Books SET PubYear = '" + PubYear + "' WHERE ISBN='" + ISBN + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                    if (!Genre.Equals(""))
                    {
                        command.CommandText = "UPDATE Books SET Genre = '" + Genre + "' WHERE ISBN='" + ISBN + "';";
                        command.CommandType = System.Data.CommandType.Text;
                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                }
                else {
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
                if (!visitor.barcode.Equals("") && !visitor.fname.Equals("") && !visitor.mname.Equals("") && !visitor.lname.Equals("") && !visitor.age.Equals("") && !visitor.gender.Equals("")&&!visitor.EGN.Equals(""))
                {
                    command.CommandText = "INSERT INTO Visitors(FirstName,MiddleName,LastName,Barcode,Age,Gender,EGN) values ('" + visitor.fname + "','"
                        + visitor.mname + "','"
                        + visitor.lname + "','"
                        + visitor.barcode + "',"
                        + visitor.age + ",'"
                        + visitor.gender + "','"
                        + visitor.EGN+"');";
                    command.CommandType = System.Data.CommandType.Text;
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                else {
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

        public void UpdateVisitor(String fname, String mname, String lname, String age, String gender, String barcode, String EGN) {
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
                else {
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

        public void DeleteVisitor(String barcode) {
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

                command.CommandText = "SELECT StartDate FROM Rent WHERE VisitorBarcode = '" + visitor + "';";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                List<String> StartDates = new List<String>();
                result.Clear();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetDateTime(0).ToString("MM/dd/yyyy"));
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
                        result.Add(reader.GetDateTime(0).ToString("MM/dd/yyyy"));
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

        ////////////////////////////
        ///                      ///
        ///  FETCH DB FUNCTIONS  ///
        ///                      ///
        ////////////////////////////
        public Book[] Books()
        {
            Book[] returnBooks = new Book[1000];
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
                List<String> AuthorIDs = new List<String>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());
                    }
                    foreach (String res in result)
                    {
                        AuthorIDs.Add(res);
                    }
                    connect.Close();
                }

                result.Clear();

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

                for (int i = 0; i < result.Count; i++)
                {
                    returnBooks[i] = new Book(AuthorIDs[i], Titles[i], ISBNs[i], Genres[i], PubYears[i]);
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
                returnVisitors = new Visitor[Barcodes.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    returnVisitors[i] = new Visitor(FNames[i],MNames[i], LNames[i], Barcodes[i], Ages[i], Genders[i],EGNs[i]);
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
