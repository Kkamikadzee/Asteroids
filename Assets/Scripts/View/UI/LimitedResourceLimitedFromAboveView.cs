using UnityEngine;

namespace View.UI
{
    public abstract class LimitedResourceLimitedFromAboveView: LimitedResourceView
    {
        protected int _displayedMaxAmountResource;

        public int DisplayedMaxAmountResource => _displayedMaxAmountResource;

        protected LimitedResourceLimitedFromAboveView(Vector3 position, int displayedAmountResource,
            int displayedMaxAmountResource) : base(position, displayedAmountResource)
        {
            
        }

        public abstract void SetMaxAmountResource(int maxAmountResource);
    }
}