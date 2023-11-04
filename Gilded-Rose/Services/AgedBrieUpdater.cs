using Gilded_Rose.Model;

namespace Gilded_Rose.Services;

public class AgedBrieUpdater : BaseItemUpdater //use inheritance oop
{
    public AgedBrieUpdater(Item item) : base(item) { }

    public override void Update()
    {
        base.Update();
        Quality++;
    }
}