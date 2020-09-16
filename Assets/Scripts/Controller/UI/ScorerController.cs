using KMK.Model.Scorer;
using View.UI;

namespace Controller.UI
{
    public class ScorerController: IUiViewController
    {
        private Scorer _scorer;
        private TimeForfeitScore _forfeitScore;
        private ScorerView _scorerView;

        public Scorer Scorer
        {
            get => _scorer;
            set
            {
                _scorer = value;
                _forfeitScore.Scorer = value;
            }
        }

        public TimeForfeitScore ForfeitScore
        {
            get => _forfeitScore;
            set
            {
                _forfeitScore = value;
                _forfeitScore.Scorer = _scorer;
            }
        }

        public ScorerView ScorerView
        {
            get => _scorerView;
            set
            {
                _scorerView.Refresh -= UpdateView;
                _scorerView = value;
                _scorerView.Refresh += UpdateView;
            }
        }

        public ScorerController() { }

        public ScorerController(Scorer scorer, TimeForfeitScore forfeitScore, ScorerView scorerView)
        {
            _scorer = scorer;
            
            _forfeitScore = forfeitScore;
            _forfeitScore.Scorer = scorer;
            
            _scorerView = scorerView;
            _scorerView.Refresh += UpdateView;
        }
        
        public void UpdateView()
        {
            if(_scorerView.DisplayedScore != _scorer.CurrentScore)
            {
                _scorerView.SetScore(_scorer.CurrentScore);
            }
        }
    }
}