namespace JB
{
    public class ResultLogic : BaseLogic
    {
        public void AddResult(int searchID, string path)
        {
            Result resultToAdd = new Result {SearchID = searchID, FullPath = path};
            DB.Results.Add(resultToAdd);
            DB.SaveChanges();
        }
    }
}


