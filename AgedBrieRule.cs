namespace csharpcore
{
    public class AgedBrieRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Quality < 50)
            {
                if (item.Name == ItemName.AGED_BRIE)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}
