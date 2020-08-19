using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 2)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private bool _followsPlayer;
    [SerializeField]
    private float _maxSize;
    [SerializeField]
    [Tooltip("0 - asteroid  1 - UFO")]
    private TypeEnemy _typeEnemy;
    [SerializeField]
    private bool _createNewEnemyAfterDie;
    [SerializeField]
    private Sprite _spriteEnemy;
    [SerializeField]
    private float _cost;

    public float MaxSpeed => _maxSpeed;
    public bool FollowsPlayer => _followsPlayer;
    public float MaxSize => _maxSize;
    public TypeEnemy TypeEnemy => _typeEnemy;
    public bool CreateNewEnemyAfterDie => _createNewEnemyAfterDie;
    public Sprite SpriteEnemy => _spriteEnemy;
}

public enum TypeEnemy
{
    Asteroid = 0,
    UFO = 1
}