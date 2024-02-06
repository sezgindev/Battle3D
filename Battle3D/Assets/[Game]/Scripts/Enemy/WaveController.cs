using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveController : MonoBehaviour
{
    [SerializeField] private float _waveFrequency;

    [SerializeField] private EnemyController _enemyPrefab;

    [SerializeField] private float _waveCount;

    private float _timer;
    private bool _isSpawnable = false;
    private Transform _spawnPos;
    private int _tempWaveCount = 0;
    public float spawnRadius = 6f;

    private void Start()
    {
        StartCoroutine(WaveSpawn());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _waveFrequency)
        {
            _isSpawnable = true;
            _timer = 0;
        }
    }

    private Vector3 GetRandomSpawnPos()
    {
        Vector3 spawnPos = Vector3.zero;
        return spawnPos;
    }

    private Vector3 SpawnObjectsAroundCharacter()
    {
        Vector3 spawnPos = Vector3.back;
        int i = Random.Range(0, 360);
        float angle = Mathf.Deg2Rad * i;
        spawnPos = _enemyPrefab.transform.position +
                   new Vector3(Mathf.Cos(angle) * spawnRadius, 0f, Mathf.Sin(angle) * spawnRadius);


        return spawnPos;
    }

    private IEnumerator WaveSpawn()
    {
        while (true)
        {
            if (_isSpawnable)
            {
                Vector3 spawnPos = SpawnObjectsAroundCharacter();
                Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
                _tempWaveCount++;
                if (_tempWaveCount >= _waveCount)
                {
                    _tempWaveCount = 0;
                    _isSpawnable = false;
                }
            }

            yield return new WaitForSeconds(2.0f);
        }
    }
}