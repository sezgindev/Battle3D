using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    [SerializeField] private OreSettings _bossOre;
    [SerializeField] private OreSettings _standardEnemyOre;

    private void OnEnable()
    {
        EventManager.OnSpawnOre += SpawnOre;
    }

    private void OnDisable()
    {
        EventManager.OnSpawnOre -= SpawnOre;
    }

    private void SpawnOre(EnemySettings.EnemyTypes enemyType, Vector3 spawnPos)
    {
        if (enemyType == EnemySettings.EnemyTypes.BasicEnemy)
        {
            var ore = _standardEnemyOre.OreObject;
            ore.PlayerXp = _standardEnemyOre.Xp;
            Instantiate(ore.gameObject, spawnPos, Quaternion.identity);
        }

        if (enemyType == EnemySettings.EnemyTypes.BossEnemy)
        {
            var ore = _bossOre.OreObject;
            ore.PlayerXp = _bossOre.Xp;
            Instantiate(ore.gameObject, spawnPos, Quaternion.identity);
        }
    }
}