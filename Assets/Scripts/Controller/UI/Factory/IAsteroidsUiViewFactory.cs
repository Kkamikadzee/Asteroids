using View.UI;

namespace Controller.UI.Factory
{
    public interface IAsteroidsUiViewFactory
    {
        ScorerView CreateScorerView();
        ProgressIndicatorView CreateReloadLaserView();
        LimitedResourceLimitedFromAboveView CreateLaserAmmoView();
        LimitedResourceView CreateHealthView();
    }
}