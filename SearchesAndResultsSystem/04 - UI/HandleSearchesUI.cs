using System;

namespace JB
{
    public class HandleSearchesUI : IDisposable
    {
        SearchesLogic searchLogic = new SearchesLogic();
        ResultLogic resultLogic = new ResultLogic();
        FindSearches find = new FindSearches();

        public void Start()
        {
            string choice = "";
            do
            {
                Menu.DisplayMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SearchByFileName();
                        break;
                    case "2":
                        SearchByFileNameandDirectory();
                        break;
                    case "3":
                        Console.WriteLine("Thank you\nHave a nice day:-)");
                        break;
                    default:
                        Menu.DisplayError();
                        break;
                }
                Console.ReadLine();
            } while (choice != "3");
        }

        // function to search by value that entred by user
        private void SearchByFileName()
        {
            Console.WriteLine("Enter file name to search: ");
            string fileName = Console.ReadLine();
            if (fileName == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No value entered for searching, please try again");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Start Searching....");
            Console.ResetColor();
            find.SearchFound += (sender, e) =>
            {
                Console.WriteLine(e.Path); // Using event to display results
                resultLogic.AddResult(e.SearchID, e.Path); // and to add to database
            };
            find.ExceptionFound += (sender, e) => Console.WriteLine(e.ExceptionCode); //Using event to display exceptions.

            find.SearchEntireComputer(fileName);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nSearch completed successfully :-)");
            Console.ResetColor();
        }

        // function to search by value and folder that entred by user
        private void SearchByFileNameandDirectory()
        {
            Console.WriteLine("Enter file name to search: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter root directory to search in: ");
            string directory = Console.ReadLine();
            if (fileName == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No value entered for searching, please try again...");
                Console.ResetColor();
                return;
            }
            if (directory == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Root directory not entered,please try again...");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Start Searching....");
            Console.ResetColor();
            find.SearchFound += (sender, e) => { 
                Console.WriteLine(e.Path); //Using event to display results
                resultLogic.AddResult(e.SearchID, e.Path); //  and to add to database
            };
            find.ExceptionFound += (sender, e) => Console.WriteLine(e.ExceptionCode); //Using event to display exceptions.

            find.SerchFilesByDirectoryAndFileName(directory, fileName);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nSearch completed successfully :-)");
            Console.ResetColor();
            }

        public void Dispose()
        {
            searchLogic.Dispose();
            resultLogic.Dispose();
        }
    }
}
