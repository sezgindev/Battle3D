using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager _instance;
    [SerializeField] private ParticleSystem _healParticle;
    [SerializeField] private GameObject _noBulletParticlePrefab;
    private GameObject _noBulletParticle;

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

    public void NoBulletParticle(Vector3 spawnPos)
    {
        if (_noBulletParticle == null)
        {
            _noBulletParticle = Instantiate(_noBulletParticlePrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            _noBulletParticle.SetActive(false);
            _noBulletParticle.SetActive(true);
            _noBulletParticle.transform.GetChild(0).gameObject.SetActive(true);
            _noBulletParticle.transform.position = spawnPos;
        }
    }
    public void EnemyDieParticle(Vector3 pos)
    {
        //TODO: Die particle add
    }

}