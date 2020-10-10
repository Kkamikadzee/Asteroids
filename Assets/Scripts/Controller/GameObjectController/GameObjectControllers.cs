using Other;

namespace Controller.GameObjectController
{
    public class GameObjectControllers: IAmountObjectsOnField
    {
        private GameObjectController _playerController;
        private GameObjectControllerStorage _asteroidControllers;
        private GameObjectControllerStorage _ufoControllers;
        private GameObjectControllerStorage _cannonBulletControllers;
        private GameObjectControllerStorage _laserControllers;

        public int AmountPlayers => _playerController != null ? 1 : 0;

        public int AmountAsteroids => _asteroidControllers.Controllers.Count;

        public int AmountUfo => _ufoControllers.Controllers.Count;
        
        public GameObjectControllers()
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
            _playerController?.Destroy();
            
            _asteroidControllers.Clear();
            _ufoControllers.Clear();
            _cannonBulletControllers.Clear();
            _laserControllers.Clear();
        }
    }
}