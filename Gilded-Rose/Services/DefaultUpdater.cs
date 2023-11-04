using Gilded_Rose.Model;

namespace Gilded_Rose.Services;

public class DefaultUpdater : BaseItemUpdater
{
    public DefaultUpdater(Item item) : base(item) { }

    public override void Update()
    {
        base.Update();
        Quality--;
    }
}