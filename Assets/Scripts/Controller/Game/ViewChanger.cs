using Controller.GameObjectController;
using KMK.Model.Builder;
using Spawner;
using Update;

namespace Controller.Game
{
    public class ViewChanger
    {
        private Updater _updater;
        private GameObjectControllerCreator _spawner;
        private GameObjectControllers _controllers;
        private IAsteroidsGameObjectViewFactory _newViewFactoty;

        public ViewChanger(Updater updater, GameObjectControllerCreator spawner, GameObjectControllers controllers,
            IAsteroidsGameObjectViewFactory newViewFactoty)
        {
            _updater = updater;
            _spawner = spawner;
            _controllers = controllers;
            _newViewFactoty = newViewFactoty;
        }

        public void ChangeView()
        {
            _updater.Disable();
            
            if (_controllers.PlayerController != null)
            {
                _controllers.PlayerController.GameObjectView.Destroy();
                _controllers.PlayerController.GameObjectView = _newViewFactoty.CreatePlayerView();
            }

            foreach (var controller in _controllers.AsteroidControllers.Controllers)
            {
                controller.GameObjectView.Destroy();
                controller.GameObjectView = _newViewFactoty.CreateAsteroidView();
            }
            
            foreach (var controller in _controllers.UfoControllers.Controllers)
            {
                controller.GameObjectView.Destroy();
                controller.GameObjectView = _newViewFactoty.CreateUfoView();
            }
            
            foreach (var controller in _controllers.CannonBulletControllers.Controllers)
            {
                controller.GameObjectView.Destroy();
                controller.GameObjectView = _newViewFactoty.CreateCannonBulletView();
            }
            
            foreach (var controller in _controllers.LaserControllers.Controllers)
            {
                controller.GameObjectView.Destroy();
                controller.GameObjectView = _newViewFactoty.CreateLaserBulletView();
            }

            var tmpView = _spawner.ViewFactoty;
            _spawner.ViewFactoty = _newViewFactoty;
            _newViewFactoty = tmpView;

            _updater.Enable();
        }
    }
}