# Habit Tracker Console APP

| Project Type | Languages Used | Database Used | Libraries Used | 
| ------------ | -------------- | ------------- | -------------- |
| Console      | #CSharp        | #SQLite       |   #ADO.Net     |

Console App using:

- SQLite 
- ADO.Net
- CSharp

# Requriements:

- [x] Ability to Register one Habit.
- [x] Habit tracked by quantity.
- [x] Store and Retrieve Data from an SQLite Database.
- [x] When the app starts, it should create a database, if one isn't present.
- [x] Create a table in the database, where the Habit will be logged.
- [x] The app should display a menu of options.
- [x] The app should have CRUD functionality.
- [x] The app should handle all errors.
- [x] Application should terminate when user enters 5.
- [x] Only raw SQL to be used. No Framework.
- [x] Add a ReadMe File.

# Features:

## SQLite Database

- The App connects to a SQLite database and creates one if one is not available.

## CRUD

- When the app is opened a list of 5 options will be displayed.

1 - Add Habit
2 - List Habits
3 - Update Habit
4 - Delete Habit
5 - Exit Program

- All functions work. Errors handled and input validation implemented to maintain integrity of database.
-Parameters used to protect database from injection attacks.

## Comments

- I've never used raw SQL before or ADO.Net. Seeing how a database can be managed through raw SQL was eye opening.
- In particular, I have learned how better to use 'using' both block-quote and simplified to handle disposal tasks once complete.

## Resources Used:
- ReadMe file based on [thags](https://github.com/thags/ConsoleTimeLogger/blob/master/README.md)
- Project based on the Habit-Logger project by [thecsharpacademy](https://www.thecsharpacademy.com/habit-tracker/)
- Discord community for bug finding