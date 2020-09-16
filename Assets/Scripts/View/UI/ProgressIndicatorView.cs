using UnityEngine;

namespace View.UI
{
    public abstract class ProgressIndicatorView: UiElement
    {
        protected float _displayedProgress;

        public float DisplayedProgress => _displayedProgress;

        protected ProgressIndicatorView(Vector3 position, float displayedProgress) : base(position)
        {
            _displayedProgress = displayedProgress;
        }

        public abstract void SetProgress(float progress);
    }
}