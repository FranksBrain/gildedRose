namespace csharpcore
{
    public class BackstagePassesLessThan5DaysButNotExpiredRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.SellIn <= 5 && item.SellIn > 0)
            {
                item.Quality += 3;
                item.SellIn -= 1;
            }
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}