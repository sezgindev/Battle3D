using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private CollectableTypes _collectableType;
    [SerializeField] private CollectableSettings _collectableSettings;
    private float _destroyCountDown = 1.0f;

    enum CollectableTypes
    {
        HealthBox,
        SpeedBoost,
        Bullet,
    }

    private void OnEnable()
    {
        CountDownToDestroy();
    }

    public void TakeCollectable()
    {
        if (_collectableType == CollectableTypes.HealthBox)
        {
            EventManager.OnTakeHealthBox?.Invoke(_collectableSettings.HealthCollectableHealthAmount);
        }
        else if (_collectableType == CollectableTypes.HealthBox)
        {
            EventManager.OnTakeSpeedBoost?.Invoke(_collectableSettings.SpeedoostAmount);
        }
        else if (_collectableType == CollectableTypes.Bullet)
        {
            EventManager.OnTakeBullet?.Invoke(GetComponent<SpawnedBullet>().BulletAmount);
        }
    }

    private void CountDownToDestroy()
    {
        float to = _destroyCountDown;
        float balance = 0;
        DOTween.To(() => balance, x => balance = x, to, 10.0f).OnComplete(() => { Destroy(gameObject); });
    }
}