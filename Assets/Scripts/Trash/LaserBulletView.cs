using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletView : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeedX = 1f;
    [SerializeField]
    private float _bulletSpeedY = 1f;
    [SerializeField]
    private float _bulletSpeed = 1f;
    private void FixedUpdate()
    {
        if (transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        var deltaNewScale = Vector3.zero;
        deltaNewScale.x = _bulletSpeedX * _bulletSpeed * Time.deltaTime;
        deltaNewScale.y = -_bulletSpeedY * _bulletSpeed * Time.deltaTime;
        transform.localScale += deltaNewScale;
    }
}
