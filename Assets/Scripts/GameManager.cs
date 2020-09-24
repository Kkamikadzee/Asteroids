using Controller.Game;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AsteroidsGameStarter _playerStarter;

    private AsteroidsGame _game;
    
    private void Start()
    {
        _game = _playerStarter.StartGame();
        _game.StartGame();
    }
}
