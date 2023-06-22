using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;
    private PlayerAttackController _playerAttackController;
    private PlayerInput _playerInput;
    private const int _spawnedBulletLayer = 8;

    private void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
        _playerAttackController = GetComponent<PlayerAttackController>();
    }

    private void OnEnable()
    {
        EventManager.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        EventManager.OnTakeDamage -= TakeDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _spawnedBulletLayer)
        {
        }
    }

    private void ReloadBullet()
    {
        _playerAttackController.Reload();
    }

    private void TakeDamage(float damage)
    {
        _playerHealthController.TakeDamage(damage);
    }
}