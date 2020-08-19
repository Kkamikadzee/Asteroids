using System;
using UnityEngine;

public class PlayerModel
{
    private PlayerData _description;

    public event Action<Vector3, Quaternion> Spawn;
    public event Action Death;
    public event Action<Vector3, Quaternion> CannonShot;
    public event Action<int> ChangeAmountBulletForLaser;
    public event Action<float> ChangeChargeLevelLaser;
    public event Action<Vector3, Quaternion> LaserShot;
    public event Action<Vector3, Quaternion> ChangeLocation;
    public event Action<Sprite> ChangeSprite;
    public event Action<float> ChangeScore;

    private int _currentAmountBullerForLaser;
    private bool _state; //Движется или нет
    private Vector3 _position;
    private Quaternion _direction;

    private float _currentScore;

    public PlayerData Description => _description;
    public Vector3 Position => _position;
    public Quaternion Direction => _direction;
    public int CurrentAmountBulletForLaser => _currentAmountBullerForLaser;
    public bool State => _state;

    public float CurrentScore => _currentScore;

    public PlayerModel(PlayerData playerData)
    {
        _description = playerData;
        _position = Vector3.zero;
        _direction = Quaternion.identity;
    }

    public void SpawnPlayer(Vector3 pos, Quaternion dir)
    {
        if (_position == Vector3.zero && _direction == Quaternion.identity)
        {
            _position = pos;
            _direction = dir;
            SetCurrentAmountBulletForLaser(Description.MaxAmountBulletForLaser);
            Spawn?.Invoke(pos, dir);
        }
        else
            new System.Exception("Player anready spawned");
    }
    public void KillPlayer()
    {
        Death?.Invoke();
    }
    public void ShootCannon()
    {
        CannonShot?.Invoke(_position, _direction);
    }
    public void SetCurrentAmountBulletForLaser(int amount)
    {
        if (amount >= 0)
        {
            _currentAmountBullerForLaser = amount;
            ChangeAmountBulletForLaser?.Invoke(amount);
        }
        else
            new System.Exception("Amount bullet for laser cannot be less than 0");
    }
    public void ShootLaser()
    {
        if (_currentAmountBullerForLaser > 0)
        {
            SetCurrentAmountBulletForLaser(_currentAmountBullerForLaser - 1);
            LaserShot?.Invoke(_position, _direction);
        }
    }
    public void SetChargeLevelLaser(float valueCharge)
    {
        ChangeChargeLevelLaser?.Invoke(valueCharge);
    }
    public void SetNewLocation(Vector3 pos, Quaternion dir)
    {
        _position = pos;
        _direction = dir;
        ChangeLocation?.Invoke(pos, dir);
    }
    public void ChangePlayerSprite(Sprite newSprite)
    {
        ChangeSprite?.Invoke(newSprite);
    }
    public void SetState(bool state)
    {
        if (_state != state)
        {
            _state = state;
            switch (_state)
            {
                case true:
                    ChangeSprite(_description.SpriteMove);
                    break;
                case false:
                    ChangeSprite(_description.SpriteStand);
                    break;
            }
        }
    }
    public void SetScore(float score)
    {
        if(score >= 0)
        {
            _currentScore = score;
            ChangeScore?.Invoke(_currentScore);
        }
        else
        {
            new System.Exception("Score cannot be less zero");
        }
    }
}
