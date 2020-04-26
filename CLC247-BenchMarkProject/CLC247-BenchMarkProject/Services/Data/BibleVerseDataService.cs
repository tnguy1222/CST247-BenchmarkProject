/* BenchMark Project version 1.0
 * BibleVerseDataService version 1.0
 * Jim Nguyen
 * April 24, 2020
 * BibleVerseDataService
 */
using CLC247_BenchMarkProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CLC247_BenchMarkProject.Services.Data
{
    public class BibleVerseDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bible;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<BibleVerseModel> SearchByPhrase(string phrase)
        {
            BibleVerseModel verse = new BibleVerseModel();
            List<BibleVerseModel> foundVerses = new List<BibleVerseModel>();

            // queryString with a placeholder
            string queryString = "select * from dbo.Bible where versetext like @versetext ";

            //create and open connection using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@versetext", "%" + phrase + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            verse = new BibleVerseModel(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                            foundVerses.Add(verse);
                        }
                    }
                    reader.Close();

                    // Exception handler that returns error message
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundVerses;
        }

        public BibleVerseModel Search(BibleVerseModel bibleVerse)
        {

            BibleVerseModel verse = new BibleVerseModel();
            // queryString with a placeholder
            string queryString = "select * from dbo.Bible where testament like @testament and  book like @book and chapternumber like @chapternumber and versenumber like @versenumber";

            //create and open connection using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@testament", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Testament;
                command.Parameters.Add("@book", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Book;
                command.Parameters.Add("@chapternumber", System.Data.SqlDbType.Int).Value = bibleVerse.ChapterNumber;
                command.Parameters.Add("@versenumber", System.Data.SqlDbType.Int).Value = bibleVerse.VerseNumber;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            verse = new BibleVerseModel(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                        }
                    }
                    reader.Close();

                    // Exception handler that returns error message
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return verse;
        }
    }
}