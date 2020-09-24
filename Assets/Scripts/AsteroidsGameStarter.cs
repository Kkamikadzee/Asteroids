using Controller.Game;
using Controller.GameObjectController;
using Controller.UI;
using Controller.UI.Factory;
using Input;
using KMK.Model.Adapter;
using KMK.Model.Builder;
using KMK.Model.Collision;
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

public class AsteroidsGameStarter: MonoBehaviour
{
    [SerializeField] private int _startAmountHealth;
    [SerializeField] private float _respawnTime;

    [SerializeField] private float _oneHealthScore;

    [SerializeField] private float _startScore;
    [SerializeField] private float _forfeitScoreInSecon;

    [SerializeField] private float _ufoSpawnProbability;
    
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Updater _updater;

    [SerializeField] private UnityAsteroidsUi _asteroidsUi;
    
    [SerializeField] private AsteroidsDataStorage _dataStorage;

    [SerializeField] private SpriteGameObjectViewCreatorFactory _spriteViewCreator;
    [SerializeField] private PolygonGameObjectViewCreatorFactory _polygonViewCreator;
    
    private Rectangle _border;

    private Health _health;
    private Scorer _scorer;

    private SystemInput _systemInput;
    private PlayerInputController _playerInputController;
    
    private SimpleAsteroidsUiViewFactory _uiViewFactory;
    private AsteroidsUiControllersStorage _uiControllers;
    
    private AsteroidsGameObjectViewFactory _spriteViewFactory;
    private AsteroidsGameObjectViewFactory _polygonViewFactory;

    private CollisionChecker _collisionChecker;
    private AsteroidsComponentsStorageFactory _modelsFactory;

    private AsteroidsControllers _controllers;

    private AsteroidsSpawner _spawner;

    private AsteroidsPlayerTransform _playerTransform;
    private AsteroidsLevelController _levelController;
    
    private AsteroidChildrenSpawner _childrenSpawner;
    private AsteroidChildrenSpawnerHelper _asteroidChildrenSpawner;
    private CannonChildrenSpawnerHelper _cannonChildrenSpawner;
    private LaserChildrenSpawnerHelper _laserChildrenSpawner;
    
    private HealthDieController _healthDieController;
    private HealthScoreController _healthScoreController;
    private ViewChanger _viewChanger;
    
    private void CreateHealthAndScorer()
    {
        _health = new Health(_startAmountHealth);
        
        _scorer = new Scorer(_startScore);
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
                new ScorerController(_scorer, 
                    new TimeForfeitScore(_scorer, _forfeitScoreInSecon),
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
        _collisionChecker = new CollisionChecker(
            new SimpleCollision());
        
        _updater.CollisionObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
            (_collisionChecker, _updater.CollisionObservable));

        _modelsFactory = new AsteroidsComponentsStorageFactory(_border, _playerTransform, 
            new PlayerComponentsStorageBuilder(
                _updater, _uiControllers, _collisionChecker, _healthDieController,
                _cannonChildrenSpawner, _laserChildrenSpawner,
                _playerInputController), 
            new AsteroidComponentsStorageBuilder(_updater,
                _collisionChecker, _asteroidChildrenSpawner, _scorer),
            new UfoComponentsStorageBuilder(_updater, _collisionChecker, _scorer), 
            new BulletComponentsStorageBuilder(_updater, _collisionChecker));
    }

    private void CreateGameControllers()
    {
        _controllers = new AsteroidsControllers();
        
        _spawner = new AsteroidsSpawner(_spriteViewFactory);

        _playerTransform = new AsteroidsPlayerTransform(_controllers);
        
        _levelController = new AsteroidsLevelController(_spawner, _dataStorage, _controllers, _border,
            _ufoSpawnProbability);
        _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
            (_levelController, _updater.OtherUpdateObservable));   
        
        _childrenSpawner = new AsteroidChildrenSpawner(_spawner, _controllers);
        _asteroidChildrenSpawner = new AsteroidChildrenSpawnerHelper(_childrenSpawner, _dataStorage);
        _cannonChildrenSpawner = new CannonChildrenSpawnerHelper(_childrenSpawner, _dataStorage);
        _laserChildrenSpawner = new LaserChildrenSpawnerHelper(_childrenSpawner, _dataStorage);

        _healthDieController = new HealthDieController(_spawner, _dataStorage,
            _controllers, _health, _respawnTime);
        _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
            (_healthDieController, _updater.OtherUpdateObservable));

        
        _healthScoreController = new HealthScoreController(_health, _scorer, _oneHealthScore);
        _updater.OtherUpdateObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver
            (_healthScoreController, _updater.OtherUpdateObservable));


        _viewChanger = new ViewChanger(_spawner, _controllers, _polygonViewFactory);
        _systemInput.ChangeView += _viewChanger.ChangeView;
    }

    private void LinkModelAndControllers()
    {
        _spawner.ModelFactory = _modelsFactory;
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

        var game = new AsteroidsGame(_updater, _spawner, 
            new AsteroidsGameControllers(_uiControllers, _controllers, _playerInputController,
                _childrenSpawner, _levelController, _playerTransform, _collisionChecker,
                _healthDieController, _healthScoreController, _viewChanger),
            _health, _scorer);

        _healthDieController.EndGame += game.StopGame;
        
        return game;
    }
}