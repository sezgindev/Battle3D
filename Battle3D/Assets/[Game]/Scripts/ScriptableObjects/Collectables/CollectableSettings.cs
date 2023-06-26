using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableSettings", menuName = "ScriptableObjects/CollectableSettings")]
public class CollectableSettings : ScriptableObject
{
    [SerializeField] private float _healthCollectableHealthAmount;
    [SerializeField] private float _speedBoostAmount;
    public float HealthCollectableHealthAmount => _healthCollectableHealthAmount;
    public float SpeedoostAmount => _speedBoostAmount;

}
