using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    public enum EnemyTypes
    {
        BasicEnemy,
        BossEnemy
    }

    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private OreSettings _deadSpawnOre;
    public float Health => _health;
    public OreSettings GetOre => _deadSpawnOre;
    public EnemyTypes EnemyType => _enemyType;
    public float Damage => _damage;
}