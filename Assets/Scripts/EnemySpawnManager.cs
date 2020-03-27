using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager
{
    private Transform _parent;
    public Transform Parent => _parent;
    public EnemySpawnManager()
    {
        _parent = GameObject.Find("Enemies").transform;
    }
    private Vector2 RandSpawnCoodrinate(float fieldBoundary)
    {
        float deltaMargin = 0.001f; // Отступ от края, чтобы спаунить не на краях, а внутри
        Vector2 retVector2 = Vector2.zero;
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0: //Left
                retVector2.x = -fieldBoundary + deltaMargin;
                break;
            case 1: //Top
                retVector2.y = 1 - deltaMargin;
                break;
            case 2: //Right
                retVector2.x = fieldBoundary - deltaMargin;
                break;
            case 3:  //Bottom
                retVector2.y = -1 + deltaMargin;
                break;
        }
        if (retVector2.x == 0)
        {
            retVector2.x = Random.Range(-fieldBoundary + deltaMargin, fieldBoundary - deltaMargin);
        }
        else // y == 0 
        {
            retVector2.y = Random.Range(-1f + deltaMargin, 1f - deltaMargin);
        }
        return retVector2;
    }
    private Vector2 RandSpawnDirMove()
    {
        return Random.rotation.eulerAngles.normalized;
    }
    private Quaternion RandSpawnRotation()
    {
        return Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f)));
    }

    public void SpawnEnemy(EnemyData data, GameObject enemyPrefab, float fieldBoundary, out EnemyController controller, out EnemyModel model, out EnemyView view)
    {
        model = new EnemyModel(data);
        var enemyObject = Object.Instantiate(enemyPrefab, _parent);
        view = enemyObject.GetComponent<EnemyView>();
        controller = new EnemyController(model, view);
        controller.Enable();
        Vector2 spawnCoodrdinate = RandSpawnCoodrinate(fieldBoundary);
        Vector2 spawnDirMove = RandSpawnDirMove();
        Quaternion spawnRotation = RandSpawnRotation();
        switch (data.TypeEnemy)
        {
            case TypeEnemy.Asteroid:
                controller.SpawnEnemy(spawnCoodrdinate, spawnRotation, spawnDirMove, data.MaxSize, data.MaxSpeed / data.MaxSize);
                break;
            case TypeEnemy.UFO:
                controller.SpawnEnemy(spawnCoodrdinate, Quaternion.identity, spawnDirMove, data.MaxSize, data.MaxSpeed);
                break;
        }
    }
    public void SpawnChildEnemy(EnemyModel enemyModel, GameObject enemyPrefab, int countChilds, out EnemyController[] controller, out EnemyModel[] model, out EnemyView[] view)
    {
        float sizeChilds = 0;
        switch (enemyModel.Description.TypeEnemy)
        {
            case TypeEnemy.Asteroid:
                sizeChilds = enemyModel.CurrentSize / countChilds;
                if(sizeChilds <= 0.5f)
                {
                    controller = null;
                    model = null;
                    view = null;
                    return;
                }
                break;
            case TypeEnemy.UFO:
                //---//
                break;
        }
        controller = new EnemyController[countChilds];
        model = new EnemyModel[countChilds];
        view = new EnemyView[countChilds];
        for(int i = 0; i< countChilds; i++)
        {
            model[i] = new EnemyModel(enemyModel.Description);
            var enemyObject = Object.Instantiate(enemyPrefab, _parent);
            view[i] = enemyObject.GetComponent<EnemyView>();
            controller[i] = new EnemyController(model[i], view[i]);
            controller[i].Enable();
            Vector2 spawnDirMove = RandSpawnDirMove();
            Quaternion spawnRotation = RandSpawnRotation();
            switch (enemyModel.Description.TypeEnemy)
            {
                case TypeEnemy.Asteroid:
                    controller[i].SpawnEnemy(enemyModel.Position, spawnRotation, spawnDirMove, sizeChilds, enemyModel.CurrentSpeed / (sizeChilds));
                    break;
                case TypeEnemy.UFO:
                    //---//
                    break;
            }
        }
    }
}
