namespace csharpcore
{
    public class BackstagePassesExpiredRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
                item.SellIn -= 1;
            }
        }
    }
}