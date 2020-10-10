using System;
using KMK.Model.Base;
using KMK.Model.Other;
using KMK.Model.Updater;
using Spawner;

namespace Controller.Game
{
    public class HealthDieController: IUpdatable
    {
        private GameObjectSpawner _spawner;
        
        private Health _health;
        private int _defaultHealth;
        
        private bool _respawn;
        private float _respawnTime;
        private float _currentRespawnTime;
        
        public event Action DisconnectFromObserver;
        public event Action EndGame;

        public HealthDieController(GameObjectSpawner spawner,
            Health health, float respawnTime)
        {
            _spawner = spawner;

            _health = health;

            _defaultHealth = _health.CurrentHealth;

            _respawn = true;
            _respawnTime = respawnTime;
            _currentRespawnTime = 0;
        }
        
        public void Update(float deltaTime)
        {
            if (_respawn)
            {
                _currentRespawnTime += deltaTime;
                if (_currentRespawnTime >= _respawnTime)
                {
                    _respawn = false;
                    _currentRespawnTime = 0;
                    
                    _spawner.SpawnPlayer();
                }
            }
        }

        public void SubHealth(IComponentsStorage componentsStorage)
        {
            _health.SubHealth();
            if (_health.CurrentHealth >= 0)
            {
                _respawn = true;
            }
            else
            {
                EndGame?.Invoke();
            }
        }

        public void Reset()
        {
            _health.AddHealth(_defaultHealth - _health.CurrentHealth);
            
            _respawn = true;
            _currentRespawnTime = 0;
        }
    }
}