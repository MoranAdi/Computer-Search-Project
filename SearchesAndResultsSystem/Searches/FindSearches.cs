using System;
using System.IO;

namespace JB
{
    public class FindSearches
    {
        public event EventHandler<SearchesEventArgs> SearchFound;
        public event EventHandler<ExceptionsEventArgs> ExceptionFound;
        SearchesLogic searchLogic = new SearchesLogic();

        // Searching function by Entered value and folder for searching 
        public void SerchFilesByDirectoryAndFileName(string folder, string search)
        {
            search = search.ToLower();

            SearchDTO myserch = new SearchDTO
            {
                findText = search,
                findFolder = folder,
                time = DateTime.Now
            };

            int searchID = searchLogic.AddSearch(myserch);
            executeTheSearch(folder, search, searchID);
        }


        // Searching function in the entire computer
        public void SearchEntireComputer(string search)
        {
            search = search.ToLower();
            string[] drives = Directory.GetLogicalDrives();
            SearchDTO myserch = new SearchDTO
            {
                findText = search,
                time = DateTime.Now
            };
            int searchID = searchLogic.AddSearchFileNameOnly(myserch);
            foreach (string drive in drives)
            {
                executeTheSearch(drive, search, searchID);
            }
        }


        // function that execute the search (the function above calls this function)
        public void executeTheSearch(string folder, string search, int searchID)
        {
            try
            {
                search = search.ToLower();
                string[] files = Directory.GetFiles(folder);
                foreach (string f in files)
                {
                    string path = Path.GetFullPath(f);
                    string fileName = Path.GetFileNameWithoutExtension(f).ToLower();

                    if (fileName.Contains(search))
                    {
                        SearchFound(this, new SearchesEventArgs(searchID, path));
                    }
                }
                string[] directories = Directory.GetDirectories(folder);
                if (directories.Length == 0)
                    return;
                foreach (string d in directories)
                    executeTheSearch(d, search, searchID);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ExceptionFound(this, new ExceptionsEventArgs(ex.Message));
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ExceptionFound(this, new ExceptionsEventArgs(ex.Message));
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ExceptionFound(this, new ExceptionsEventArgs(ex.Message));
                Console.ResetColor();
            }
        }
    }
}