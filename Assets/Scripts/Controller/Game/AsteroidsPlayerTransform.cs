using Controller.GameObjectController;
using KMK.Model.Base;

namespace Controller.Game
{
    public class AsteroidsPlayerTransform
    {
        private AsteroidsControllers _controllers;

        public Transform PlayerTransform => _controllers.PlayerController?.GameObjectModel.Transform;

        public AsteroidsPlayerTransform(AsteroidsControllers controllers)
        {
            _controllers = controllers;
        }
    }
}