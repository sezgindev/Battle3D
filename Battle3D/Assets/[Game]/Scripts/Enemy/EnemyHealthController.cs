using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour, IDamageable
{
    private EnemyController _enemyController;
    private EnemySettings _enemySettings;
    private float _health;
    [SerializeField] private Image _healthFillImage;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _enemySettings = _enemyController.EnemySettings;
        _health = _enemySettings.Health;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(_health);
        _health -= damage;
        SetHealthBar();
        if (_health <= 0)
        {
            Die();
        }
    }

    private void SetHealthBar()
    {
        //TODO:Set Enemy Health Bar
    }

    private void Die()
    {
        //TODO:Set Enemy Health Die
    }
}