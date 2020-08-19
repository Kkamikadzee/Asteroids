using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletView : MonoBehaviour
{
    [SerializeField]
    private float _maxLifeTime = 1f;
    [SerializeField]
    private float _bulletSpeed = 1f;
    private float _lifeTime;
    private Vector3 _eulerAnglesDir;
    private void Start()
    {
        _eulerAnglesDir = Vector3.zero;
        _eulerAnglesDir.x = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        _eulerAnglesDir.y = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
    }
    private void FixedUpdate()
    {
        if (_lifeTime >= _maxLifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            _lifeTime += Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        transform.position += _eulerAnglesDir * _bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
