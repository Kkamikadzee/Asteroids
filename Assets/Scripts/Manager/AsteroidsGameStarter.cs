using Audio.Effects;
using Controller.Game;
using Controller.GameObjectController;
using Controller.UI;
using Controller.UI.Factory;
using Input;
using KMK.Model.Adapter;
using KMK.Model.Builder;
using KMK.Model.Collision;
using KMK.Model.Destroyer;
using KMK.Model.Other;
using KMK.Model.Other.Rectangle;
using KMK.Model.Scorer;
using Model.Builder;
using Model.Data;
using Model.Factory;
using Spawner;
using Spawner.ChildrenSpawner;
using UnityEngine;
using Update;
using View.GameObjectView.CreatorFactory.Polygon;
using View.GameObjectView.CreatorFactory.Sprite;
using View.UI;
using Vector3 = KMK.Model.Base.Vector3;

namespace Manager
{
    public class AsteroidsGameStarter: MonoBehaviour
    {
        [SerializeField] private int _startAmountHealth;
        [SerializeField] private float _respawnTime;

        [SerializeField] private float _oneHealthScore;

        [SerializeField] private float _startScore;
        [SerializeField] private float _forfeitScoreInSecond;

        [SerializeField] private float _ufoSpawnProbability;
    
        [SerializeField] private Camera _camera;
    
        [SerializeField] private Updater _updater;

        [SerializeField] private UnityAsteroidsUi _asteroidsUi;
    
        [SerializeField] private AsteroidsDataStorage _dataStorage;

        [SerializeField] private SpriteGameObjectViewCreatorFactory _spriteViewCreator;
        [SerializeField] private PolygonGameObjectViewCreatorFactory _polygonViewCreator;

        [SerializeField] private EffectsSources _effectsSources;
    
        private Rectangle _border;

        private Health _health;
        private Scorer _scorer;
        private TimeForfeitScore _forfeitScore;
        private ScorerController _scorerController;  //TODO: Нигде не хранится и мб стоит в игре работать через неё, а не через Scorer

        private SystemInput _systemInput;
        private PlayerInputController _playerInputController;
    
        private SimpleAsteroidsUiViewFactory _uiViewFactory;
        private AsteroidsUiControllersStorage _uiControllers;
    
        private AsteroidsGameObjectViewFactory _spriteViewFactory;
        private AsteroidsGameObjectViewFactory _polygonViewFactory;

        private UpdatableDestroyer _modelDestroyer;
        private CollisionChecker _collisionChecker;
        private AsteroidsComponentsStorageFactory _modelsFactory;

        private GameObjectControllers _controllers;

        private GameObjectControllerCreator _controllerCreator;

        private ModelSoundEffectsBinder _soundEffectsBinder;
    
        private GameObjectSpawner _spawner;

        private GetterPlayerTransform _playerTransform;
    
        private AsteroidsLevelController _levelController;
    
        private AsteroidChildrenSpawner _childrenSpawner;
        private AsteroidChildrenSpawner _asteroidChildrenSpawner;
        private CannonChildrenSpawner _cannonChildrenSpawner;
        private LaserChildrenSpawner _laserChildrenSpawner;
    
        private HealthDieController _healthDieController;
        private HealthScoreController _healthScoreController;
        private ViewChanger _viewChanger;
    
        private void CreateHealthAndScorer()
        {
            _health = new Health(_startAmountHealth);
        
            _scorer = new Scorer(_startScore);
            _forfeitScore = new TimeForfeitScore(_scorer, _forfeitScoreInSecond);
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver //TODO: у updater'a создать методы, которые будут выполнять функционал создателя обсервера
                (_forfeitScore, _updater.OtherUpdateObservable));
        }
    
        private void CreateBorder()
        {
            _border = new Rectangle(_camera.orthographicSize * _camera.aspect * 2f, _camera.orthographicSize * 2f, Vector3.Zero);
        }
    
