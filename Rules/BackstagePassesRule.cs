namespace csharpcore
{
    public class BackstagePassesRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.Name == ItemName.BACKSTAGE_PASSES)
            {
                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                    item.SellIn -= 1;
                }

                if (item.SellIn <= 5 && item.SellIn > 0)
                {
                    item.Quality += 3;
                    item.SellIn -= 1;
                }

                if (item.SellIn <= 10 && item.SellIn > 5)
                {
                    item.Quality += 2;
                    item.SellIn -= 1;
                }
              
                if (item.SellIn > 10)
                {
                    item.Quality += 1;
                    item.SellIn -= 1;
                }
            }
        }
    }
}
