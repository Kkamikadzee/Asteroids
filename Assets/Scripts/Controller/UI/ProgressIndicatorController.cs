using KMK.Model.ViewInterface;
using View.UI;

namespace Controller.UI
{
    public class ProgressIndicatorController: IUiViewController
    {
        private IProgressIndicator _progressIndicator;
        private ProgressIndicatorView _progressIndicatorView;

        public IProgressIndicator ProgressIndicator
        {
            get => _progressIndicator;
            set => _progressIndicator = value;
        }

        public ProgressIndicatorView ProgressIndicatorView
        {
            get => _progressIndicatorView;
            set
            {
                _progressIndicatorView.Refresh -= UpdateView;
                _progressIndicatorView = value;
                _progressIndicatorView.Refresh += UpdateView;
            }
        }

        public ProgressIndicatorController() { }
        
        public ProgressIndicatorController(ProgressIndicatorView progressIndicatorView)
        {
            _progressIndicatorView = progressIndicatorView;
            _progressIndicatorView.Refresh += UpdateView;
        }
        
        public ProgressIndicatorController(IProgressIndicator progressIndicator,
            ProgressIndicatorView progressIndicatorView)
        {
            _progressIndicator = progressIndicator;
            
            _progressIndicatorView = progressIndicatorView;
            _progressIndicatorView.Refresh += UpdateView;
        }

        public void UpdateView()
        {
            if (_progressIndicator != null && _progressIndicatorView != null)
            {
                if(_progressIndicatorView.DisplayedProgress != _progressIndicator.Progress)
                {
                    _progressIndicatorView.SetProgress(_progressIndicator.Progress);
                }
            }

        }
    }
}