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
        SetHealthBar(_health);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        _health -= damage;
        SetHealthBar(_health);
    }

    public void TakeHealthBox(float heathIncreaseAmount)
    {
        _health += heathIncreaseAmount;
        ParticleManager.Instance.HealParticle(transform.position);
        SetHealthBar(_health);
    }

    private void SetHealthBar(float health)
    {
    }
}