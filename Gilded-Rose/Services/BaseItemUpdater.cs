using Gilded_Rose.Model;

namespace Gilded_Rose.Services;

public abstract class BaseItemUpdater //Define base class service for updater => use abstraction oop
{
    private readonly Item _item;

    protected BaseItemUpdater(Item item)
    {
        this._item = item;
    }

    protected int Quality
    {
        get => _item.Quality;
        set
        {
            _item.Quality = Math.Max(0, value);
            _item.Quality = Math.Min(50, _item.Quality); //Limit value for Item quality 
        }
    }

    protected int SellIn
    {
        get => _item.SellIn;
        private set => _item.SellIn = value;
    }

    public virtual void Update()
    {
        SellIn--;
    }
}