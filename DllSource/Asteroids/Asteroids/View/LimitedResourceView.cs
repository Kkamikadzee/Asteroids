using KMK.Models.Updater;

namespace KMK.Models.View
{
    public abstract class LimitedResourceView: IUpdatable
    {
        protected ILimitedResource _limitedResource;

        protected LimitedResourceView(ILimitedResource limitedResource)
        {
            _limitedResource = limitedResource;
        }
        
        public abstract void Update(float deltaTime);
    }
}