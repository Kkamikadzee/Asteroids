using UnityEngine;

namespace View.UI
{
    public abstract class LimitedResourceView: UiElement
    {
        protected int _displayedAmountResource;

        public int DisplayedAmountResource => _displayedAmountResource;

        protected LimitedResourceView(Vector3 position, int displayedAmountResource) : base(position)
        {
            _displayedAmountResource = displayedAmountResource;
        }

        public abstract void SetAmountResource(int amountResource);
    }
}