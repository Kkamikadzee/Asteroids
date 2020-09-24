using KMK.Model.ViewInterface;
using View.UI;

namespace Controller.UI
{
    public class LimitedResourceLimitedFromAboveController: IUiViewController
    {
        private ILimitedResourceLimitedFromAbove _limitedResource;
        private LimitedResourceLimitedFromAboveView _limitedResourceView;

        public ILimitedResourceLimitedFromAbove LimitedResource
        {
            get => _limitedResource;
            set => _limitedResource = value;
        }

        public LimitedResourceLimitedFromAboveView LimitedResourceView
        {
            get => _limitedResourceView;
            set
            {
                _limitedResourceView.Refresh -= UpdateView;
                _limitedResourceView = value;
                _limitedResourceView.Refresh += UpdateView;
            }
        }

        public LimitedResourceLimitedFromAboveController() { }

        public LimitedResourceLimitedFromAboveController(LimitedResourceLimitedFromAboveView limitedResourceView)
        {
            _limitedResourceView = limitedResourceView;
            _limitedResourceView.Refresh += UpdateView;
        }

        public LimitedResourceLimitedFromAboveController(ILimitedResourceLimitedFromAbove limitedResource, 
            LimitedResourceLimitedFromAboveView limitedResourceView)
        {
            _limitedResource = limitedResource;

            _limitedResourceView = limitedResourceView;
            _limitedResourceView.Refresh += UpdateView;
        }

        public void UpdateView()
        {
            if (_limitedResource != null && _limitedResourceView != null)
            {
                if(_limitedResourceView.DisplayedMaxAmountResource != _limitedResource.MaxAmountResource)
                {
                    _limitedResourceView.SetMaxAmountResource(_limitedResource.MaxAmountResource);
                }
                if(_limitedResourceView.DisplayedAmountResource != _limitedResource.CurrentAmountResource)
                {
                    _limitedResourceView.SetAmountResource(_limitedResource.CurrentAmountResource);
                }
            }
        }    
    }
}