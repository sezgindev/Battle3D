using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private CollectableTypes _collectableType;
    [SerializeField] private CollectableSettings _collectableSettings;
    enum CollectableTypes
    {
        HealthBox,
        SpeedBoost,

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

    }
}
