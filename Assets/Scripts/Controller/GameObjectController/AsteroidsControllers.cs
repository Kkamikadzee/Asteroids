namespace Controller.GameObjectController
{
    public class AsteroidsControllers
    {
        private GameObjectController _playerController;
        private GameObjectControllerStorage _asteroidControllers;
        private GameObjectControllerStorage _ufoControllers;
        private GameObjectControllerStorage _cannonBulletControllers;
        private GameObjectControllerStorage _laserControllers;

        public AsteroidsControllers()
        {
            _asteroidControllers = new GameObjectControllerStorage();
            _ufoControllers = new GameObjectControllerStorage();
            _cannonBulletControllers = new GameObjectControllerStorage();
            _laserControllers = new GameObjectControllerStorage();
        }

        public GameObjectController PlayerController
        {
            get => _playerController;
            set => _playerController = value;
        }

        public GameObjectControllerStorage AsteroidControllers => _asteroidControllers;

        public GameObjectControllerStorage UfoControllers => _ufoControllers;

        public GameObjectControllerStorage CannonBulletControllers => _cannonBulletControllers;

        public GameObjectControllerStorage LaserControllers => _laserControllers;

        public void Clear()
        {
            _playerController.DestroyAll();
            
            _asteroidControllers.Clear();
            _ufoControllers.Clear();
            _cannonBulletControllers.Clear();
            _laserControllers.Clear();
        }
    }
}