using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Model.Data
{
    public class AsteroidsDataStorage: Component
    {
        [SerializeField] private PlayerData _player;
        [SerializeField] private AsteroidData[] _sortedAsteroids;
        [SerializeField] private UfoData _ufo;
        [SerializeField] private BulletData _cannonBullet;
        [SerializeField] private BulletData _laserBullet;

        public PlayerData Player => _player;
        public ReadOnlyCollection<AsteroidData> Asteroids => Array.AsReadOnly(_sortedAsteroids);
        public UfoData Ufo => _ufo;
        public BulletData CannonBullet => _cannonBullet;
        public BulletData LaserBullet => _laserBullet;
    }
}