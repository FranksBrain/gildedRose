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

        private Item GetAgedBrie(int sellIn = _defaultSellIn, int quality = _defaultQuality)
        {
            return new Item { Name = ItemName.AGED_BRIE, SellIn = sellIn, Quality = quality };
        }

        private Item GetSulfuras(int sellIn = _defaultSellIn, int quality = _defaultQuality)
        {
            return new Item { Name = ItemName.SULFURAS, SellIn = sellIn, Quality = quality };
        }

        private Item GetBackstagePass(int sellIn = _defaultSellIn, int quality = _defaultQuality)
        {
            return new Item { Name = ItemName.BACKSTAGE_PASSES, SellIn = sellIn, Quality = quality };
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

        [Fact]
        public void AgedBrieQualityIncreasesAsItGetsOlder()
        {
            IList<Item> items = new List<Item> { GetAgedBrie() };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality + 1, items[0].Quality);
        }

        [Fact]
        public void ItemQualityIsNeverMoreThan50()
        {
            IList<Item> items = new List<Item> { GetAgedBrie(quality: 50) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void SulfurasQualityNeverChanges()
        {
            IList<Item> items = new List<Item> { GetSulfuras() };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality, items[0].Quality);
        }

        [Fact]
        public void SulfurasSellInNeverChanges()
        {
            IList<Item> items = new List<Item> { GetSulfuras() };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultSellIn, items[0].SellIn);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(13)]
        [InlineData(11)]
        public void BackstageQualityIncreasesByOneAsSellInMoreThanTenApproachesTen(int sellIn)
        {
            IList<Item> items = new List<Item> { GetBackstagePass(sellIn: sellIn) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality + 1, items[0].Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(6)]
        public void BackstageQualityIncreasesByTwoAsSellInLessThanTenApproachesFive(int sellIn)
        {
            IList<Item> items = new List<Item> { GetBackstagePass(sellIn: sellIn) };
            CreateAppAndUpdateQuality(items);
            Assert.Equal(_defaultQuality + 2, items[0].Quality);
        }
    }
}