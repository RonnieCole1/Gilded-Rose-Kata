using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
                {
                ItemCategory category = catagorize(item);
                category.UpdateOneItem(item);
                }
        }

        private static ItemCategory catagorize(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new Legendary();
            }
            if (item.Name == "Aged Brie")
            {
                return new Cheese();
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePass();
            }
            if (item.Name.StartsWith("Conjured")) {
                return new Conjured();
            }
            return new ItemCategory();
        }
    }
    internal class ItemCategory
    {
        public void UpdateOneItem(Item item)
        {
            updateQuality(item);
            updateSellIn(item);

            if (item.SellIn < 0)
            {
                updateExpired(item);
            }
        }
        protected void incrementQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
        protected void decrementQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        protected void updateExpired(Item item)
        {
            decrementQuality(item);
        }
        protected void updateSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
        protected void updateQuality(Item item)
        {
            decrementQuality(item);
        }
    }
    internal class Legendary : ItemCategory
    {
        protected new void updateExpired(Item item)
        {    
        } 
        protected new void updateSellIn(Item item)
        {
        }
        protected new void updateQuality(Item item)
        {
        }
    }

    internal class Cheese : ItemCategory
    {
        protected new void updateExpired(Item item)
        {    
            incrementQuality(item);
        } 
        protected new void updateQuality(Item item)
        {
            incrementQuality(item);
        }
    }
    internal class BackstagePass : ItemCategory
    {
        protected new void updateQuality(Item item)
        {
            incrementQuality(item);
                
            if (item.SellIn < 11)
            {
                incrementQuality(item);
            }
            if (item.SellIn < 6)
            {
                 incrementQuality(item); 
            } 
        }
        protected new void updateExpired(Item item)
        {
            item.Quality = 0;
        }
    }
    internal class Conjured : ItemCategory
    {
        protected new void updateExpired(Item item)
        {    
            decrementQuality(item);
            decrementQuality(item);
        } 
        protected new void updateQuality(Item item)
        {
            decrementQuality(item);
            decrementQuality(item);
        }
    }
}
