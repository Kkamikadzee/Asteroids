using System;
using KMK.Model.Updater;

namespace KMK.Model.Scorer
{
    public class TimeForfeitScore: IUpdatable
    {
        private IScorer _scorer;

        private float _forfeitScoreInSecond;

        public IScorer Scorer
        {
            get => _scorer;
            set => _scorer = value;
        }

        public float ForfeitScoreInSecond
        {
            get => _forfeitScoreInSecond;
            set => _forfeitScoreInSecond = value;
        }

        public event Action DisconnectFromObserver;

        public TimeForfeitScore(IScorer scorer, float forfeitScoreInSecon)
        {
            _scorer = scorer;
            _forfeitScoreInSecond = forfeitScoreInSecon;
        }
        
        public void Update(float deltaTime)
        {
            if (_scorer.CurrentScore == 0)
            {
                return;
            }
            if (_scorer.CurrentScore + _forfeitScoreInSecond * deltaTime < 0)
            {
                _scorer.AddScore(_scorer.CurrentScore);
            }
            _scorer.AddScore(_forfeitScoreInSecond * deltaTime);
        }
    }
}