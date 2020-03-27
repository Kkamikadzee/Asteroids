using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public event Action<float> Destroy;

    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private PlayerViewUI _playerViewUI;
    public PlayerController(PlayerModel playerModel, PlayerView playerView, PlayerViewUI playerViewUI)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _playerViewUI = playerViewUI;
    }

    public void SpawnPlayer(Vector3 pos, Quaternion dir)
    {
        _playerModel.SpawnPlayer(pos, dir);
    }
    public void SpawnPlayerView(Vector3 pos, Quaternion dir)
    {
        _playerView.SpawnPlayer(pos, dir);
    }
    private void SetNewLocation(Vector3 pos, Quaternion dir)
    {
        _playerView.SetNewLocation(pos, dir);
    }
    private void CannonShot(Vector3 pos, Quaternion dir)
    {
        _playerView.CannonShot(pos, dir);
    }
    private void LaserShot(Vector3 pos, Quaternion dir)
    {
        _playerView.LaserShot(pos, dir);
    }
    private void SetLaserChargeLevel(float valueCharge)
    {
        _playerViewUI.SetLaserChargeLevel(valueCharge);
    }
    private void SetAmountBulletForLaser(int amount)
    {
        _playerViewUI.SetAmountBulletForLaser(amount);
    }
    private void ChangePlayerSprite(Sprite newSprite)
    {
        _playerView.ChangeSprite(newSprite);
    }
    private void SetScoreUI(float score)
    {
        _playerViewUI.SetScore(score);
    }
    private void HitPlayer()
    {
        _playerModel.KillPlayer();
    }
    private void DestroyPlayer()
    {
        Disable();
        Destroy?.Invoke(_playerModel.CurrentScore);
        _playerView.DestroyPlayer();
        _playerViewUI.DestroyPlayer();
        _playerView = null;
        _playerViewUI = null;
        _playerModel = null;
    }
    public void Enable()
    {
        _playerModel.Spawn += SpawnPlayerView;
        _playerModel.ChangeLocation += SetNewLocation;
        _playerModel.CannonShot += CannonShot;
        _playerModel.LaserShot += LaserShot;
        _playerModel.ChangeChargeLevelLaser += SetLaserChargeLevel;
        _playerModel.ChangeAmountBulletForLaser += SetAmountBulletForLaser;
        _playerModel.ChangeSprite += ChangePlayerSprite;
        _playerModel.ChangeScore += SetScoreUI;
        _playerView.Hit += HitPlayer;
        _playerModel.Death += DestroyPlayer;
    }
    public void Disable()
    {
        _playerModel.Spawn -= SpawnPlayerView;
        _playerModel.ChangeLocation -= SetNewLocation;
        _playerModel.CannonShot -= CannonShot;
        _playerModel.LaserShot -= LaserShot;
        _playerModel.ChangeChargeLevelLaser -= SetLaserChargeLevel;
        _playerModel.ChangeAmountBulletForLaser -= SetAmountBulletForLaser;
        _playerModel.ChangeSprite -= ChangePlayerSprite;
        _playerModel.ChangeScore -= SetScoreUI;
        _playerView.Hit -= HitPlayer;
        _playerModel.Death -= DestroyPlayer;
    }
}
