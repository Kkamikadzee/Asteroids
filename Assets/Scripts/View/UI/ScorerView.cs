using UnityEngine;

namespace View.UI
{
    public abstract class ScorerView: UiElement
    {
        protected float _displayedScore;

        public float DisplayedScore => _displayedScore;

        protected ScorerView(Vector3 position, float displayedScore) : base(position)
        {
            _displayedScore = displayedScore;
        }

        public abstract void SetScore(float score);
    }
}