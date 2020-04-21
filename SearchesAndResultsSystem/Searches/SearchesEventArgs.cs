using System;

namespace JB
{
    public  class SearchesEventArgs : EventArgs
    {
        public int SearchID;
        public string Path;

        public SearchesEventArgs(int searchID, string path)
        {
            SearchID = searchID;
            Path = path;
        }
    }
}
