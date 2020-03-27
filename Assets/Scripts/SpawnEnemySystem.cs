using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySystem
{
    private EnemyManager _enemyManager;

    private float _currentProbability = 1f;
    private float _deltaProbability = 0.004f;
    private float _probabilitySpawnUFO = 0.15f;
    public SpawnEnemySystem(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void FixedUpdate()
    {
        _currentProbability += _deltaProbability * Time.fixedDeltaTime;
    }
    public void Update()
    {
        SpawnRandomEnemy();
    }
    private void SpawnRandomEnemy() //Нет это не ошибка, что вероятность обнуляется только при спауне астероидов
    {
        if(Random.value < _currentProbability)
        {
            if(Random.value < _probabilitySpawnUFO)
            {
                _enemyManager.SpawnEnemy(TypeEnemy.UFO);
            }
            else
            {
                int amountAsteroids = Random.Range(1, Mathf.CeilToInt(_currentProbability * 3));
                for(int i = 0; i < amountAsteroids; i++)
                {
                    _enemyManager.SpawnEnemy(TypeEnemy.Asteroid);
                }
                _currentProbability = 0f;
            }
        }
    }
}
