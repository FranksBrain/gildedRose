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

        private void CreateAppAndUpdateQuality(IList<Item> items)
        {
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
        }
        
        [Fact]
        public void ReducesNormalItemSellInByOne()
        { 
            IList<Item> items = new List<Item> { GetNormalItem() };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultSellIn - 1, items[0].SellIn);
        }

        [Fact]
        public void ReducesNormalItemQualityByOne()
        {
            IList<Item> items = new List<Item> { GetNormalItem() };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality - 1, items[0].Quality);
        }

        [Fact]
        public void QualityDegradesTwiceAsFastOnceSellInPasses()
        {
            IList<Item> items = new List<Item> { GetNormalItem(sellIn: 0) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality - 2, items[0].Quality);
        }

        [Fact]
        public void QualityIsNeverNegative()
        {
            IList<Item> items = new List<Item> { GetNormalItem(quality: 0) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(0, items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void QualityIsNeverNegativeWhenSellInIsZero(int quality)
        {
            IList<Item> items = new List<Item> { GetNormalItem(sellIn: 0, quality: quality) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(0, items[0].Quality);
        }
    }
}