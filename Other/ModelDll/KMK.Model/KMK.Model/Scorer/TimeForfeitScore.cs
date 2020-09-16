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

        public event Action DisconnectFromObserver; // TODO: Сомнительная нужда в этой событие у этого класса

        public TimeForfeitScore(IScorer scorer, float forfeitScoreInSecon)
        {
            _scorer = scorer;
            _forfeitScoreInSecond = forfeitScoreInSecon;
        }
        
        public void Update(float deltaTime)
        {
            _scorer.AddScore(_forfeitScoreInSecond * deltaTime);
        }
    }
}