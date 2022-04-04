using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	public static UiManager Instance;

	public delegate void GameStarted();

	public static event GameStarted GameStartedEvent;
	
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI coinText;
	[SerializeField] private TextMeshProUGUI header;
	[SerializeField] private GameObject tapToPlayPanel;
	[SerializeField] private GameObject upgradeButton;
	[SerializeField] private GameObject gameStartButton;

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
		//levelText.text = "Level" + 
	}
		
	public void GameStartButtonClicked()
	{
		if (GameStartedEvent != null)
		{
			GameStartedEvent();
		}
		
		tapToPlayPanel.SetActive(false);
		header.gameObject.SetActive(false);
		upgradeButton.SetActive(false);
	}
}