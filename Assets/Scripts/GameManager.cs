using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _playerUIPrefab;
    [SerializeField]
    private GameObject _cameraPrefab;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private List<EnemyData> _enemyDatas;
    [SerializeField]
    private List<GameObject> _enemyPrefabs;

    private Vector2 fieldBoundary;
    private bool inGame;

    private GameObject _cameraObject;
    private InputModel _inputModel;
    private SystemInput _systemInput;

    private PlayerManager _playerManager;
    private PlayerMoveSystem _playerMoveSystem;
    private PlayerShootSystem _playerShootSystem;

    private EnemyManager _enemyManager;
    private EnemyMoveSystem _enemyMoveSystem;

    private ScoringSystem _scoringSystem;
    private SpawnEnemySystem _spawnEnemySystem;
    private void Start()
    {
        StartGame();
    }
    private void Update()
    {
        _systemInput.Update();
        if (inGame)
        {
            _playerMoveSystem.Update();
            _playerShootSystem.Update();
            _enemyMoveSystem.Update();
            _scoringSystem.Update();
            _spawnEnemySystem.Update();
        }
    }
    private void FixedUpdate()
    {
        if (inGame)
        {
            _playerMoveSystem.FixedUpdate();
            _playerShootSystem.FixedUpdate();
            _spawnEnemySystem.FixedUpdate();
        }
    }
    private void StartGame()
    {
        _cameraObject = Instantiate(_cameraPrefab);

        var camera = _cameraObject.GetComponent<Camera>();
        float widthCam = camera.orthographicSize * camera.aspect;
        fieldBoundary = new Vector2(widthCam, 1f);

        _inputModel = new InputModel();
        _systemInput = new SystemInput(_inputModel);

        _playerManager = new PlayerManager(_playerPrefab, _playerUIPrefab, _playerData);
        _playerMoveSystem = new PlayerMoveSystem(_inputModel, _playerManager.PlayerModel, fieldBoundary);
        _playerShootSystem = new PlayerShootSystem(_inputModel, _playerManager.PlayerModel);

        _enemyManager = new EnemyManager(_enemyDatas, _enemyPrefabs, fieldBoundary.x);
        _enemyMoveSystem = new EnemyMoveSystem(_enemyManager, _playerManager.PlayerModel, fieldBoundary);

        _scoringSystem = new ScoringSystem(_playerManager.PlayerModel, _enemyManager);
        _spawnEnemySystem = new SpawnEnemySystem(_enemyManager);

        _playerManager.Destroy += EndGame;


        _playerManager.SpawnPlayer(Vector3.zero, Quaternion.identity);
        inGame = true;
    }
    private void EndGame(float score)
    {
        inGame = false;
        Debug.Log(score);
        _enemyManager.DestroyAllEnemies();
        _playerManager.Destroy -= EndGame;
    }
}
