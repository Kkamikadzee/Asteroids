using System;
using KMK.Model.Base;

namespace KMK.Model.Scorer
{
    public class ScoreGiver: Component
    {
        private float _amountScore;

        public event Action<float> Give;
        
        public ScoreGiver(IComponentsStorage parent, float amountScore) : base(parent)
        {
            _amountScore = amountScore;
        }

        public void GiveScore()
        {
            Give?.Invoke(_amountScore);
        }

        public override void Destroy()
        {
            base.Destroy();
            
            GiveScore();
        }
    }
}