        private void CreatePlayerInputController()
        { 
            _systemInput = new SystemInput();
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_systemInput, _updater.OtherUpdateObservable));

            _playerInputController = new PlayerInputController(_systemInput);
        }

        private void CreateUi()
        {
            _uiViewFactory = new SimpleAsteroidsUiViewFactory(_asteroidsUi, _updater);
        
            _uiControllers = new AsteroidsUiControllersStorage(
                new ScorerController(_scorer, _forfeitScore,
                    _uiViewFactory.CreateScorerView()),
                
                new ProgressIndicatorController(_uiViewFactory.CreateReloadLaserView()), 
                new LimitedResourceLimitedFromAboveController(_uiViewFactory.CreateLaserAmmoView()),
                
                new LimitedResourceController(
                    new LimitedResourceHealthAdapter(_health),
                    _uiViewFactory.CreateHealthView()));
        }

        private void CreateView()
        {
            _spriteViewCreator.Updater = _updater;
            _polygonViewCreator.Updater = _updater;
        
            _spriteViewFactory = new AsteroidsGameObjectViewFactory(
                _spriteViewCreator.PlayerCreator, 
                _spriteViewCreator.AsteroidCreator, _spriteViewCreator.UfoCreator, 
                _spriteViewCreator.CannonBulletCreator, _spriteViewCreator.LaserBulletCreator);
        
            _polygonViewFactory = new AsteroidsGameObjectViewFactory(
                _polygonViewCreator.PlayerCreator, 
                _polygonViewCreator.AsteroidCreator, _polygonViewCreator.UfoCreator, 
                _polygonViewCreator.CannonBulletCreator, _polygonViewCreator.LaserBulletCreator);
        }

        private void CreateModel()
        {
            _modelDestroyer = new UpdatableDestroyer();
            _updater.ModelDestroyerObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_modelDestroyer, _updater.ModelDestroyerObservable));
        
            _collisionChecker = new CollisionChecker(
                new SimpleCollision());
            _updater.CollisionObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_collisionChecker, _updater.CollisionObservable));

            _modelsFactory = new AsteroidsComponentsStorageFactory(_border, _playerTransform, 
                new PlayerComponentsStorageBuilder(
                    _updater, _modelDestroyer, _uiControllers, _collisionChecker, _healthDieController,
                    _cannonChildrenSpawner, _laserChildrenSpawner,
                    _playerInputController), 
                new AsteroidComponentsStorageBuilder(_updater, _modelDestroyer, 
                    _collisionChecker, _asteroidChildrenSpawner, _scorer),
                new UfoComponentsStorageBuilder(_updater, _modelDestroyer, _collisionChecker, _scorer), 
                new BulletComponentsStorageBuilder(_updater, _modelDestroyer, _collisionChecker));
        }

        private void CreateGameControllers()
        {
            _controllers = new GameObjectControllers();
        
            _controllerCreator = new GameObjectControllerCreator(_spriteViewFactory);

            _playerTransform = new GetterPlayerTransform(_controllers);
        
            _soundEffectsBinder = new ModelSoundEffectsBinder(_effectsSources);
        
            _spawner = new GameObjectSpawner(_controllerCreator, _dataStorage, _controllers, _border, _soundEffectsBinder);
        
            _levelController = new AsteroidsLevelController(_spawner, _controllers, _ufoSpawnProbability);
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_levelController, _updater.OtherUpdateObservable));   
        
            _asteroidChildrenSpawner = new AsteroidChildrenSpawner(_spawner, _dataStorage);
            _cannonChildrenSpawner = new CannonChildrenSpawner(_spawner);
            _laserChildrenSpawner = new LaserChildrenSpawner(_spawner);

            _healthDieController = new HealthDieController(_spawner, _health, _respawnTime);
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_healthDieController, _updater.OtherUpdateObservable));

        
            _healthScoreController = new HealthScoreController(_health, _scorer, _oneHealthScore);
            _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
                (_healthScoreController, _updater.OtherUpdateObservable));


            _viewChanger = new ViewChanger(_updater, _controllerCreator, _controllers, _polygonViewFactory);
            _systemInput.ChangeView += _viewChanger.ChangeView;
        }

        private void LinkModelAndControllers()
        {
            _controllerCreator.ModelFactory = _modelsFactory;
        }

        public AsteroidsGame StartGame()
        {
            CreateBorder();
        
            CreatePlayerInputController();
            CreateHealthAndScorer();
            CreateUi();
            CreateView();
            CreateGameControllers();
            CreateModel();
            LinkModelAndControllers();

            var game = new AsteroidsGame(_updater, _controllerCreator, 
                new AsteroidsGameControllers(_uiControllers, _controllers, _playerInputController,
                    _childrenSpawner, _levelController, _playerTransform, _collisionChecker,
                    _healthDieController, _healthScoreController, _viewChanger),
                _health, _scorer);

            _healthDieController.EndGame += game.Stop;
        
            return game;
        }
    }
}