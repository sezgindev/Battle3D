using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "OreSettings", menuName = "ScriptableObjects/OreSettings")]
public class OreSettings : ScriptableObject
{
    [SerializeField] private OreTypes _oreType;
    [SerializeField] private int _xp;
    [SerializeField] private GameObject _oreObjectPrefab;
    
    public enum OreTypes
    {
        BasicOre,
        BossOre
    }

    public OreTypes OreType => _oreType;
    public GameObject OreObject => _oreObjectPrefab;
    public int Xp => _xp;
    
}