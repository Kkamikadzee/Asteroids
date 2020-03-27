using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootSystem
{
    InputModel _inputModel;
    PlayerModel _playerModel;

    private float _timeBetweenCannonShots;
    private float _timeSinceLastCannonShot;
    private float _timeBetweenLaserShots;
    private float _timeSinceLastLaserShot;
    private float _timeReloadLaser = 0;
    public PlayerShootSystem(InputModel inputModel, PlayerModel playerModel)
    {
        _inputModel = inputModel;
        _playerModel = playerModel;
        _timeBetweenCannonShots = 1f / playerModel.Description.FireRateCannon;
        _timeSinceLastCannonShot = _timeBetweenCannonShots;
        _timeBetweenLaserShots = 1f / playerModel.Description.FireRateLaser;
        _timeSinceLastLaserShot = _timeBetweenLaserShots;
    }
    public void FixedUpdate()
    {
        if (_playerModel.CurrentAmountBulletForLaser < _playerModel.Description.MaxAmountBulletForLaser)
        {
            if (_timeReloadLaser < _playerModel.Description.TimeReloadLaser)
            {
                _timeReloadLaser += Time.fixedDeltaTime;
            }
        }
        if (_timeSinceLastCannonShot < _timeBetweenCannonShots)
        {
            _timeSinceLastCannonShot += Time.fixedDeltaTime;
        }
        if (_timeSinceLastLaserShot < _timeBetweenLaserShots)
        {
            _timeSinceLastLaserShot += Time.fixedDeltaTime;
        }
    }
    public void Update()
    {
        if (_inputModel.Cannon != 0)
        {
            if(_timeSinceLastCannonShot >= _timeBetweenCannonShots)
            {
                _playerModel.ShootCannon();
                _timeSinceLastCannonShot = 0;
            }
        }
        if(_timeReloadLaser >= _playerModel.Description.TimeReloadLaser)
        {
            if (_playerModel.CurrentAmountBulletForLaser < _playerModel.Description.MaxAmountBulletForLaser)
            {
                _playerModel.SetCurrentAmountBulletForLaser(_playerModel.CurrentAmountBulletForLaser + 1);
                _timeReloadLaser = 0;
            }
        }
        if(_playerModel.CurrentAmountBulletForLaser < _playerModel.Description.MaxAmountBulletForLaser)
        {
            _playerModel.SetChargeLevelLaser(_timeReloadLaser / _playerModel.Description.TimeReloadLaser);
        }
        if (_inputModel.Laser != 0)
        {
            if (_timeSinceLastLaserShot >= _timeBetweenLaserShots)
            {
                _playerModel.ShootLaser();
                _timeSinceLastLaserShot = 0;
            }
        }
    }
}
