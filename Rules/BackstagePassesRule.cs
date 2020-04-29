namespace csharpcore
{
    public class BackstagePassesRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.Name == ItemName.BACKSTAGE_PASSES)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    item.Quality += 1;
                }

                if (item.SellIn < 6)
                {
                    item.Quality += 1;
                }

                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }

                item.SellIn -= 1;
            }
        }
    }
}