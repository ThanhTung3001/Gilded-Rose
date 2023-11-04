using Gilded_Rose.Model;
using Gilded_Rose.Services;

namespace Gilded_Rose;

public class GildedRose
{
    private readonly IList<Item> _items;

    private readonly Dictionary<string, Type> _itemUpdaters = new Dictionary<string, Type>(StringComparer.CurrentCultureIgnoreCase)
    {
        { "Aged Brie", typeof(AgedBrieUpdater) },
        { "Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassUpdater) },
        { "Conjured", typeof(ConjuredUpdater) },
        { "Default", typeof(DefaultUpdater) },
        { "Sulfuras, Hand of Ragnaros", typeof(SulfurasUpdater) }
    }; // Define type of object and mapping with service function update

    public GildedRose(IList<Item> items)
    {
        this._items = items;
    }

    public void UpdateItems()
    {
        foreach (var item in _items)
        {
            var updaterType = _itemUpdaters.FirstOrDefault
                                  (u => item.Name.StartsWith(u.Key, StringComparison.CurrentCultureIgnoreCase)).Value
                              ?? typeof(DefaultUpdater); // Base name of object get type and use table of object
            var updaterConstructor = updaterType.GetConstructor(new [] { typeof(Item) });
            if (updaterConstructor == null) continue;
            BaseItemUpdater updater = (BaseItemUpdater)updaterConstructor.Invoke(new object[] { item }); //Pass param to object base object contructor
            updater.Update();
        }
    }
}
