using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private TextMeshPro _healthText;

    private void Start()
    {
        SetHealth(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        SetHealth(_health);
    }

    public void TakeHealthBox(float heathIncreaseAmount)
    {
        _health += heathIncreaseAmount;
        ParticleManager.Instance.HealParticle(transform.position);
        SetHealth(_health);
    }

    private void SetHealth(float health)
    {
    }
}