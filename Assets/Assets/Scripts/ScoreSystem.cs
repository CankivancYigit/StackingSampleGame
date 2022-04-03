using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    private static int _totalCoinCount = 0;
    private int _coinCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseCoinCount(int gain)
    {
        _coinCount += gain;
        //UiManager.Instance.CoinText.text = _coinCount.ToString();
    }

    public void IncreaseTotalCoinCount()
    {
        _totalCoinCount += _coinCount;
    }
}
