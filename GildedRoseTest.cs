using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseUpdateQuality
    {
        private IList<Item> GetNormalItem()
        {
            return new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 9 } };
        }
        
        [Fact]
        public void ReducesNormalItemSellInByOne()
        {
            IList<Item> items = GetNormalItem();
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void ReducesNormalItemQualityByOne()
        {
            IList<Item> items = GetNormalItem();
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
        }
    }
}