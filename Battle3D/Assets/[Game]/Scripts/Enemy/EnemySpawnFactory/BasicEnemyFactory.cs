using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyFactory : EnemyFactory
{
    [SerializeField] private BasicEnemyController _basicEnemyController;


    public override IEnemy CreateEnemy(Vector3 spawnPos)
    {
        GameObject basicEnemyInstance = Instantiate(_basicEnemyController.gameObject, spawnPos, Quaternion.identity);
        BasicEnemyController basicEnemy = basicEnemyInstance.GetComponent<BasicEnemyController>();

        basicEnemy.Initialize();
        return basicEnemy;
    }
}