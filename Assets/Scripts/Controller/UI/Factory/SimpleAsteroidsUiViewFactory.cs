using Update;
using View.UI;
using View.UI.ImageUi;
using View.UI.TextUi;

namespace Controller.UI.Factory
{
    public class SimpleAsteroidsUiViewFactory: IAsteroidsUiViewFactory
    {
        private UnityAsteroidsUi _unityAsteroidsUi;
        private IUpdater _updater;

        public SimpleAsteroidsUiViewFactory(UnityAsteroidsUi unityAsteroidsUi, IUpdater updater)
        {
            _unityAsteroidsUi = unityAsteroidsUi;
            _updater = updater;
        }
        
        public ScorerView CreateScorerView()
        {
            var view = new TextScorerView(_unityAsteroidsUi.ScoreText.transform.position,
                0f, _unityAsteroidsUi.ScoreText);
            
            _updater.ViewObservable.AddUpdaterObserver(
                UpdateObserverCreator.GetObserver(view, _updater.ViewObservable));

            return view;
        }

        public ProgressIndicatorView CreateReloadLaserView()
        {
            var view = new ImageProgressIndicatorView(_unityAsteroidsUi.ReloadLaserImage.transform.position,
                0f, _unityAsteroidsUi.ReloadLaserImage,
                _unityAsteroidsUi.GradientForReloadLaserView);
            
            _updater.ViewObservable.AddUpdaterObserver(
                UpdateObserverCreator.GetObserver(view, _updater.ViewObservable));

            return view;
        }

        public LimitedResourceLimitedFromAboveView CreateLaserAmmoView()
        {
            var view = new ImageLimitedResourceLimitedFromAboveView(_unityAsteroidsUi.LaserAmmoStorage.transform.position,
                0, 0, _unityAsteroidsUi.LaserAmmoPrefab,
                _unityAsteroidsUi.LaserAmmoStorage.transform);
            
            _updater.ViewObservable.AddUpdaterObserver(
                UpdateObserverCreator.GetObserver(view, _updater.ViewObservable));

            return view;
        }

        public LimitedResourceView CreateHealthView()
        {
            var view = new ImageLimitedResourceView(_unityAsteroidsUi.HealthStorage.transform.position,
                0, _unityAsteroidsUi.HealthPrefab, _unityAsteroidsUi.HealthStorage.transform);
            
            _updater.ViewObservable.AddUpdaterObserver(
                UpdateObserverCreator.GetObserver(view, _updater.ViewObservable));

            return view;
        }
    }
}