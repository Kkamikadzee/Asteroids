using KMK.Models.Adapter;
using KMK.Models.Updater;

namespace KMK.Models.View
{
    public abstract class ProgressIndicatorView: IUpdatable
    {
        protected IProgressIndicator _progressIndicator;

        protected ProgressIndicatorView(IProgressIndicator progressIndicator)
        {
            _progressIndicator = progressIndicator;
        }

        public abstract void Update(float deltaTime);
    }
}