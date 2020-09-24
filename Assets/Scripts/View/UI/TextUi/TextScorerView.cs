using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI.TextUi
{
    public class TextScorerView: ScorerView
    {
        private Text _scoreText;

        public override event Action DisconnectFromObserver;
        public override event Action Refresh;

        public TextScorerView(Vector3 position, float displayedScore,
            Text scoreText) : base(position, displayedScore)
        {
            _scoreText = scoreText;
            _scoreText.text = _displayedScore.ToString();
        }

        public override void SetScore(float score)
        {
            _displayedScore = score;
            _scoreText.text = _displayedScore.ToString();
        }
        
        public override void Update(float deltaTime)
        {
            Refresh?.Invoke();
        }

        public override void Destroy()
        {
            DisconnectFromObserver?.Invoke();
            
            UnityEngine.Object.Destroy(_scoreText);
        }
    }
}