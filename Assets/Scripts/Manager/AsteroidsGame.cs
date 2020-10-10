using System;
using Controller.Game;
using KMK.Model.Other;
using KMK.Model.Scorer;
using Spawner;
using Update;

namespace Manager
{
    public class AsteroidsGame
    {
        private Updater _updater;
        private GameObjectControllerCreator _spawner;
        private AsteroidsGameControllers _controllers;
        private Health _health;
        private Scorer _scorer;

        public Updater Updater => _updater;
        public GameObjectControllerCreator Spawner => _spawner;
        public AsteroidsGameControllers Controllers => _controllers;
        public Health Health => _health;
        public Scorer Scorer => _scorer;

        public event Action EndGame;
        
        public AsteroidsGame(Updater updater, GameObjectControllerCreator spawner,
            AsteroidsGameControllers controllers, Health health,
            Scorer scorer)
        {
            _updater = updater;
            _spawner = spawner;
            _controllers = controllers;
            _health = health;
            _scorer = scorer;

            _controllers.HealthDieController.EndGame += Stop;
        }

        public void Start()
        {
            _updater.Enable();
        }

        public void Stop()
        {
            _updater.Disable();
            
            EndGame?.Invoke();
        }

        public void Restart()
        {
            _updater.Disable();
            
            _controllers.Controllers.Clear();
            
            _controllers.LevelController.Reset();
            _controllers.HealthScoreController.Reset();
            _controllers.HealthDieController.Reset();
            
            _updater.Enable();
        }
    }
}