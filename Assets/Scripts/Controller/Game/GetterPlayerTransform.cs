using Controller.GameObjectController;
using KMK.Model.Base;

namespace Controller.Game
{
    public class GetterPlayerTransform
    {
        private GameObjectControllers _controllers;

        public Transform PlayerTransform
        {
            get
            {
                if (_controllers.PlayerController == null)
                {
                    return null;
                }
                else if (_controllers.PlayerController.GameObjectModel == null)
                {
                    return null;
                }
                return _controllers.PlayerController.GameObjectModel.Transform;
            }
        }

        public GetterPlayerTransform(GameObjectControllers controllers)
        {
            _controllers = controllers;
        }
    }
}