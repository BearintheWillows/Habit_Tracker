using System.Data.SQLite;

namespace Habit_Tracker.Data;

public static class AppDb
    {
    private const string connectionString = "Data Source=habit-tracker.db";

    public static void CreateDB()
    {
        // Creates a new Database if one does not exist
        using var connection = new SQLiteConnection(connectionString);
        // Declaring command sent to Db
        using (var command = connection.CreateCommand())
        {
            connection.Open();

            // Declaring Command in SQL
            command.CommandText =
                @"CREATE TABLE IF NOT EXISTS habits (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

            // Execute non-query command. No Data Returned
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Db Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Db not Created");
                Console.WriteLine(e);
            }
        }
        //Connection closes automatically by using the 'using' statement
    }
    }
