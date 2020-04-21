namespace JB
{
    class Program
    {
        static void Main(string[] args)
        {
            using(HandleSearchesUI handleSearchesUI = new HandleSearchesUI())
            {
                handleSearchesUI.Start();
            }
        }
    }
}
