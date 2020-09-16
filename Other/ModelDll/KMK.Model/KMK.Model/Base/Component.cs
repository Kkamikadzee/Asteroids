namespace KMK.Model.Base
{
    public abstract class Component : IDestroyable
    {
        private IComponentsStorage _parent;

        public Transform Transform => _parent.Transform;

        protected Component(IComponentsStorage parent)
        {
            _parent = parent;
        }
        
        public virtual void Destroy()
        {
            _parent = null;
        }
    }
}