using System;

namespace JB
{
    public class Menu
    {
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Select One of the Following: ");
            Console.WriteLine("1. Enter file name to search.");
            Console.WriteLine("2. Enter file name + parent directory to search in.");
            Console.WriteLine("3. Exit");
        }
        public static void DisplayError()
        {
            Console.WriteLine("Incorrect Choice!");
        }
    }
}
