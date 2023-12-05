using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform _targetTransform;
    private Rigidbody _rb;
    private float _damage = 0;

    public void DamageInit(float damage)
    {
        _damage = damage;
    }

    private void Awake()
    {
        _targetTransform = FindObjectOfType<PlayerController>().transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable obj = other.GetComponent<IDamageable>();
        obj?.TakeDamage(_damage);
        Destroy(gameObject);
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