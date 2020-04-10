using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseUpdateQuality
    {
        private Item GetNormalItem(int sellIn, int quality)
        {
            return new Item { Name = "foo", SellIn = sellIn, Quality = quality };
        }
        
        [Fact]
        public void ReducesNormalItemSellInByOne()
        {
            IList<Item> items = new List<Item> { GetNormalItem(10, 9) };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void ReducesNormalItemQualityByOne()
        {
            IList<Item> items = new List<Item> { GetNormalItem(10, 9) };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
        }
    }
}