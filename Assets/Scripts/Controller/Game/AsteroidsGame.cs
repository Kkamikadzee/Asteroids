using KMK.Model.Other;
using KMK.Model.Scorer;
using Spawner;
using Update;

namespace Controller.Game
{
    public class AsteroidsGame
    {
        private Updater _updater;
        private AsteroidsSpawner _spawner;
        private AsteroidsGameControllers _controllers;
        private Health _health;
        private Scorer _scorer;

        public Updater Updater => _updater;
        public AsteroidsSpawner Spawner => _spawner;
        public AsteroidsGameControllers Controllers => _controllers;
        public Health Health => _health;
        public Scorer Scorer => _scorer;

        public AsteroidsGame(Updater updater, AsteroidsSpawner spawner,
            AsteroidsGameControllers controllers, Health health,
            Scorer scorer)
        {
            _updater = updater;
            _spawner = spawner;
            _controllers = controllers;
            _health = health;
            _scorer = scorer;

            _controllers.HealthDieController.EndGame += StartGame;
        }

        private void _spawnPlayer()
        {
            
        }
        
        public void StartGame()
        {
            _updater.Enable();
        }
        
        public void StopGame()
        {
            _updater.Disable();
        }
        
    }
}