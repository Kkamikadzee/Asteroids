using KMK.Models.Base;

namespace KMK.Models.View
{
    public interface IViewFactory
    {
        LimitedResourceView CreateLimitedResource(ILimitedResource limitedResource);
        ProgressIndicatorView CreateProgressIndicator(IProgressIndicator progressIndicator);
        ComponentView CreateComponentView(IComponentsStorage parent);
    }
}