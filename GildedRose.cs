using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> items;
        private List<IRule> _rules = new List<IRule>();

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                UpdateItem(items[i]);
            }
        }

        private void UpdateItem(Item item)
        {
            switch (item.Name)
            {
                case ItemName.SULFURAS:
                    break;
                case ItemName.AGED_BRIE:
                    new AgedBrieRule().Eval(item);
                    break;
                case ItemName.BACKSTAGE_PASSES:
                    new BackstagePassesExpiredRule().Eval(item);
                    new BackstagePassesLessThan5DaysButNotExpiredRule().Eval(item);
                    new BackstagePassesLessThan10MoreThan5DaysRule().Eval(item);
                    new BackstagePassesMoreThan10DaysRule().Eval(item);
                    
                    
                    
                    break;
                default:
                    new NormalItemRule().Eval(item);
                    break;
            }
            //    if (item.Name != ItemName.AGED_BRIE && item.Name != ItemName.BACKSTAGE_PASSES)
            //    {
            //        if (item.Quality > 0)
            //        {
            //            if (item.Name != ItemName.SULFURAS)
            //            {
            //                item.Quality = item.Quality - 1;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (item.Quality < 50)
            //        {
            //            item.Quality = item.Quality + 1;

            //            if (item.Name == ItemName.BACKSTAGE_PASSES)
            //            {
            //                if (item.SellIn < 11)
            //                {
            //                    if (item.Quality < 50)
            //                    {
            //                        item.Quality = item.Quality + 1;
            //                    }
            //                }

            //                if (item.SellIn < 6)
            //                {
            //                    if (item.Quality < 50)
            //                    {
            //                        item.Quality = item.Quality + 1;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    if (item.Name != ItemName.SULFURAS)
            //    {
            //        item.SellIn = item.SellIn - 1;
            //    }

            //    if (item.SellIn < 0)
            //    {
            //        if (item.Name != ItemName.AGED_BRIE)
            //        {
            //            if (item.Name != ItemName.BACKSTAGE_PASSES)
            //            {
            //                if (item.Quality > 0)
            //                {
            //                    if (item.Name != ItemName.SULFURAS)
            //                    {
            //                        item.Quality = item.Quality - 1;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                item.Quality = item.Quality - item.Quality;
            //            }
            //        }
            //        else
            //        {
            //            if (item.Quality < 50)
            //            {
            //                item.Quality = item.Quality + 1;
            //            }
            //        }
            //    }
        }
    }
}
