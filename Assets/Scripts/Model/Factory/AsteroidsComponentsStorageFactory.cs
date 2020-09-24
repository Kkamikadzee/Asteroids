using Controller.Game;
using KMK.Model.Base;
using KMK.Model.Builder;
using KMK.Model.Other.Rectangle;
using Model.Data;
using Model.Director;

namespace Model.Factory
{
    public class AsteroidsComponentsStorageFactory: IAsteroidsComponentsStorageFactory
    {
        private ComponentsStorageBuilder _playerBuilder;
        private ComponentsStorageBuilder _asteroidBuilder;
        private ComponentsStorageBuilder _ufoBuilder;
        private ComponentsStorageBuilder _bulletBuilder;

        private PlayerComponentsStorageDirector _playerDirector;
        private AsteroidComponentsStorageDirector _asteroidDirector;
        private UfoComponentsStorageDirector _ufoDirector;
        private BulletComponentsStorageDirector _bulletDirector;

        public AsteroidsComponentsStorageFactory(Rectangle boundary, AsteroidsPlayerTransform playerTransform,
            ComponentsStorageBuilder playerBuilder, ComponentsStorageBuilder asteroidBuilder,
            ComponentsStorageBuilder ufoBuilder, ComponentsStorageBuilder bulletBuilder)
        {
            _playerDirector = new PlayerComponentsStorageDirector(boundary);
            _asteroidDirector = new AsteroidComponentsStorageDirector(boundary);
            _ufoDirector = new UfoComponentsStorageDirector(boundary, playerTransform);
            _bulletDirector = new BulletComponentsStorageDirector();

            _playerBuilder = playerBuilder;
            _asteroidBuilder = asteroidBuilder;
            _ufoBuilder = ufoBuilder;
            _bulletBuilder = bulletBuilder;
        }
        
        public IComponentsStorage CreatePlayer(Transform transform, Data.PlayerData data)
        {
            _playerDirector.Construct(_playerBuilder, transform, data);
            return _playerBuilder.GetIComponentsStorage();
        }

        public IComponentsStorage CreateAsteroid(Transform transform, AsteroidData data)
        {
            _asteroidDirector.Construct(_asteroidBuilder, transform, data);
            return _asteroidBuilder.GetIComponentsStorage();
        }

        public IComponentsStorage CreateUfo(Transform transform, UfoData data)
        {
            _ufoDirector.Construct(_ufoBuilder, transform, data);
            return _ufoBuilder.GetIComponentsStorage();
        }

        public IComponentsStorage CreateBullet(Transform transform, BulletData data)
        {
            _bulletDirector.Construct(_bulletBuilder, transform, data);
            return _bulletBuilder.GetIComponentsStorage();
        }
    }
}