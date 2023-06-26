using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager _instance;
    [SerializeField] private ParticleSystem _healParticle;
    private void OnEnable()
    {
        _instance = this;
    }
    public static ParticleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("ParticleManager").AddComponent<ParticleManager>();
            }
            return _instance;

        }

    }
    public void HealParticle(Vector3 spawnPos)
    {
        _healParticle = Instantiate(_healParticle, spawnPos, Quaternion.identity);
    }
}
