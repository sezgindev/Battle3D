using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveController : MonoBehaviour
{
    [SerializeField] private float _waveFrequency;

    [SerializeField] private EnemyController _enemyPrefab;

    [SerializeField] private List<Transform> _waveSpawnGates;

    [SerializeField] private float _waveCount;

    private float _timer;
    private bool _isSpawnable = false;
    private Transform _spawnPos;
    private int _tempWaveCount = 0;

    private void Start()
    {
        _spawnPos = _waveSpawnGates[(int)Random.Range(0, _waveSpawnGates.Count)];
        StartCoroutine(WaveSpawn());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _waveFrequency)
        {
            _isSpawnable = true;
            _timer = 0;
            _spawnPos = _waveSpawnGates[(int)Random.Range(0, _waveSpawnGates.Count)];
        }
    }


    private IEnumerator WaveSpawn()
    {
        while (true)
        {
            if (_isSpawnable)
            {
                Instantiate(_enemyPrefab, _spawnPos.position, Quaternion.identity);
                _tempWaveCount++;
                if (_tempWaveCount >= _waveCount)
                {
                    _tempWaveCount = 0;
                    _isSpawnable = false;
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}