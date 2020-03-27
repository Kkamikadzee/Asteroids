using System;
using UnityEngine;

public class EnemyModel
{
    private EnemyData _description;

    public event Action<Vector3, Quaternion, Vector3> Spawn;
    public event Action Death;
    public event Action<Vector3> ChangePosition;

    private Vector3 _position;
    private Quaternion _direction;
    private Vector3 _directionMove;
    private float _currentSize;
    private float _currentSpeed;

    private bool _linkedToPlayer;

    public EnemyData Description => _description;
    public Vector3 Position => _position;
    public Quaternion Direction => _direction;
    public Vector3 DirectionMove => _directionMove;
    public float CurrentSize => _currentSize;
    public float CurrentSpeed => _currentSpeed;

    public bool LinkdeToPlayer => _linkedToPlayer;

    public EnemyModel(EnemyData enemyData)
    {
        _description = enemyData;
        _position = Vector3.zero;
        _direction = Quaternion.identity;
    }

    public void SpawnEnemy(Vector3 pos, Quaternion dir, Vector3 dirMove, float size, float speed)
    {
        if (_position == Vector3.zero && _direction == Quaternion.identity)
        {
            _position = pos;
            _direction = dir;
            _directionMove = dirMove;
            _currentSize = size;
            _currentSpeed = speed;
            Spawn?.Invoke(pos, dir, Vector3.one * size);
        }
        else
            new System.Exception("Enemy anready spawned");
    }
    public void KillEnemy()
    {
        Death?.Invoke();
    }
    public void SetNewPosition(Vector3 pos)
    {
        _position = pos;
        ChangePosition?.Invoke(pos);
    }
    public void Bounce(Vector3 normal)
    {
        _directionMove = Vector3.Reflect(_directionMove, normal);
    }
    public void SetLinkedToPlayer(PlayerModel playerModel)
    {
        playerModel.ChangeLocation += UpdateDirectionMoveFollowPlayer;
        _linkedToPlayer = true;
    }
    private void UpdateDirectionMoveFollowPlayer(Vector3 playerPosition, Quaternion playerDir)
    {
        _directionMove = Vector3.Normalize(playerPosition - _position);
    }

}
