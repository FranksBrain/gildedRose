namespace csharpcore
{
    public class NormalItemRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
                item.SellIn -= 1;
                if (item.SellIn < 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
