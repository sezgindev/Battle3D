using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;
    private PlayerAttackController _playerAttackController;
    private const int _spawnedBulletLayer = 8;
    private const int _collectableLayer = 9;


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
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == _collectableLayer)
        {
            Destroy(other.gameObject);
            IInteractable collectable = other.GetComponent<IInteractable>();
            collectable?.TakeCollectable();
        }
    }

    private void ReloadBullet() => _playerAttackController.Reload();
    private void TakeDamage(float damage) => _playerHealthController.TakeDamage(damage);
    private void TakeHealthBox(float heathIncreaseAmount) => _playerHealthController.TakeHealthBox(heathIncreaseAmount);
}