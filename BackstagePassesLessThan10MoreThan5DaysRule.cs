namespace csharpcore
{
    public class BackstagePassesLessThan10MoreThan5DaysRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.SellIn <= 10 && item.SellIn > 5 && item.Quality < 50)
            {
                item.Quality += 2;
            }
        }
    }
}