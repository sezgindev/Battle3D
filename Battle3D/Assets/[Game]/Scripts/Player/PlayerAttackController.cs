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
    private int _bulletMagazine = 7;
    private bool _isShoot = false;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerMovementController.PlayerInput.PlayerMovement.Shoot.started += OnShoot;
    }


    private void OnShoot(InputAction.CallbackContext context)
    {
        if (_bulletMagazine > 0)
        {
            _isShoot = context.ReadValueAsButton();
            if (!_isShoot) return;
            BulletController bullet = Instantiate(_bulletObject, _bulletSpawnPos.position, Quaternion.identity);
            bullet.Shoot();
            _bulletMagazine -= 1;
        }
        else
        {
            NoBullet();
        }
    }

    private void NoBullet()
    {
        ParticleManager.Instance.NoBulletParticle(transform.position + Vector3.up + (2 * Vector3.right));
    }

    public void Reload(float bulletAmount)
    {
        _bulletMagazine = (int)bulletAmount;
    }
}