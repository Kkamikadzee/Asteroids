using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public event System.Action<float> Destroy;

    private GameObject _playerPrefab;
    private GameObject _playerUIPrefab;
    private PlayerData _playerData;
    private PlayerController _playerController;
    private PlayerModel _playerModel;
    private GameObject _playerObject;
    private GameObject _playerUIObject;

    public PlayerModel PlayerModel => _playerModel;
    public PlayerManager(GameObject playerPrefab, GameObject playerUIPrefab, PlayerData playerData)
    {
        _playerPrefab = playerPrefab;
        _playerUIPrefab = playerUIPrefab;
        _playerData = playerData;
        _playerModel = new PlayerModel(_playerData);
    }
    public void SpawnPlayer(Vector3 pos, Quaternion dir)
    {
        _playerObject = Object.Instantiate(_playerPrefab, pos, dir);
        _playerUIObject = Object.Instantiate(_playerUIPrefab);
        _playerController = new PlayerController(_playerModel, _playerObject.GetComponent<PlayerView>(), _playerUIObject.GetComponent<PlayerViewUI>());
        EnableController();
        _playerController.Destroy += DestroyPlayer;
        _playerController.SpawnPlayer(pos, dir);
    }
    public void DestroyPlayer(float score)
    {
        Destroy?.Invoke(score);
        _playerController.Destroy -= DestroyPlayer;
        _playerController = null;
    }
    public void EnableController()
    {
        _playerController.Enable();
    }
    public void DisableController()
    {
        _playerController.Disable();
    }
}