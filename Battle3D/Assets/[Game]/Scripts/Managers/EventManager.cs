using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityAction<float> OnTakeDamage;
    public static UnityAction<float> OnShootEnemy;
    public static UnityAction<float> OnTakeHealthBox;
    public static UnityAction<float> OnTakeSpeedBoost;
    public static UnityAction<float> OnTakeBullet;
    public static UnityAction<OreSettings,Vector3> OnSpawnOre;
}
