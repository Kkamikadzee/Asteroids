using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float _maxSpeed = 1f;
    [SerializeField]
    private float _rotateSpeed = 6f;
    [SerializeField]
    private float _acceleration = 0.1f;
    [SerializeField]
    private float _deceleration = 0.2f;
    [SerializeField]
    private int _maxAmountBulletForLaser = 5;
    [SerializeField]
    private float _timeReloadLaser = 1f;
    [SerializeField]
    private float _fireRateLaser = 1f;
    [SerializeField]
    private float _fireRateCannon = 1f;
    [SerializeField]
    private Sprite _spriteStand;
    [SerializeField]
    private Sprite _spriteMove;

    public float MaxSpeed => _maxSpeed;
    public float RotateSpeed => _rotateSpeed;
    public float Acceleration => _acceleration;
    public float Deceleration => _deceleration;
    public int MaxAmountBulletForLaser => _maxAmountBulletForLaser;
    public float TimeReloadLaser => _timeReloadLaser;
    public float FireRateLaser => _fireRateLaser;
    public float FireRateCannon => _fireRateCannon;
    public Sprite SpriteStand => _spriteStand;
    public Sprite SpriteMove => _spriteMove;
}
