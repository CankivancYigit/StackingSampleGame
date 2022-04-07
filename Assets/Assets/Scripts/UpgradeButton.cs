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
    }

    void Start()
    {
        upgradeCostText.text = _upgradeCost.ToString();
        
        //ES3.Load("SavedCharacter",Player.Instance.gameObject);
    }

    private void LateUpdate()
    {
        if (ScoreSystem.Instance.CoinCount >_upgradeCost)
        {
            if (Player.Instance.characters.Count < Player.Instance.MaxStackAmount)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
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
        
        //SaveCharacter();
    }
    
    public void SaveUpgradeCost()
    {
        PlayerPrefs.SetInt("SavedUpgradeCost",_upgradeCost);
    }
}
