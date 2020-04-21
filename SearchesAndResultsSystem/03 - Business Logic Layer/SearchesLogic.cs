using System;
using System.IO;
using System.Linq;

namespace JB
{
    public class SearchesLogic : BaseLogic
    {
        // Add to database (with folder to search)
        public int AddSearch(SearchDTO search)
        {
            Search SearchToAdd = new Search
            {
                TextToSearch = search.findText,
                FolderToSearch = search.findFolder,
                SearchTime = search.time,
            };
            DB.Searches.Add(SearchToAdd);
            DB.SaveChanges();
            return SearchToAdd.SearchID;
        }

        // Add to database (without folder to search)
        public int AddSearchFileNameOnly(SearchDTO search)
        {
            Search SearchToAdd = new Search
            {
                TextToSearch = search.findText,
                SearchTime = search.time,
            };

            DB.Searches.Add(SearchToAdd);
            DB.SaveChanges();
            return SearchToAdd.SearchID;
        }
    }
}
