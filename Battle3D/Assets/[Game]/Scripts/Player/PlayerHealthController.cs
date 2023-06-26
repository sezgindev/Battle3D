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
        SetHealt(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        SetHealt(_health);
    }

    public void TakeHealthBox(float heathIncreaseAmount)
    {
        _health += heathIncreaseAmount;
        ParticleManager.Instance.HealParticle(transform.position);
        SetHealt(_health);
    }

    private void SetHealt(float health)
    {
    }
}