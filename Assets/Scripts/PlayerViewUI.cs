using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViewUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _UILaserBulletPrefab;
    private Stack<GameObject> _laserBulletStack;
    private Image _reloadLevelLaser;
    private Text _score;
    public void Awake()
    {
        _laserBulletStack = new Stack<GameObject>();
        _reloadLevelLaser = transform.Find("UIReloadLevelLaser").GetComponent<Image>();
        _score = transform.Find("UIScore").GetComponent<Text>();
    }
    public void SetLaserChargeLevel(float valueCharge)
    {
        _reloadLevelLaser.fillAmount = valueCharge;
    }
    public void SetAmountBulletForLaser(int amount)
    {
        if(amount > _laserBulletStack.Count)
        {
            while(amount > _laserBulletStack.Count)
            {
                AddLaserBullet();
            }
        }
        else if(amount < _laserBulletStack.Count)
        {
            while (amount < _laserBulletStack.Count)
            {
                DeleteLaserBullet();
            }
        }
    }
    private void AddLaserBullet()
    {
        var bulletPosition = new Vector3(-(32 * _laserBulletStack.Count), 0, 0);
        _laserBulletStack.Push(Instantiate(_UILaserBulletPrefab, transform));
        _laserBulletStack.Peek().GetComponent<RectTransform>().transform.position += bulletPosition;
    }
    private void DeleteLaserBullet()
    {
        Destroy(_laserBulletStack.Pop());
    }

    public void SetScore(float score)
    {
        _score.text = "Score: " + (Mathf.FloorToInt(score)).ToString();
    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}
