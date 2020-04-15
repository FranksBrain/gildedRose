namespace csharpcore
{
    public class AgedBrieRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
                item.SellIn -= 1;
            }
            if(item.SellIn < 0)
            {
                item.Quality += 1;
            }
        }
    }
}
