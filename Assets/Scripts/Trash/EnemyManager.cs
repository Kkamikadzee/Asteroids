using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public event Action<EnemyModel> Destroy;

    private List<EnemyData> _enemyDatas;
    private List<GameObject> _enemyPrefabs;

    private Dictionary<EnemyController, EnemyModel> _controllerModelPairs; //По факту эти словари не нужны здесь, было просто интересно как оперировать с элементами из них в игровом процессе.
    private Dictionary<EnemyView, EnemyModel> _viewModelPairs;
    private List<EnemyModel> _enemyModels;

    private EnemySpawnManager _enemySpawnManager;
    private float _fieldBoundary;
    public List<EnemyModel> EnemyModels => _enemyModels;
    public EnemyManager(List<EnemyData> enemyDatas, List<GameObject> enemyPrefabs, float fieldBoundary)
    {
        _enemyDatas = enemyDatas;
        _enemyPrefabs = enemyPrefabs;
        _enemySpawnManager = new EnemySpawnManager();
        _controllerModelPairs = new Dictionary<EnemyController, EnemyModel>();
        _viewModelPairs = new Dictionary<EnemyView, EnemyModel>();
        _enemyModels = new List<EnemyModel>();
        _fieldBoundary = fieldBoundary;
    }

    public void SpawnEnemy(TypeEnemy typeEnemy)
    {
        EnemyController controller;
        EnemyModel model;
        EnemyView view;
        int numPrefab = System.Convert.ToInt32(typeEnemy);
        _enemySpawnManager.SpawnEnemy(_enemyDatas[numPrefab], _enemyPrefabs[numPrefab], _fieldBoundary, out controller, out model, out view);
        controller.Destroy += DestroyEnemy;
        _controllerModelPairs.Add(controller, model);
        _viewModelPairs.Add(view, model);
        _enemyModels.Add(model);
    }

    public void DestroyEnemy(EnemyController controller, EnemyView view)
    {
        var model = _controllerModelPairs[controller];
        if (model.Description.CreateNewEnemyAfterDie)
        {
            EnemyController[] controllers;
            EnemyModel[] models;
            EnemyView[] views;

            int numPrefab = System.Convert.ToInt32(model.Description.TypeEnemy);
            int countChilds = 2;
            _enemySpawnManager.SpawnChildEnemy(model, _enemyPrefabs[numPrefab], countChilds, out controllers, out models, out views);
            if(controllers != null && models != null && views != null)
            {
                for (int i = 0; i < countChilds; i++)
                {
                    controllers[i].Destroy += DestroyEnemy;
                    _controllerModelPairs.Add(controllers[i], models[i]);
                    _viewModelPairs.Add(views[i], models[i]);
                    _enemyModels.Add(models[i]);
                }
            }
        }
        Destroy?.Invoke(model);
        _enemyModels.Remove(model);
        _controllerModelPairs.Remove(controller);
        _viewModelPairs.Remove(view);
        controller.Destroy -= DestroyEnemy;
        controller = null;
    }
    public void DestroyAllEnemies()
    {
        _viewModelPairs.Clear();
        var controllerModelArray = _controllerModelPairs.Keys.ToArray();
        for(int i = controllerModelArray.Length - 1; i >= 0; i--)
        {
            var model = _controllerModelPairs[controllerModelArray[i]];
            Destroy?.Invoke(model);
            _enemyModels.Remove(model);
            _controllerModelPairs.Remove(controllerModelArray[i]);
            controllerModelArray[i].Destroy -= DestroyEnemy;
            controllerModelArray[i] = null;
        }
    }
    public void UpdateFieldBoundary(float value)
    {
        _fieldBoundary = value;
    }
}
