using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public delegate void UpgradeButtonClicked();

    public static event UpgradeButtonClicked upgradeButtonClickedEvent;
    
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    
    private static int _upgradeCost = 30;
    private static int _characterStackAmount;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("SavedUpgradeCost"))
        {
            _upgradeCost = PlayerPrefs.GetInt("SavedUpgradeCost");
        }
        
        if (PlayerPrefs.HasKey("SavedCharacterStackAmount"))
        {
            _characterStackAmount = PlayerPrefs.GetInt("SavedCharacterStackAmount");
        }
    }

    void Start()
    {
        upgradeCostText.text = _upgradeCost.ToString();
    }

    private void Update()
    {
        if (ScoreSystem.Instance.CoinCount >_upgradeCost && _characterStackAmount < Player.Instance.MaxStackAmount)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void UpgradeButtonClick()
    {
        _upgradeCost = (int)Mathf.Pow(_upgradeCost, 1.05f);
        upgradeCostText.text = _upgradeCost.ToString();
        
        ScoreSystem.Instance.ChangeCoinCount(-_upgradeCost);
        
        SaveUpgradeCost();
        
        ScoreSystem.Instance.SaveCoinAmount();
        if (upgradeButtonClickedEvent != null)
        {
            upgradeButtonClickedEvent();
        }
        
        SaveCharacterStackAmount();
    }
    
    public void SaveUpgradeCost()
    {
        PlayerPrefs.SetInt("SavedUpgradeCost",_upgradeCost);
    }

    public void SaveCharacterStackAmount()
    {
        PlayerPrefs.SetInt("SavedCharacterStackAmount", Player.Instance.characters.Count);
    }
}
