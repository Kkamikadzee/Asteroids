using Audio.Music;
using Controller.Game;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AsteroidsGameStarter _playerStarter;
    
        [SerializeField] private MusicSources _musicSources;

        [SerializeField] private Settings.AudioSettings _audioSettings;
        
        private AsteroidsGame _game;

        private void Start()
        {
            _audioSettings.Initialize();

            _game = _playerStarter.Create();

            _game.EndGame += _musicSources.Defeat.Play;
        
            _game.Start();
        }

        public void Restart()
        {
            _game.Restart();
        }
    }
}
