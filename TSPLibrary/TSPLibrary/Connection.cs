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

        private void ConnectionTo() {
            connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\TSPLibrary\TSPLibrary\Database1.mdb");
            command = connect.CreateCommand();

        }

        public Connection() {
            ConnectionTo();
        }

        public void Insert(Author author)
        {
            try
            {
                command.CommandText = "INSERT INTO Author(_Author) values ('" + author.author+ "');";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                if (connect != null) {
                    connect.Close();
                }            
            }
        }
    }
}
