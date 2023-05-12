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
        SetHealthText(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        SetHealthText(_health);
    }

    private void SetHealthText(float health) => _healthText.SetText(health.ToString());
}