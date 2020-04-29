using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> items;
        private List<IRule> _rules = new List<IRule>();

        
        private void AddRules()
        {
            _rules.Add(new NormalItemRule());
            _rules.Add(new AgedBrieRule());
            _rules.Add(new SellInPassedRule());
            _rules.Add(new BackstagePassesRule());
            _rules.Add(new ConjuredItemsRule());
            _rules.Add(new QualityIsNeverNegativeRule());
            _rules.Add(new QualityIsNeverOverFiftyRule());
        }

        public GildedRose(IList<Item> items)
        {
            this.items = items;
            AddRules();
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
            foreach (var rule in _rules)
            {
                rule.Eval(item);
            }
        }
    }
}