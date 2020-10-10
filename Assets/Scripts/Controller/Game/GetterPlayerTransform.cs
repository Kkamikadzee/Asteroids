using Controller.GameObjectController;
using KMK.Model.Base;

namespace Controller.Game
{
    public class GetterPlayerTransform
    {
        private GameObjectControllers _controllers;

        public Transform PlayerTransform => _controllers?.PlayerController.GameObjectModel.Transform;

        public GetterPlayerTransform(GameObjectControllers controllers)
        {
            _controllers = controllers;
        }
    }
}