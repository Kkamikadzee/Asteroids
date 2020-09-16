using UnityEngine;
using Update;
using View.GameObjectView.Creator;
using View.GameObjectView.Creator.Polygon;

namespace View.GameObjectView.CreatorFactory.Polygon
{
    public class PolygonGameObjectViewCreatorFactory: IGameObjectViewCreatorFactory
    {
        private IUpdater _updater;

        private Transform _instantiateParent;
        
        private GameObject _playerPrefab;

        private GameObject _asteroidPrefab;

        private GameObject _ufoPrefab;

        private GameObject _cannonBulletPrefab;

        private GameObject _laserBulletPrefab;

        public PolygonGameObjectViewCreatorFactory(IUpdater updater, Transform instantiateParent,
            GameObject playerPrefab,
            GameObject asteroidPrefab, GameObject ufoPrefab,
            GameObject cannonBulletPrefab, GameObject laserBulletPrefab)
        {
            _updater = updater;

            _instantiateParent = instantiateParent;

            _playerPrefab = playerPrefab;

            _asteroidPrefab = asteroidPrefab;

            _ufoPrefab = ufoPrefab;

            _cannonBulletPrefab = cannonBulletPrefab;

            _laserBulletPrefab = laserBulletPrefab;
        }

        public GameObjectViewCreator PlayerCreator =>
            new PolygonTransformGameObjectViewCreator(_updater, _playerPrefab, _instantiateParent);

        public GameObjectViewCreator AsteroidCreator => 
            new PolygonTransformGameObjectViewCreator(_updater, _asteroidPrefab, _instantiateParent);

        public GameObjectViewCreator UfoCreator => 
            new PolygonTransformGameObjectViewCreator(_updater, _ufoPrefab, _instantiateParent);

        public GameObjectViewCreator CannonBulletCreator => 
            new PolygonTransformGameObjectViewCreator(_updater, _cannonBulletPrefab, _instantiateParent);

        public GameObjectViewCreator LaserBulletCreator => 
            new PolygonTransformGameObjectViewCreator(_updater, _laserBulletPrefab, _instantiateParent);

    }
}