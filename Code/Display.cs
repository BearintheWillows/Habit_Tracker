using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habit_Tracker.Code
{
    public class Display
    {
        public static void Menu()
        {
            Console.WriteLine(@"
            ---- Options ----
            1 - Add Habit
            2 - List Habits
            3 - Update Habit
            4 - Delete Habit
            5 - Exit Program
            ");
        }

        public static void NotANumberError()
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter a Number: ");
        }

      
    }
}