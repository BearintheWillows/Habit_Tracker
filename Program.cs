﻿using Habit_Tracker.Data;
using Habit_Tracker.Code;

Display _ = new();
UI ui = new();
AppDb.CreateDB();

Display.Menu();

ui.GetMenuInput();
