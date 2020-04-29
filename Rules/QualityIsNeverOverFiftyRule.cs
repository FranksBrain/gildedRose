namespace csharpcore
{
    public class QualityIsNeverOverFiftyRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Name != ItemName.SULFURAS)
            {
                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }
        }
    }
}