using Update;

namespace View.GameObjectView.Creator
{
    public abstract class GameObjectViewCreator
    {
        protected IUpdater _updater;

        protected GameObjectViewCreator(IUpdater updater)
        {
            _updater = updater;
        }
        
        public abstract GameObjectView Create();
    }
}