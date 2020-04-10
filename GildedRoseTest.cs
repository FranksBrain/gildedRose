using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseUpdateQuality
    {
        [Fact]
        public void ReducesNormalItemSellInByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
        }
    }
}