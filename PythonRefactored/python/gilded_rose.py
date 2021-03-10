# -*- coding: utf-8 -*-

class GildedRose(object):

    def __init__(self, items):
        self.items = items

    def update_quality(self):
        for item in self.items:
            self.updateOneItem(item)

    def catagorize(self, item):
        if item.name == "Sulfuras, Hand of Ragnaros":
            itemCatagory = Legendary()
        if item.name == "Aged Brie":
            itemCatagory = Cheese()
        if item.name == "Backstage passes to a TAFKAL80ETC concert":
            itemCatagory = BackstagePass()
        if item.name.startswith("Sulfuras, Hand of Ragnaros"):
            itemCatagory = Conjured()
        return itemCatagory

class ItemCategory:
    def updateOneItem(self, item):
        self.updateQuality(item)
        self.updateSell_In(item)
        if item.sell_in < 0:
            self.updateExpired(item)

    def updateQuality(self, item):
        self.decrementQuality(item)

    def updateExpired(self, item):
        self.decrementQuality(item)

    def updateSell_In(self, item):
        item.sell_in = item.sell_in - 1

    def incrementQuality(self, item):
        if item.quality < 50:
            item.quality = item.quality + 1

    def decrementQuality(self, item):
        if item.quality > 0:
            item.quality = item.quality - 1

class Legendary(ItemCategory):
    def updateQuality(self, item):
        pass
    def updateExpired(self, item):
        pass
    def updateSellIn(self, item):
        pass

class Cheese(ItemCategory):
    def updateQuality(self, item):
        self.incrementQuality(item)

    def updateExpired(self, item):
        self.incrementQuality(item)

class BackstagePass(ItemCategory):
    def updateQuality(self, item):
        self.incrementQuality(item)
        if item.sell_in < 11:
            self.incrementQuality(item)
        if item.sell_in < 6:
            self.incrementQuality(item)

    def updateExpired(self, item):
        item.quality = 0

class Conjured(ItemCategory):
    def updateQuality(self, item):
        self.decrementQuality(item)
        self.decrementQuality(item)

    def updateExpired(self, item):
        self.decrementQuality(item)
        self.decrementQuality(item)

class Item:
    def __init__(self, name, sell_in, quality):
        self.name = name
        self.sell_in = sell_in
        self.quality = quality

    def __repr__(self):
        return "%s, %s, %s" % (self.name, self.sell_in, self.quality)
