using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyFactory : EnemyFactory
{
    [SerializeField] private BossEnemyController _bossEnemyPrefab;
    

    public override IEnemy CreateEnemy(Vector3 spawnPos)
    {
        GameObject bossEnemyInstance = Instantiate(_bossEnemyPrefab.gameObject, spawnPos, Quaternion.identity);
        BossEnemyController bossEnemy = bossEnemyInstance.GetComponent<BossEnemyController>();

        bossEnemy.Initialize();
        return bossEnemy;
    }
}