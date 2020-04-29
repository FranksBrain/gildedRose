using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class ConjuredItemsRule : IRule
    {
        public void Eval(Item item)
        {
            if (item.Name.Contains("Conjured"))
            {
                if (item.Quality >= 0)
                {
                    item.Quality -= 2;
                    item.SellIn -= 1;
                }
                if (item.SellIn < 0)
                {
                    item.Quality -= 2;
                }
            }
        }
    }
}
