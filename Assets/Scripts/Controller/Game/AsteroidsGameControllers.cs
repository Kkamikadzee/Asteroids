using Controller.GameObjectController;
using Controller.UI;
using Input;
using KMK.Model.Collision;
using Spawner.ChildrenSpawner;

namespace Controller.Game
{
    public class AsteroidsGameControllers
    {
        private AsteroidsUiControllersStorage _uiControllersStorage;
        private AsteroidsControllers _controllers;
        private PlayerInputController _playerInputController;
        private AsteroidChildrenSpawner _childrenSpawner;
        private AsteroidsLevelController _levelController;
        private AsteroidsPlayerTransform _playerTransform;
        private CollisionChecker _collisionChecker;
        private HealthDieController _healthDieController;
        private HealthScoreController _healthScoreController;
        private ViewChanger _viewChanger;

        public AsteroidsUiControllersStorage UiControllersStorage => _uiControllersStorage;
        public AsteroidsControllers Controllers => _controllers;
        public PlayerInputController PlayerInputController => _playerInputController;
        public AsteroidChildrenSpawner ChildrenSpawner => _childrenSpawner;
        public AsteroidsLevelController LevelController => _levelController;
        public AsteroidsPlayerTransform PlayerTransform => _playerTransform;
        public CollisionChecker CollisionChecker => _collisionChecker;
        public HealthDieController HealthDieController => _healthDieController;
        public HealthScoreController HealthScoreController => _healthScoreController;
        public ViewChanger ViewChanger => _viewChanger;

        public AsteroidsGameControllers(AsteroidsUiControllersStorage uiControllersStorage,
            AsteroidsControllers controllers, PlayerInputController playerInputController,
            AsteroidChildrenSpawner childrenSpawner, AsteroidsLevelController levelController,
            AsteroidsPlayerTransform playerTransform, CollisionChecker collisionChecker,
            HealthDieController healthDieController, HealthScoreController healthScoreController,
            ViewChanger viewChanger)
        {
            _uiControllersStorage = uiControllersStorage;
            _controllers = controllers;
            _playerInputController = playerInputController;
            _childrenSpawner = childrenSpawner;
            _levelController = levelController;
            _playerTransform = playerTransform;
            _collisionChecker = collisionChecker;
            _healthDieController = healthDieController;
            _healthScoreController = healthScoreController;
            _viewChanger = viewChanger;
        }
    }
}