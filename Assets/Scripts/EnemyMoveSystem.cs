using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSystem
{
    private EnemyManager _enemyManager;
    private PlayerModel _playerModel;
    private Vector3 _fieldBoundary;
    public EnemyMoveSystem(EnemyManager enemyManager, PlayerModel playerModel, Vector2 fieldBoundary)
    {
        _enemyManager = enemyManager;
        _playerModel = playerModel;
        _fieldBoundary = fieldBoundary;
    }
    public void Update()
    {
        foreach(EnemyModel model in _enemyManager.EnemyModels)
        {
            switch(model.Description.TypeEnemy)
            {
                case TypeEnemy.Asteroid:
                    if (model.Position.x > _fieldBoundary.x)
                    {
                        model.Bounce(Vector3.left);
                    }
                    else if (model.Position.x < -_fieldBoundary.x)
                    {
                        model.Bounce(Vector3.right);
                    }
                    if (model.Position.y > _fieldBoundary.y)
                    {
                        model.Bounce(Vector3.down);
                    }
                    else if (model.Position.y < -_fieldBoundary.y)
                    {
                        model.Bounce(Vector3.up);
                    }
                    break;
                case TypeEnemy.UFO:
                    if(!model.LinkdeToPlayer)
                    {
                        model.SetLinkedToPlayer(_playerModel);
                    }

                    if (model.Position.x > _fieldBoundary.x)
                    {
                        Vector3 newPos = model.Position;
                        newPos.x -= 2 * _fieldBoundary.x;
                        model.SetNewPosition(newPos);
                    }
                    else if (model.Position.x < -_fieldBoundary.x)
                    {
                        Vector3 newPos = model.Position;
                        newPos.x += 2 * _fieldBoundary.x;
                        model.SetNewPosition(newPos);
                    }
                    if (model.Position.y > _fieldBoundary.y)
                    {
                        Vector3 newPos = model.Position;
                        newPos.y -= 2 * _fieldBoundary.y;
                        model.SetNewPosition(newPos);
                    }
                    else if (model.Position.y < -_fieldBoundary.y)
                    {
                        Vector3 newPos = model.Position;
                        newPos.y += 2 * _fieldBoundary.y;
                        model.SetNewPosition(newPos);
                    }
                    break;
            }
            model.SetNewPosition(model.Position + model.DirectionMove * model.CurrentSpeed * Time.deltaTime);
        }
    }
}
