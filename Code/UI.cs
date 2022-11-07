using System.Runtime.CompilerServices;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habit_Tracker.Data;

namespace Habit_Tracker.Code
{
    public class UI
    {
        public void MenuChoices(int choice)
        {
                switch (choice)
            {
                case 1:
                AddHabit();
                break;

                default:
                Console.WriteLine("Incorrect Option");
                Console.WriteLine("Try again: ");
                GetMenuInput();
                    break;
            }
    
        }

        public void GetMenuInput(){
            string choiceInput = Console.ReadLine();

            if (!int.TryParse(choiceInput, out int choice))
            {
                Display.NotANumberError();
                GetMenuInput();
            }
            else
            {
                MenuChoices(choice);
            }
        }

        public void AddHabitInput()
        {

        }

        public DateTime DateCheck()
        {
            Console.WriteLine("Have you performed the Habit now? Y/N");
            var input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Please enter Y or N :");
                input = Console.ReadLine().ToLower();
            }
            switch (input)
            {
                case "y":
                    return DateTime.Now;
                case "n":
                    DateTime date;
                    Console.WriteLine("Please Enter a date: ");
                    while (!DateTime.TryParse(Console.ReadLine(), out date))
                    {
                        Console.WriteLine("Incorrect Date. Try again.");
                        Console.WriteLine("Valid Date Format - DD/MM/YYYY");
                    }
                    Console.WriteLine(date);
                    return date;
                default:
                    return DateTime.Now;
            }
        }

        public void AddHabit()
        {
            var date = DateCheck();
            var quanitity = QuantityCheck();
            AppDb.InsertHabit(date, quanitity);
        }

        private static int QuantityCheck()
        {

            int input;
            Console.WriteLine("Please enter a Quantity: ");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Incorrect Value.");
                Console.WriteLine("Please enter a Number: ");
            }

            return input;
        }
    }
}