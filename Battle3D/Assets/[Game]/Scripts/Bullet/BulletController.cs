using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private AttackSettings _attackSettings;
    private const int _playerLayer = 6;
    private const int _enemyLayer = 6;
    private Transform _targetTransform;
    private Rigidbody _rb;

    private void Awake()
    {
        _targetTransform = FindObjectOfType<PlayerController>().transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            EventManager.OnTakeDamage?.Invoke(_attackSettings.BulletDamage);
        }

        if (other.gameObject.layer == _enemyLayer)
        {
            EventManager.OnShootEnemy?.Invoke(_attackSettings.BulletDamage);
            Destroy(gameObject);
        }
    }

    public void Shoot(Transform target = null)
    {
        if (target == null)
        {
            transform.DOLookAt(_targetTransform.transform.position, .0f);
            Vector3 dir = transform.position - _targetTransform.position;
            _rb.AddForce(dir.normalized * -25, ForceMode.Impulse);
     
        }
        else
        {
            _rb.AddForce(target.forward * 25, ForceMode.Impulse);
            transform.DORotateQuaternion(target.rotation, .0f);
        }
    }
}