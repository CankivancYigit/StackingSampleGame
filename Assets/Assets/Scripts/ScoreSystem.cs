using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    
    private int _coinCount = 0;

    public int CoinCount
    {
        get => _coinCount;
        set => _coinCount = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerPrefs.HasKey("SavedCoinAmount"))
        {
            _coinCount = PlayerPrefs.GetInt("SavedCoinAmount");
        }
    }

    public void ChangeCoinCount(int gain)
    {
        _coinCount += gain;
    }
    
    public void SaveCoinAmount()
    {
        PlayerPrefs.SetInt("SavedCoinAmount",_coinCount);
    }
}
