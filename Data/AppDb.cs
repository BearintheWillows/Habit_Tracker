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

        public static void InsertHabit(DateTime date, int quantity)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    // Open Connection
                    connection.Open();
                    // insert into habits (date, quantity) values ('2021-01-01', 1)
                    command.CommandText = @"INSERT INTO habits (date, quantity) VALUES (@date, @quantity)";
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    // Execute non-query command. No Data Returned
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Data Inserted successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Data not Inserted");
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
