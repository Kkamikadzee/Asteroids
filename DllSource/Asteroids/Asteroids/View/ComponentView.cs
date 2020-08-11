using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.View
{
    public abstract class ComponentView: Component, IUpdatable
    {
        protected ComponentView(IComponentsStorage parent) : base(parent) { }

        public abstract void Update(float deltaTime);
    }
}