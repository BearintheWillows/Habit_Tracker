using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habit_Tracker.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}