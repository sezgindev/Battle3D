using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;
    private PlayerInput _playerInput;
    


    private void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
    }

    private void OnEnable()
    {
        EventManager.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        EventManager.OnTakeDamage -= TakeDamage;
    }

    public void TakeDamage(float damage)
    {
        _playerHealthController.TakeDamage(damage);
    }
}