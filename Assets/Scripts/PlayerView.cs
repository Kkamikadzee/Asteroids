using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public event Action Hit;

    [SerializeField]
    private GameObject _cannonShellPrefab;
    [SerializeField]
    private GameObject _laserShellPrefab;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SpawnPlayer(Vector3 pos, Quaternion dir)
    {
        _transform.SetPositionAndRotation(pos, dir);
    }
    public void ChangeSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    public void SetNewLocation(Vector3 pos, Quaternion dir)
    {
        _transform.SetPositionAndRotation(pos, dir);
    }
    public void CannonShot(Vector3 pos, Quaternion dir)
    {
        var cannonShellObject = Instantiate(_cannonShellPrefab, pos, dir);
    }
    public void LaserShot(Vector3 pos, Quaternion dir)
    {
        var laserShellObject = Instantiate(_laserShellPrefab, pos, dir);
    }
    public void ChangePlayerSprite(Sprite newSprite)
    {
        _spriteRenderer.sprite = newSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit?.Invoke();
    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}

