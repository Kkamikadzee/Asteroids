using KMK.Model.ViewInterface;
using View.UI;

namespace Controller.UI
{
    public class LimitedResourceController: IUiViewController
    {
        private ILimitedResource _limitedResource;
        private LimitedResourceView _limitedResourceView;

        public ILimitedResource LimitedResource
        {
            get => _limitedResource;
            set => _limitedResource = value;
        }

        public LimitedResourceView LimitedResourceView
        {
            get => _limitedResourceView;
            set
            {
                _limitedResourceView.Refresh -= UpdateView;
                _limitedResourceView = value;
                _limitedResourceView.Refresh += UpdateView;
            }
        }

        public LimitedResourceController() { }

        public LimitedResourceController(LimitedResourceView limitedResourceView)
        {
            _limitedResourceView = limitedResourceView;
            _limitedResourceView.Refresh += UpdateView;
        }

        public LimitedResourceController(ILimitedResource limitedResource, LimitedResourceView limitedResourceView)
        {
            _limitedResource = limitedResource;

            _limitedResourceView = limitedResourceView;
            _limitedResourceView.Refresh += UpdateView;
        }

        public void UpdateView()
        {
            if (_limitedResource != null && _limitedResourceView != null)
            {
                if(_limitedResourceView.DisplayedAmountResource != _limitedResource.CurrentAmountResource)
                {
                    _limitedResourceView.SetAmountResource(_limitedResource.CurrentAmountResource);
                }
            }
        }
    }
}