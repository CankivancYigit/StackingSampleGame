using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinText;
    
    private void Awake()
    {
	    if (Instance == null)
	    {
		    Instance = this;
	    }
    }

    public void SetCoinAmountText()
    {
	    coinText.text = ScoreSystem.Instance.CoinCount.ToString();
    }

    public void SetLevelText()
    {
	    
    }
}
