using Controller.GameObjectController;
using Controller.GameObjectController.UpdateViewStrategy;
using KMK.Model.Base;
using KMK.Model.Builder;
using Model.Data;
using Model.Factory;

namespace Spawner
{
    public class GameObjectControllerCreator: IGameObjectControllerCreator
    {
        private IAsteroidsComponentsStorageFactory _modelFactory;
        private IAsteroidsGameObjectViewFactory _viewFactory;

        public IAsteroidsComponentsStorageFactory ModelFactory
        {
            get => _modelFactory;
            set => _modelFactory = value;
        }

        public IAsteroidsGameObjectViewFactory ViewFactoty
        {
            get => _viewFactory;
            set => _viewFactory = value;
        }

        public GameObjectControllerCreator(IAsteroidsGameObjectViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public GameObjectControllerCreator(IAsteroidsComponentsStorageFactory modelFactory, 
            IAsteroidsGameObjectViewFactory viewFactory)
        {
            _modelFactory = modelFactory;
            _viewFactory = viewFactory;
        }
        
        public GameObjectController CreatePlayer(Transform transform, Model.Data.PlayerData playerData)
        {
            var model = _modelFactory.CreatePlayer(transform, playerData);
            var view = _viewFactory.CreatePlayerView();
            var controller = new GameObjectController(new IUpdateViewStrategy[]
            {
                new UpdateViewStrategyTransform(), new UpdateViewStrategyMutable()
            })
            {
                GameObjectModel = model, 
                GameObjectView = view
            };


            return controller;
        }

        public GameObjectController CreateAsteroid(Transform transform, AsteroidData asteroidData)
        {
            var model = _modelFactory.CreateAsteroid(transform, asteroidData);
            var view = _viewFactory.CreateAsteroidView();
            var controller =
                new GameObjectController(new IUpdateViewStrategy[] 
                    {new UpdateViewStrategyTransform()})
                {
                    GameObjectModel = model, 
                    GameObjectView = view
                };
            
            return controller;
        }

        public GameObjectController CreateUfo(Transform transform, UfoData ufoData)
        {
            var model = _modelFactory.CreateUfo(transform, ufoData);
            var view = _viewFactory.CreateUfoView();
            var controller =
                new GameObjectController(new IUpdateViewStrategy[] 
                    {new UpdateViewStrategyTransform()})
                {
                    GameObjectModel = model, 
                    GameObjectView = view
                };
            
            return controller;
        }

        public GameObjectController CreateCannonBullet(Transform transform, BulletData bulletData)
        {
            var model = _modelFactory.CreateBullet(transform, bulletData);
            var view = _viewFactory.CreateCannonBulletView();
            var controller =
                new GameObjectController(new IUpdateViewStrategy[] 
                    {new UpdateViewStrategyTransform()})
                {
                    GameObjectModel = model, 
                    GameObjectView = view
                };
            
            return controller;
        }

        public GameObjectController CreateLaserBullet(Transform transform, BulletData bulletData)
        {
            var model = _modelFactory.CreateBullet(transform, bulletData);
            var view = _viewFactory.CreateLaserBulletView();
            var controller =
                new GameObjectController(new IUpdateViewStrategy[] 
                    {new UpdateViewStrategyTransform()})
                {
                    GameObjectModel = model, 
                    GameObjectView = view
                };
            
            return controller;
        }
    }
}