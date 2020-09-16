using UnityEngine;
using Update;
using View.GameObjectView.Creator;
using View.GameObjectView.Creator.Sprite;

namespace View.GameObjectView.CreatorFactory.Sprite
{
    public class SpriteGameObjectViewCreatorFactory: IGameObjectViewCreatorFactory
    {
        private IUpdater _updater;

        private Transform _instantiateParent;
        
        private UnityEngine.Sprite[] _playerSprites;
        private GameObject _playerPrefab;

        private GameObject _asteroidPrefab;

        private GameObject _ufoPrefab;

        private GameObject _cannonBulletPrefab;

        private GameObject _laserBulletPrefab;

        public SpriteGameObjectViewCreatorFactory(IUpdater updater, Transform instantiateParent,
            UnityEngine.Sprite[] playerSprites, GameObject playerPrefab,
            GameObject asteroidPrefab, GameObject ufoPrefab,
            GameObject cannonBulletPrefab, GameObject laserBulletPrefab)
        {
            _updater = updater;

            _instantiateParent = instantiateParent;

            _playerSprites = playerSprites;
            _playerPrefab = playerPrefab;

            _asteroidPrefab = asteroidPrefab;

            _ufoPrefab = ufoPrefab;

            _cannonBulletPrefab = cannonBulletPrefab;

            _laserBulletPrefab = laserBulletPrefab;
        }

        public GameObjectViewCreator PlayerCreator => 
            new SpriteTransformMutableGameObjectViewCreator(_updater, _playerPrefab, _instantiateParent, _playerSprites);

        public GameObjectViewCreator AsteroidCreator => 
            new SpriteTransformGameObjectViewCreator(_updater, _asteroidPrefab, _instantiateParent);

        public GameObjectViewCreator UfoCreator => 
            new SpriteTransformGameObjectViewCreator(_updater, _ufoPrefab, _instantiateParent);

        public GameObjectViewCreator CannonBulletCreator => 
            new SpriteTransformGameObjectViewCreator(_updater, _cannonBulletPrefab, _instantiateParent);

        public GameObjectViewCreator LaserBulletCreator => 
            new SpriteTransformGameObjectViewCreator(_updater, _laserBulletPrefab, _instantiateParent);
    }
}