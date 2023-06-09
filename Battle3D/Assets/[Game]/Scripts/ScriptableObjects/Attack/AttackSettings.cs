using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSettings", menuName = "ScriptableObjects/AttackSettings")]

public class AttackSettings : ScriptableObject
{
    [SerializeField] private float _bulletDamage;

    public float BulletDamage => _bulletDamage;
}