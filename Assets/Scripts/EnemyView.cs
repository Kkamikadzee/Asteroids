using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public event Action Hit;
    private Transform _transform;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void SpawnEnemy(Vector3 pos, Quaternion dir, Vector3 scale)
    {
        _transform.SetPositionAndRotation(pos, dir);
        _transform.localScale = scale;
    }
    public void SetNewPosition(Vector3 pos)
    {
        _transform.position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit?.Invoke();
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
