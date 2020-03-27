using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem
{
    private PlayerModel _playerModel;
    private EnemyManager _enemyManager;

    private float _timePenalty = 3f; //value в секунду

    public ScoringSystem(PlayerModel playerModel, EnemyManager enemyManager)
    {
        _playerModel = playerModel;
        _enemyManager = enemyManager;
        _enemyManager.Destroy += AddScore;
    }
    public void Update()
    {
        if(_playerModel.CurrentScore > 0)
        {
            float addScore = -(_timePenalty * Time.deltaTime);
            if (_playerModel.CurrentScore + addScore > 0)
            {
                _playerModel.SetScore(_playerModel.CurrentScore + addScore);
            }
            else
            {
                _playerModel.SetScore(0f);
            }
        }
    }
    private void AddScore(EnemyModel enemy)
    {
        float addScore = 0;
        switch (enemy.Description.TypeEnemy)
        {
            case TypeEnemy.Asteroid:
                addScore = 100f / enemy.CurrentSize;
                break;
            case TypeEnemy.UFO:
                addScore = 150f;
                break;
        }
        _playerModel.SetScore(_playerModel.CurrentScore + addScore);
    }
}
