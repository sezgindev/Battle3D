using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnSpawnOre += SpawnOre;
    }

    private void OnDisable()
    {
        EventManager.OnSpawnOre -= SpawnOre;
    }

    private void SpawnOre(OreSettings ore, Vector3 spawnPos)
    {
        Instantiate(ore.OreObject, spawnPos, Quaternion.identity);
    }
}