using Audio.Effects;
using Controller.GameObjectController;
using KMK.Model.Base;
using KMK.Model.Other.Pursuer;
using KMK.Model.Other.Rectangle;
using Model.Data;
using Other;
using UnityEngine;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Spawner
{
    public class GameObjectSpawner
    {
         private IGameObjectControllerCreator _controllerCreator;
         private AsteroidsDataStorage _dataStorage;
         private GameObjectControllers _controllers;

         private Rectangle _rectangle;
         private float _rectangleMargin = 0.01f;

         private ModelSoundEffectsBinder _soundEffectsBinder;
         
         public GameObjectSpawner(IGameObjectControllerCreator controllerCreator,
             AsteroidsDataStorage dataStorage, GameObjectControllers controllers, Rectangle rectangle,
             ModelSoundEffectsBinder soundEffectsBinder)
         {
             _controllerCreator = controllerCreator;
             _dataStorage = dataStorage;
             _controllers = controllers;

             _rectangle = rectangle;

             _soundEffectsBinder = soundEffectsBinder;
         }

         private AsteroidData _randomAsteroidData()
         {
             return _dataStorage.Asteroids[Random.Range(0, _dataStorage.Asteroids.Count)];
         }

         private void _bindEffects(IComponentsStorage componentsStorage)
         {
             _soundEffectsBinder.Bind(componentsStorage);
         }
         
         public void SpawnPlayer()
         {
             var transform = new Transform(Vector3.Zero, Vector3.Zero);
             var player = _controllerCreator.CreatePlayer(transform, _dataStorage.Player);
             _controllers.PlayerController = player;

             _bindEffects(player.GameObjectModel);
             
             //Обновление целей у преследователей
             foreach (var ufoController in _controllers.UfoControllers.Controllers)
             {
                 ufoController.GameObjectModel.GetComponent<PursuerPointer>().Pursued = transform;
             }
         }
         
         public void SpawnRandomAsteroid()
         {
             var transform = new Transform(RandomTransform.RandomPositionInRectangle2D(_rectangle, _rectangleMargin),
                 RandomTransform.RandomRotate2D());
             var asteroid = _controllerCreator.CreateAsteroid(transform, _randomAsteroidData());
             _controllers.AsteroidControllers.AddController(asteroid);
             
             _bindEffects(asteroid.GameObjectModel);
         }
         
         public void SpawnAsteroid(Transform transform, AsteroidData data)
         {
             var asteroid = _controllerCreator.CreateAsteroid(transform, data);
             _controllers.AsteroidControllers.AddController(asteroid);
             
             _bindEffects(asteroid.GameObjectModel);
         }

         public void SpawnRandomUfo()
         {
             var transform = new Transform(RandomTransform.RandomPositionInRectangle2D(_rectangle, _rectangleMargin));
             var ufo = _controllerCreator.CreateUfo(transform, _dataStorage.Ufo);
             _controllers.UfoControllers.AddController(ufo);
             
             _bindEffects(ufo.GameObjectModel);
         }

         public void SpawnCannonBullet(Transform transform)
         {
             var controller = _controllerCreator.CreateCannonBullet(transform, _dataStorage.CannonBullet);
             _controllers.CannonBulletControllers.AddController(controller);

         }
         
         public void SpawnLaserBullet(Transform transform)
         {
             var controller = _controllerCreator.CreateLaserBullet(transform, _dataStorage.LaserBullet);
             _controllers.LaserControllers.AddController(controller);
         }
    }
}