using Gilded_Rose.Model;

namespace Gilded_Rose.Services;

public class ConjuredUpdater : BaseItemUpdater
{
    public ConjuredUpdater(Item item) : base(item) { }

    public override void Update()
    {
        base.Update();
        Quality -= 2;
    }
}