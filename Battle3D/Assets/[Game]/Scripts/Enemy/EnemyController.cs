using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BulletController _bulletObject;
    [SerializeField] private Transform _bulletSpawnPos;
    private NavMeshAgent _agent;
    private Transform _player;
    private EnemyStates _enemyState;
    public EnemySettings EnemySettings;

    private enum EnemyStates
    {
        Follow,
        Attack
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>().transform;
        _agent.SetDestination(_player.position);
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.LookAt(_player);
        _agent.SetDestination(_player.position);
        if (_agent.remainingDistance <= 10.0f)
        {
            ChangeState(EnemyStates.Attack);
            _agent.speed = 0;
        }
        else
        {
            ChangeState(EnemyStates.Follow);
            _agent.speed = 3;
        }
    }

    private void ChangeState(EnemyStates state)
    {
        if (_enemyState == state) return;
        _enemyState = state;
        if (_enemyState == EnemyStates.Attack)
        {
            StartCoroutine(AttackToPlayer());
        }
    }

    private IEnumerator AttackToPlayer()
    {
        while (true)
        {
            BulletController bullet = Instantiate(_bulletObject, _bulletSpawnPos.position, Quaternion.identity);
            bullet.DamageInit(EnemySettings.Damage);
            bullet.Shoot();
            yield return new WaitForSeconds(1.0f);
        }
    }
}