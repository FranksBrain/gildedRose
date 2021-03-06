﻿namespace csharpcore
{
    public class SellInPassedRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Name != ItemName.AGED_BRIE && item.Name != ItemName.SULFURAS && !item.Name.Contains("Conjured"))
            {
                if (item.SellIn < 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
