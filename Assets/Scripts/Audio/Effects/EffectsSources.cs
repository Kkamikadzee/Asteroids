using UnityEngine;

namespace Audio.Effects
{
    public class EffectsSources: MonoBehaviour
    {
        [SerializeField] private AudioSource _explosion;
        [SerializeField] private AudioSource _cannonShot;
        [SerializeField] private AudioSource _laserShot;

        public AudioSource Explosion => _explosion;

        public AudioSource CannonShot => _cannonShot;

        public AudioSource LaserShot => _laserShot;
    }
}