using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public event Action<EnemyController, EnemyView> Destroy;

    EnemyModel _enemyModel;
    EnemyView _enemyView;

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        _enemyModel = enemyModel;
        _enemyView = enemyView;
    }

    public void SpawnEnemy(Vector3 pos, Quaternion dir, Vector3 dirMove, float size, float speed)
    {
        _enemyModel.SpawnEnemy(pos, dir, dirMove, size, speed);
    }
    public void SpawnEnemyView(Vector3 pos, Quaternion dir, Vector3 scale)
    {
        _enemyView.SpawnEnemy(pos, dir, scale);
    }
    private void SetNewPosition(Vector3 pos)
    {
        _enemyView.SetNewPosition(pos);
    }
    private void HitEnemyModel()
    {
        _enemyModel.KillEnemy();
    }
    private void DestroyEnemy()
    {
        Disable();
        Destroy?.Invoke(this, _enemyView);
        _enemyView.DestroyEnemy();
        _enemyView = null;
        _enemyModel = null;
    }
    public void Enable()
    {
        _enemyView.Hit += HitEnemyModel;
        _enemyModel.Spawn += SpawnEnemyView;
        _enemyModel.Death += DestroyEnemy;
        _enemyModel.ChangePosition += SetNewPosition;
    }
    public void Disable()
    {
        _enemyView.Hit -= HitEnemyModel;
        _enemyModel.Spawn -= SpawnEnemyView;
        _enemyModel.Death -= DestroyEnemy;
        _enemyModel.ChangePosition -= SetNewPosition;
    }

}
