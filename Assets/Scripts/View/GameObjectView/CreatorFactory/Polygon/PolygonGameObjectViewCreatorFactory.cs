using UnityEngine;
using Update;
using View.GameObjectView.Creator;
using View.GameObjectView.Creator.Polygon;

namespace View.GameObjectView.CreatorFactory.Polygon
{
    public class PolygonGameObjectViewCreatorFactory: MonoBehaviour, IGameObjectViewCreatorFactory
    {
        private IUpdater _updater;

        [SerializeField] private Transform _instantiateParent;
        
        [SerializeField] private GameObject _playerPrefab;

        [SerializeField] private GameObject _asteroidPrefab;

        [SerializeField] private GameObject _ufoPrefab;

        [SerializeField] private GameObject _cannonBulletPrefab;

        [SerializeField] private GameObject _laserBulletPrefab;

        public GameObjectViewCreator PlayerCreator
        {
            get
            {
                if(_updater != null)
                {
                    return new PolygonTransformGameObjectViewCreator(_updater, _playerPrefab, _instantiateParent);
                }

                return null;
            }
        }

        public GameObjectViewCreator AsteroidCreator
        {
            get
            {
                if(_updater != null)
                {
                    return new PolygonTransformGameObjectViewCreator(_updater, _asteroidPrefab, _instantiateParent);
                }

                return null;
            }
        }


        public GameObjectViewCreator UfoCreator
        {
            get
            {
                if(_updater != null)
                {
                    return new PolygonTransformGameObjectViewCreator(_updater, _ufoPrefab, _instantiateParent);
                }

                return null;
            }
        }

        public GameObjectViewCreator CannonBulletCreator
        {
            get
            {
                if(_updater != null)
                {
                    return new PolygonTransformGameObjectViewCreator(_updater, _cannonBulletPrefab, _instantiateParent);
                }

                return null;
            }
        }

        
        public GameObjectViewCreator LaserBulletCreator
        {
            get
            {
                if(_updater != null)
                {
                    return new PolygonTransformGameObjectViewCreator(_updater, _laserBulletPrefab, _instantiateParent);
                }

                return null;
            }
        }

        
        public IUpdater Updater
        {
            set => _updater = value;
        }

        public PolygonGameObjectViewCreatorFactory(IUpdater updater)
        {
            _updater = updater;
        }
        
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
    }
}