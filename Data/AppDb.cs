using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using Habit_Tracker.Models;
using Habit_Tracker.Code;

namespace Habit_Tracker.Data;

public static class AppDb
    {
    private const string connectionString = "Data Source=habit-tracker.db";

        public static void CreateDB()
    {
        // Creates a new Database if one does not exist
        using var connection = new SQLiteConnection(connectionString);
        // Declaring command sent to Db
        using var command = connection.CreateCommand();
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

        public static bool DeleteById(int id)
        {
            using (var connection = new SQLiteConnection(connectionString) )
            {
                using (var command = connection.CreateCommand())
                {
                    // Open Connection
                    connection.Open();
                    // Select row from Habits where Id = id
                    command.CommandText = $"SELECT * FROM habits WHERE Id = {id}";
                    command.Parameters.AddWithValue("@id", id);

                    // Create SQLiteDataReader to read the data
                    SQLiteDataReader reader = command.ExecuteReader();

                    // Check if the reader has any rows
                    if (reader.HasRows)
                    {
                        reader.Close();
                        // Delete row from habits where Id = id
                        command.CommandText = $"DELETE FROM habits WHERE Id = {id}";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        Display.IdNotFoundError();
                        return false;
                    }
                }
            }
        }
    
        public static List<Habit> GetHabits()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    // Open Connection
                    connection.Open();
                    // Select all rows from habits
                    command.CommandText = "SELECT * FROM habits";
                    // Create SQLiteDataReader to read the data
                    SQLiteDataReader reader = command.ExecuteReader();
                    // Create a list to store the habits
                    List<Habit> habits = new();
                    // Loop through the reader
                    while (reader.Read())
                    {
                        // Create a habit object
                        Habit habit = new Habit();
                        // Set the habit properties
                        habit.Id = reader.GetInt32(0);
                        habit.Date = reader.GetDateTime(1);
                        habit.Quantity = reader.GetInt32(2);
                        // Add the habit to the list
                        habits.Add(habit);
                    }
                    // Return the list of habits
                    return habits;
                }
            }
        }

        public static bool UpdateHabit(Habit habit)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    // Open Connection
                    connection.Open();
                    // Select row from Habits where Id = id
                    command.CommandText = $"SELECT * FROM habits WHERE Id = {habit.Id}";
                    command.Parameters.AddWithValue("@id", habit.Id);

                    // Create SQLiteDataReader to read the data
                    SQLiteDataReader reader = command.ExecuteReader();
                    // Check if the reader has any rows
                    if (reader.HasRows)
                    {
                        reader.Close();
                        // Update row from habits where Id = id
                        Console.WriteLine("Updating Habit...");
                        command.CommandText = $"UPDATE habits SET Date = @date, Quantity = @quantity WHERE Id = {habit.Id}";
                        command.Parameters.AddWithValue("@date", habit.Date);
                        command.Parameters.AddWithValue("@quantity", habit.Quantity);
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Habit {habit.Id} updated successfully");
                        return true;
                    }
                    else
                    {
                        Display.IdNotFoundError();
                        return false;
                    }
                }
            }
        }

        public static Habit GetById(int id)
        {
        using var connection = new SQLiteConnection(connectionString);
        using var command = connection.CreateCommand();
        // Open Connection
        connection.Open();
        // Select row from Habits where Id = id
        command.CommandText = $"SELECT * FROM habits WHERE Id = {id}";
        command.Parameters.AddWithValue("@id", id);

        // Create SQLiteDataReader to read the data
        using var reader = command.ExecuteReader();

        // Check if the reader has any rows
        if (reader.HasRows)
        {
            reader.Read();
            Habit habit = new Habit();
            habit.Id = reader.GetInt32(0);
            habit.Date = reader.GetDateTime(1);
            habit.Quantity = reader.GetInt32(2);
           
            return habit;
        }
        else
        {
            Display.IdNotFoundError();
            return null;
        }

    }

}

