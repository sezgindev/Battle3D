using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour, IDamageable
{
    private IEnemy _enemyController;
    private EnemySettings _enemySettings;
    private float _health;
    [SerializeField] private Image _healthFillImage;

    private void Awake()
    {
        _enemyController = GetComponent<IEnemy>();
        _enemySettings = _enemyController.GetEnemySettings();
        _health = _enemySettings.Health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        //TODO: Damage text particle add (Particle anim)
        //  SetHealthBar();
        if (_health <= 0)
        {
            Die();
        }
    }

    private void SetHealthBar()
    {
        var a = Mathf.InverseLerp(100, 0, _health);
        var b = Mathf.Lerp(1, 0, a);
        _healthFillImage.DOFillAmount(b, .15f);
    }

    private void Die()
    {
        ParticleManager.Instance.EnemyDieParticle(transform.position);
        EventManager.OnSpawnOre?.Invoke(_enemySettings.EnemyType, gameObject.transform.position);
        Destroy(this.gameObject);
    }
}