using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnedBullet _spawnObjectPrefab;
    [SerializeField] private GameObject _spawnGroundArea;
    private MeshCollider _spawnAreaCollider;

    private void Start()
    {
        _spawnAreaCollider = _spawnGroundArea.GetComponent<MeshCollider>();
        InvokeRepeating(nameof(SpawnBullet), 5.0f, 5.0f);
    }


    private Vector3 GetBulletsSpawnPoint()
    {
        Vector3 spawnPos;
        Bounds spawnAreaMeshBounds = _spawnAreaCollider.bounds;
        spawnPos.x = Random.Range(spawnAreaMeshBounds.max.x, spawnAreaMeshBounds.min.x);
        spawnPos.z = Random.Range(spawnAreaMeshBounds.max.z, spawnAreaMeshBounds.min.z);
        spawnPos.y = 0f;
        return spawnPos;
    }


    private void SpawnBullet()
    {
        Vector3 spawnPos = GetBulletsSpawnPoint();
        SpawnedBullet spawnedBullet = Instantiate(_spawnObjectPrefab, spawnPos, Quaternion.identity);
        spawnedBullet.BulletAmount = 10;
    }
}