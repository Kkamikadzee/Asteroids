using Convert;
using KMK.Model.Base;
using View.GameObjectView;

namespace Controller.GameObjectController.UpdateViewStrategy
{
    public class UpdateViewStrategyTransform: IUpdateViewStrategy
    {
        private Transform _transformModel;

        public UpdateViewStrategyTransform() { }
        public UpdateViewStrategyTransform(Transform transformModel)
        {
            _transformModel = transformModel;
        }
        
        public void RefreshView(GameObjectView gameObjectView)
        {
            if (!(gameObjectView is ITransformView transformView)) return;
            
            if (!transformView.DisplayedPosition.IsEquivalentTo(_transformModel.Position))
            {
                transformView.MoveTo(_transformModel.Position);
            }
                
            if (!transformView.DisplayedEulerAngles.IsEquivalentTo(_transformModel.EulerAngles))
            {
                transformView.RotateTo(_transformModel.EulerAngles);
            }

            if (!transformView.DisplayedScale.IsEquivalentTo(_transformModel.Scale))
            {
                transformView.ScaleTo(_transformModel.Scale);
            }
        }

        public void RefreshModelData(IComponentsStorage componentsStorage)
        {
            _transformModel = componentsStorage.Transform;
        }
    }
}