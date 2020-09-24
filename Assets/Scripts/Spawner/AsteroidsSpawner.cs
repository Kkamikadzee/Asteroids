using Controller.GameObjectController;
using Controller.GameObjectController.UpdateViewStrategy;
using KMK.Model.Base;
using KMK.Model.Builder;
using Model.Data;
using Model.Factory;

namespace Spawner
{
    public class AsteroidsSpawner: IAsteroidsSpawner
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

        public AsteroidsSpawner(IAsteroidsGameObjectViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public AsteroidsSpawner(IAsteroidsComponentsStorageFactory modelFactory, 
            IAsteroidsGameObjectViewFactory viewFactory)
        {
            _modelFactory = modelFactory;
            _viewFactory = viewFactory;
        }
        
        public GameObjectController SpawnPlayer(Transform transform, Model.Data.PlayerData playerData)
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

        public GameObjectController SpawnAsteroid(Transform transform, AsteroidData asteroidData)
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

        public GameObjectController SpawnUfo(Transform transform, UfoData ufoData)
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

        public GameObjectController SpawnCannonBullet(Transform transform, BulletData bulletData)
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

        public GameObjectController SpawnLaserBullet(Transform transform, BulletData bulletData)
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