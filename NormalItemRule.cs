namespace csharpcore
{
    public class NormalItemRule : IRule
    {
        public void Eval(Item item)
        {
            item.Quality -= 1;
            item.SellIn -= 1;
        }
    }
}
