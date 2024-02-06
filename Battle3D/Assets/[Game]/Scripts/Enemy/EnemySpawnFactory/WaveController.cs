using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveController : MonoBehaviour
{
    [SerializeField] private EnemyFactory[] factories;
    private EnemyFactory _enemyFactory;
    private int _spawnedEnemyCount = 0;


    private bool _isSpawnable = true;
    public float spawnRadius = 6f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private Vector3 SpawnObjectsAroundCharacter()
    {
        Vector3 spawnPos = Vector3.back;
        int i = Random.Range(0, 360);
        float angle = Mathf.Deg2Rad * i;
        spawnPos = new Vector3(Mathf.Cos(angle) * spawnRadius, 0f, Mathf.Sin(angle) * spawnRadius);
        return spawnPos;
    }


    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_isSpawnable)
            {
                _spawnedEnemyCount += 1;
                if (_spawnedEnemyCount % 10 == 0)
                {
                    _enemyFactory = factories[1];
                }
                else
                {
                    _enemyFactory = factories[0];
                }


                Vector3 spawnPos = SpawnObjectsAroundCharacter();
                _enemyFactory.CreateEnemy(spawnPos);
            }

            yield return new WaitForSeconds(2.0f);
        }
    }
}