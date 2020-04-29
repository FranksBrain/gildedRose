namespace csharpcore
{
    public class NormalItemRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Name != ItemName.AGED_BRIE && item.Name != ItemName.SULFURAS && item.Name != ItemName.BACKSTAGE_PASSES && !item.Name.Contains("Conjured"))
            {
                if (item.Quality >= 0)
                {
                    item.Quality -= 1;
                    item.SellIn -= 1;
                }
            }
        }
    }
}