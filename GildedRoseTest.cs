using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseUpdateQuality
    {
        private const int _defaultSellIn = 10;
        private const int _defaultQuality = 20;

        private Item GetNormalItem(int sellIn = _defaultSellIn, int quality = _defaultQuality)
        {
            return new Item { Name = "foo", SellIn = sellIn, Quality = quality };
        }
        
        [Fact]
        public void ReducesNormalItemSellInByOne()
        { 
            IList<Item> items = new List<Item> { GetNormalItem() };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(_defaultSellIn - 1, items[0].SellIn);
        }

        [Fact]
        public void ReducesNormalItemQualityByOne()
        {
            IList<Item> items = new List<Item> { GetNormalItem() };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(_defaultQuality - 1, items[0].Quality);
        }

        [Fact]
        public void QualityDegradesTwiceAsFastOnceSellInPasses()
        {
            IList<Item> items = new List<Item> { GetNormalItem(sellIn: 0) };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(_defaultQuality - 2, items[0].Quality);
        }
    }
}