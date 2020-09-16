using System;
using Convert;
using KMK.Model.Base;
using KMK.Model.Move;
using View.GameObjectView;

namespace Controller.GameObjectController.UpdateViewStrategy
{
    public class UpdateViewStrategyMutable: IUpdateViewStrategy
    {
        private double _TOLERANCE = 1e-6;
        
        private IVelocityMover _velocityMover;
        
        public UpdateViewStrategyMutable(IVelocityMover velocityMover)
        {
            _velocityMover = velocityMover;
        }
        
        public void RefreshView(GameObjectView gameObjectView)
        {
            if (!(gameObjectView is IMutableView mutableView)) return;

            if (Math.Abs(_velocityMover.Velocity) > _TOLERANCE)
            {
                if (mutableView.DisplayedState != ViewState.Move)
                {
                    mutableView.DisplayedState = ViewState.Move;
                }
            }
            else
            {
                if (mutableView.DisplayedState != ViewState.Stay)
                {
                    mutableView.DisplayedState = ViewState.Stay;
                }
            }
        }

        public void RefreshModelData(IComponentsStorage componentsStorage)
        {
            _velocityMover = componentsStorage.GetComponent<IVelocityMover>();
        }

    }
}