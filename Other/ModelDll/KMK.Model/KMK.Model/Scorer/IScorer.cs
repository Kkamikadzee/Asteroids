namespace KMK.Model.Scorer
{
    public interface IScorer
    {
        float CurrentScore { get; }

        void AddScore(float value);
    }
}