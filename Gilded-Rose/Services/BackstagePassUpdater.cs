using Gilded_Rose.Model;

namespace Gilded_Rose.Services;

public class BackstagePassUpdater : BaseItemUpdater
{
    public BackstagePassUpdater(Item item) : base(item) { }

    public override void Update()
    {
        base.Update();
        Quality =
            (SellIn < 0) ? 0 :
            (SellIn <= 5) ? Quality += 3 :
            (SellIn <= 10) ? Quality += 2 :
            ++Quality;
    }
}