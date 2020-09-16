using System;
using Controller.GameObjectController;
using KMK.Model.Base;
using KMK.Model.Other;
using KMK.Model.Other.Pursuer;
using KMK.Model.Scorer;
using KMK.Model.Updater;
using Model.Data;
using Spawner;
using View.GameObjectView;

namespace Controller.Game
{
    public class HealthDieController: IUpdatable
    {
        private IAsteroidsSpawner _spawner;
        private AsteroidsDataStorage _dataStorage;
        
        private AsteroidsControllers _controllers;
        private Health _health;

        private bool _respawn;
        private float _respawnTime;
        private float _currentRespawnTime;
        
        public event Action DisconnectFromObserver;

        public HealthDieController(IAsteroidsSpawner spawner, AsteroidsDataStorage dataStorage, AsteroidsControllers controllers,
            Health health, float respawnTime)
        {
            _spawner = spawner;
            _dataStorage = dataStorage;
            
            _controllers = controllers;
            _health = health;

            _respawn = false;
            _respawnTime = respawnTime;
            _currentRespawnTime = 0;
        }
        
        public void Update(float deltaTime)
        {
            if (_respawn)
            {
                _currentRespawnTime += deltaTime;
                {
                    if (_currentRespawnTime >= _respawnTime)
                    {
                        _respawn = false;
                        _currentRespawnTime = 0;
                        
                        Transform transform = new Transform(Vector3.Zero, Vector3.Zero);
                        var tmp = _spawner.SpawnPlayer(transform, _dataStorage.Player);
                        _controllers.PlayerController = tmp;

                        foreach (var ufoController in _controllers.UfoControllers.Controllers)
                        {
                            ufoController.GameObjectModel.GetComponent<PursuerPointer>().Pursued = transform;
                        }
                    }
                }
            }
            
        }

        public void SubHealth(IComponentsStorage componentsStorage)
        {
            _health.SubHealth();
            _respawn = true;
        }
    }
}