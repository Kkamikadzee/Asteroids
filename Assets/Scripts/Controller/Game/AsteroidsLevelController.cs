using System;
using KMK.Model.Updater;
using Other;
using Spawner;
using Random = UnityEngine.Random;

namespace Controller.Game
{
    public class AsteroidsLevelController: IUpdatable
    {
        private GameObjectSpawner _spawner;
        private IAmountObjectsOnField _amountObjectsOnField;
        
        private int _level;
        private int _maxLevel = 10;

        private float _ufoSpawnProbability;
        
        public event Action DisconnectFromObserver;

        public AsteroidsLevelController(GameObjectSpawner spawner, IAmountObjectsOnField amountObjectsOnField
            , float ufoSpawnProbability, int level = 0)
        {
            _spawner = spawner;

            _amountObjectsOnField = amountObjectsOnField;
            
            _ufoSpawnProbability = ufoSpawnProbability;
            
            _level = level;
        }

        private void _spawnLevel(int level)
        {
            if (level <= _maxLevel)
            {
                for (int i = 0; i < level; i++)
                {
                    _spawner.SpawnRandomAsteroid();
                }
            }
            else
            {
                for (int i = 0; i < _maxLevel; i++)
                {
                    _spawner.SpawnRandomAsteroid();
                }
            }
        }

        public void Update(float deltaTime)
        {
            if (_amountObjectsOnField.AmountAsteroids == 0)
            {
                _spawnLevel(++_level);
            }

            if (_amountObjectsOnField.AmountUfo < 2)
            {
                if (Random.value <= _ufoSpawnProbability)
                {
                    _spawner.SpawnRandomUfo();
                }
            }
        }

        public void Reset()
        {
            _level = 0;
        }
    }
}