namespace csharpcore
{
    public class BackstagePassesRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.SellIn > 10 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
    }
}