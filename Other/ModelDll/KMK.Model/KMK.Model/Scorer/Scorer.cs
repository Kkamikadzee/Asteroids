namespace KMK.Model.Scorer
{
    public class Scorer: IScorer
    {
        private float _currentScore;

        public float CurrentScore => _currentScore;

        public Scorer(float score)
        {
            _currentScore = score;
        }
        
        public void AddScore(float value)
        {
            _currentScore += value;
        }
    }
}