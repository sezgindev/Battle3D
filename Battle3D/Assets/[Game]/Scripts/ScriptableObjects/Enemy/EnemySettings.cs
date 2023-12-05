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

    public float Health => _health;
    public EnemyTypes EnemyType => _enemyType;
    public float Damage => _damage;
}