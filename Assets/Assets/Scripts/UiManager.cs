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
	[SerializeField] private GameObject successPanel;

	public GameObject SuccessPanel => successPanel;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	private void Start()
	{
		SetCoinAmountText();
		SetLevelText();
	}

	private void OnEnable()
	{
		UpgradeButton.upgradeButtonClickedEvent += OnUpgradeButtonClicked;
	}

	private void OnDisable()
	{
		UpgradeButton.upgradeButtonClickedEvent -= OnUpgradeButtonClicked;
	}
	
	public void SetCoinAmountText()
	{
		coinText.text = ScoreSystem.Instance.CoinCount.ToString();
	}

	public void SetLevelText()
	{
		levelText.text = "Level " + LevelManager.Instance.LevelNumber;
	}
		
	private void OnUpgradeButtonClicked()
	{
		SetCoinAmountText();
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