using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private AttackSettings _attackSettings;
    private const int _playerLayer = 6;
    private Rigidbody _rb;
    private GameObject _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = FindObjectOfType<PlayerController>().gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            EventManager.OnTakeDamage?.Invoke(_attackSettings.BulletDamage);
        }
    }

    public void Shoot()
    {
        _rb.AddForce(_player.transform.forward * 20, ForceMode.Impulse);
    }
}