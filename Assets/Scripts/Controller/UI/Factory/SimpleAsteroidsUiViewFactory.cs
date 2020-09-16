using View.UI;

namespace Controller.UI.Factory
{
    public class SimpleAsteroidsUiViewFactory: IAsteroidsUiViewFactory
    {
        
        
        public ScorerView CreateScorerView()
        {
            throw new System.NotImplementedException();
        }

        public ProgressIndicatorView CreateReloadLaserView()
        {
            throw new System.NotImplementedException();
        }

        public LimitedResourceLimitedFromAboveView CreateLaserAmmoView()
        {
            throw new System.NotImplementedException();
        }

        public LimitedResourceView CreateHealthView()
        {
            throw new System.NotImplementedException();
        }
    }
}