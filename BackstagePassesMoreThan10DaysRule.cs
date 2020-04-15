namespace csharpcore
{
    public class BackstagePassesMoreThan10DaysRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.SellIn > 10)
            {
                item.Quality += 1;
                item.SellIn -= 1;
            }
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}