using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private PlayerHealthController _playerHealthController;
    private PlayerAttackController _playerAttackController;
    public PlayerSettings PlayerSettings;
    private Camera _mainCamera;
    [SerializeField] private GameObject _playerUICanvas;

    private void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
        _playerAttackController = GetComponent<PlayerAttackController>();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        EventManager.OnTakeBullet += ReloadBullet;
    }

    private void OnDisable()
    {
        EventManager.OnTakeBullet -= ReloadBullet;
    }

    private void LateUpdate()
    {
        _playerUICanvas.transform.DOLookAt(_mainCamera.transform.position, .1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable collectable = other.GetComponent<IInteractable>();
        if (collectable != null)
        {
            collectable.TakeCollectable();
            Destroy(other.gameObject);
        }
    }


    private void ReloadBullet(float bulletAmount) => _playerAttackController.Reload(bulletAmount);
    public void TakeDamage(float damage) => _playerHealthController.TakeDamage(damage);
    private void TakeHealthBox(float heathIncreaseAmount) => _playerHealthController.TakeHealthBox(heathIncreaseAmount);
}