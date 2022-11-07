using Habit_Tracker.Data;

namespace Habit_Tracker.Code
{
    public class UI
    {
        public void MenuChoices(int choiceInput)
        {
            int choice = choiceInput;
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        AddHabit();
                        break;
                    case 2:
                        GetHabits();
                        break;
                    case 3:
                        UpdateHabit();
                        break;
                    case 4:
                        DeleteHabit();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        Console.WriteLine("Try again: ");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
                GetMenuInput();
                choice = 5;
            }
            Console.Clear();
            Console.WriteLine("Goodbye");
        }

        private void DeleteHabit()
        {
            Console.WriteLine("Enter the ID of the Habit you want to delete: ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int value))
            {
                if (AppDb.DeleteById(value))
                {
                    Console.WriteLine("Habit Deleted");
                }
                else
                {
                    DeleteHabit();
                }
            }
        }

        public void GetMenuInput()
        {
            Display.Menu();
            Console.WriteLine("Choose an option: ");
            string choiceInput = Console.ReadLine();

            if (!int.TryParse(choiceInput, out int choice))
            {
                Display.NotANumberError();
                GetMenuInput();
            }
            else if (choice == 5)
            {
            } else
            {
                MenuChoices(choice);
            }
        }

        private static DateTime DateCheck()
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

        private void AddHabit()
        {
            var date = DateCheck();
            var quanitity = QuantityCheck();
            AppDb.InsertHabit(date, quanitity);
        }

        private void GetHabits()
        {
            var habits = AppDb.GetHabits();
            int count = 1;
            foreach (var habit in habits)
            {
                Console.WriteLine(
                    $"{count} - ID: {habit.Id} Date: {habit.Date} Quantity: {habit.Quantity}"
                );
                count++;
            }
        }

        private static int QuantityCheck()
        {
            int input;
            Console.WriteLine("Please enter a Quantity: ");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Display.NotANumberError();
            }

            return input;
        }

private static void UpdateHabit()
        {
            Console.WriteLine("Enter the ID of the Habit you want to update: ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out int value))
            {
                var habit = AppDb.GetById(value);
                if (habit != null)
                {
                    habit.Quantity = QuantityCheck();
                    AppDb.UpdateHabit(habit);
                }
                else
                {
                    UpdateHabit();
                }
            }
            else
            {
                Display.NotANumberError();
                UpdateHabit();
            }
        }
    }
}
