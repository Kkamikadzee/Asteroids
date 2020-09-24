using View.GameObjectView;
using View.GameObjectView.Creator;

namespace KMK.Model.Builder
{
    public class AsteroidsGameObjectViewFactory: IAsteroidsGameObjectViewFactory
    {
        private GameObjectViewCreator _playerCreator;
        private GameObjectViewCreator _asteroidCreator;
        private GameObjectViewCreator _ufoCreator;
        private GameObjectViewCreator _cannonBulletCreator;
        private GameObjectViewCreator _laserBulletCreator;

        public AsteroidsGameObjectViewFactory(GameObjectViewCreator playerCreator,
            GameObjectViewCreator asteroidCreator, GameObjectViewCreator ufoCreator,
            GameObjectViewCreator cannonBulletCreator, GameObjectViewCreator laserBulletCreator)
        {
            _playerCreator = playerCreator;
            _asteroidCreator = asteroidCreator;
            _ufoCreator = ufoCreator;
            _cannonBulletCreator = cannonBulletCreator;
            _laserBulletCreator = laserBulletCreator;
        }
        
        public GameObjectView CreatePlayerView()
        {
            return _playerCreator.Create();
        }

        public GameObjectView CreateAsteroidView()
        {
            return _asteroidCreator.Create();
        }

        public GameObjectView CreateUfoView()
        {
            return _ufoCreator.Create();
        }

        public GameObjectView CreateCannonBulletView()
        {
            return _cannonBulletCreator.Create();
        }

        public GameObjectView CreateLaserBulletView()
        {
            return _laserBulletCreator.Create();
        }
    }
}