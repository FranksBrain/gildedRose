namespace csharpcore
{
    public class QualityIsNeverNegativeRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.Quality <= 0)
            {
                item.Quality = 0;
            }
        }
    }
}