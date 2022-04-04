using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    
    private static int _upgradeCost = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeCostText.text = _upgradeCost.ToString();
    }

    private void Update()
    {
        if (ScoreSystem.Instance.CoinCount >_upgradeCost)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void UpgradeButtonClicked()
    {
        _upgradeCost = (int)Mathf.Pow(_upgradeCost, 1.05f);
        upgradeCostText.text = _upgradeCost.ToString();
    }
}