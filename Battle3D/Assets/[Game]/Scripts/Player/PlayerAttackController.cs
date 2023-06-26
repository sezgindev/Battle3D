using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private BulletController _bulletObject;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField] private TextMeshPro _bulletText;
    private PlayerMovementController _playerMovementController;
    private int _bulletMagazine = 7;
    private bool _isShoot = false;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerMovementController.PlayerInput.PlayerMovement.Shoot.started += OnShoot;
        SetBulletText();
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
            SetBulletText();
        }
        else
        {
            NoBullet();
        }
    }

    private void NoBullet()
    {
        ParticleManager.Instance.NoBulletParticle(transform.position + Vector3.up + (1.2f * Vector3.right));
    }

    public void Reload(float bulletAmount)
    {
        _bulletMagazine = (int)bulletAmount;
       SetBulletText();
    }

    private void SetBulletText() => _bulletText.SetText(_bulletMagazine.ToString());
}