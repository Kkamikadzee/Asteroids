using Controller.GameObjectController;
using KMK.Model.Builder;
using Spawner;

namespace Controller.Game
{
    public class ViewChanger
    {
        private AsteroidsSpawner _spawner;
        private AsteroidsControllers _controllers;
        private IAsteroidsGameObjectViewFactory _newViewFactoty;

        public ViewChanger(AsteroidsSpawner spawner, AsteroidsControllers controllers,
            IAsteroidsGameObjectViewFactory newViewFactoty)
        {
            _spawner = spawner;
            _controllers = controllers;
            _newViewFactoty = newViewFactoty;
        }

        public void ChangeView()
        {
            var tmpView = _spawner.ViewFactoty;
            _spawner.ViewFactoty = _newViewFactoty;
            _newViewFactoty = tmpView;

            _controllers.PlayerController.GameObjectView = _newViewFactoty.CreatePlayerView();

            foreach (var controller in _controllers.AsteroidControllers.Controllers)
            {
                controller.GameObjectView = _newViewFactoty.CreateAsteroidView();
            }
            
            foreach (var controller in _controllers.UfoControllers.Controllers)
            {
                controller.GameObjectView = _newViewFactoty.CreateUfoView();
            }
            
            foreach (var controller in _controllers.CannonBulletControllers.Controllers)
            {
                controller.GameObjectView = _newViewFactoty.CreateCannonBulletView();
            }
            
            foreach (var controller in _controllers.LaserControllers.Controllers)
            {
                controller.GameObjectView = _newViewFactoty.CreateLaserBulletView();
            }
            
            _newViewFactoty = tmpView;
        }
    }
}