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
	[SerializeField] private TextMeshProUGUI header;
	[SerializeField] private GameObject tapToPlayPanel;
	[SerializeField] private GameObject upgradeButton;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	private void OnEnable()
	{
		GameManager.GameStartedEvent += OnGameStarted;
	}

	private void OnDisable()
	{
		GameManager.GameStartedEvent -= OnGameStarted;
	}

	public void SetCoinAmountText()
	{
		coinText.text = ScoreSystem.Instance.CoinCount.ToString();
	}

	public void SetLevelText()
	{
		//levelText.text = "Level" + 
	}
		
	private void OnGameStarted()
	{
		tapToPlayPanel.SetActive(false);
		header.gameObject.SetActive(false);
		upgradeButton.SetActive(false);
	}
}