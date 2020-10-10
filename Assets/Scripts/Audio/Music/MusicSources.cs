using UnityEngine;

namespace Audio.Music
{
    public class MusicSources: MonoBehaviour
    {
        [SerializeField] private AudioSource _background;
        [SerializeField] private AudioSource _defeat;

        public AudioSource Background => _background;

        public AudioSource Defeat => _defeat;
    }
}