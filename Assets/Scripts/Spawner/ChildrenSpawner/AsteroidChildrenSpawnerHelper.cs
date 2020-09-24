using System;
using KMK.Model.Base;
using KMK.Model.Move;
using Model.Data;
using UnityEngine;
using Component = KMK.Model.Base.Component;
using Random = UnityEngine.Random;
using Transform = KMK.Model.Base.Transform;
using Vector3 = KMK.Model.Base.Vector3;

namespace Spawner.ChildrenSpawner
{
    public class AsteroidChildrenSpawnerHelper: ChildrenSpawnerHelper
    {
        private IAsteroidChildrenSpawner _spawner;
        private AsteroidsDataStorage _dataStorage;

        public AsteroidChildrenSpawnerHelper(IAsteroidChildrenSpawner spawner, AsteroidsDataStorage dataStorage)
        {
            _spawner = spawner;
            _dataStorage = dataStorage;
        }
        
        public override void SpawnChildren(IComponentsStorage componentsStorage)
        {
            AsteroidData data = null;
            foreach (var asteroidData in _dataStorage.Asteroids)
            {
                if (asteroidData.Scale < Mathf.Max(componentsStorage.Transform.Scale.X, 
                    componentsStorage.Transform.Scale.Y, componentsStorage.Transform.Scale.Z))
                {
                    data = asteroidData;
                    break;
                }
            }

            if ((data != null))
            {
                float randomAngle = Random.Range(0f, 360f);

                Transform newTransform1 = newTransform1 = new Transform(componentsStorage.Transform.Position, 
                    new Vector3(0f, 0f, randomAngle - 45f));
                Transform newTransform2 = new Transform(componentsStorage.Transform.Position, 
                    new Vector3(0f, 0f, randomAngle + 45f));
                
                _spawner.SpawnAsteroidChildren(newTransform1, data);
                _spawner.SpawnAsteroidChildren(newTransform2, data);
            }
        }
    }
}