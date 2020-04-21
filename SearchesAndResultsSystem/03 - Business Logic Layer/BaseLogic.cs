using System;

namespace JB
{
    public class BaseLogic : IDisposable
    {
        protected SearchesAndResultsEntities DB = new SearchesAndResultsEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
