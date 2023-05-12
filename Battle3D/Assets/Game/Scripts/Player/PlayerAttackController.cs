using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private BulletController _bulletObject;
    [SerializeField] private Transform _bulletSpawnPos;
    private PlayerMovementController _playerMovementController;
    private bool _isShoot = false;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerMovementController.PlayerInput.PlayerMovement.Shoot.started += OnShoot;
    }


    private void OnShoot(InputAction.CallbackContext context)
    {
        _isShoot = context.ReadValueAsButton();
        if (!_isShoot) return;
        BulletController bullet = Instantiate(_bulletObject, _bulletSpawnPos.position, Quaternion.identity);
        bullet.Shoot();
    }
}