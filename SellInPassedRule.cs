namespace csharpcore
{
    public class SellInPassedRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.SellIn < 0)
            {
                item.Quality -= 1;
            }
        }
    }
}
