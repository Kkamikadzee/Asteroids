using System;
using Controller.GameObjectController;
using KMK.Model.Base;
using KMK.Model.Other.Rectangle;
using KMK.Model.Updater;
using Model.Data;
using Spawner;
using Random = UnityEngine.Random;

namespace Controller.Game
{
    public class AsteroidsLevelController: IUpdatable
    {
        private AsteroidsSpawner _spawner;
        private AsteroidsDataStorage _dataStorage;
        private AsteroidsControllers _controllers;

        private int _level;
        private int _maxLevel = 10;

        private float _ufoSpawnProbability;

        private Rectangle _rectangle;
        private float _rectangleMargin = 0.01f;

        public event Action DisconnectFromObserver;

        public AsteroidsLevelController(AsteroidsSpawner spawner,
            AsteroidsDataStorage dataStorage, AsteroidsControllers controllers,
            Rectangle rectangle, float ufoSpawnProbability, int level = 0)
        {
            _spawner = spawner;
            _dataStorage = dataStorage;
            _controllers = controllers;

            _rectangle = rectangle;
            
            _ufoSpawnProbability = ufoSpawnProbability;
            
            _level = level;
        }

        private void _spawnLevel(int level)
        {
            if (level <= _maxLevel)
            {
                for (int i = 0; i < level; i++)
                {
                    var transform = new Transform(_randomPosition(), _randomRotate());
                    var asteroid = _spawner.SpawnAsteroid(transform, _randomAsteroidData());
                    _controllers.AsteroidControllers.AddController(asteroid);
                }
            }
            else
            {
                for (int i = 0; i < _maxLevel; i++)
                {
                    var transform = new Transform(_randomPosition(), _randomRotate());
                    var asteroid = _spawner.SpawnAsteroid(transform, _randomAsteroidData());
                    _controllers.AsteroidControllers.AddController(asteroid);
                }
            }
        }

        private Vector3 _randomPosition()
        {
            return new Vector3(
                Random.Range(_rectangle.LeftBottomPoint.X + _rectangleMargin, _rectangle.RightTopPoint.X - _rectangleMargin),
                Random.Range(_rectangle.LeftBottomPoint.Y + _rectangleMargin, _rectangle.RightTopPoint.Y - _rectangleMargin),
                0);
        }
        private Vector3 _randomRotate()
        {
            return new Vector3(
                0,
                0,
                Random.Range(0f, 360f));
        }

        private AsteroidData _randomAsteroidData()
        {
            return _dataStorage.Asteroids[Random.Range(0, _dataStorage.Asteroids.Count)];
        }

        public void Update(float deltaTime)
        {
            if (_controllers.AsteroidControllers.Controllers.Count == 0)
            {
                _spawnLevel(++_level);
            }

            if (_controllers.UfoControllers.Controllers.Count < 2)
            {
                if (Random.value <= _ufoSpawnProbability)
                {
                    var transform = new Transform(_randomPosition());
                    var ufo = _spawner.SpawnUfo(transform, _dataStorage.Ufo);
                    _controllers.UfoControllers.AddController(ufo);
                }
            }
        }
    }
}