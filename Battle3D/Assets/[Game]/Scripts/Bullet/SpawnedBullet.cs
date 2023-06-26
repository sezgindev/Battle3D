using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnedBullet : MonoBehaviour
{
    private TextMeshPro _bulletAmountText;
    private int _bulletAmount;


    private void Awake()
    {
        _bulletAmountText = GetComponentInChildren<TextMeshPro>();
    }

    public int BulletAmount
    {
        set
        {
            _bulletAmount = value;
            SetBulletAmountText();
        }
        get => _bulletAmount;
    }

    private void SetBulletAmountText() => _bulletAmountText.SetText(_bulletAmount.ToString());
}