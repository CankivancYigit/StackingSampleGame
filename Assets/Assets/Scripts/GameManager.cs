using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public enum States
    {
        TapToPlay,
        Game,
        GameEnd
    }
    
    public States _states;
    
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    
    public CinemachineVirtualCamera CinemachineVirtualCamera
    {
        get => _cinemachineVirtualCamera;
        set => _cinemachineVirtualCamera = value;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        UiManager.GameStartedEvent += OnGameStarted;
    }

    private void OnDisable()
    {
        UiManager.GameStartedEvent -= OnGameStarted;
    }
    
    private void Start()
    {
        PlayerController.Instance.CurrentSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_states)
        {
            case States.TapToPlay:
               
                return;
            case States.Game:

                if (PlayerController.Instance.CurrentSpeed == 0)
                {
                    PlayerController.Instance.CurrentSpeed = PlayerController.Instance.speed;
                }
                
                return;
            case States.GameEnd:

                if (!UiManager.Instance.SuccessPanel.activeInHierarchy)
                {
                    UiManager.Instance.SuccessPanel.SetActive(true);
                    Debug.Log("abc");
                }
                
                return;
        }
    }
    
    private void OnGameStarted()
    {
        _states = States.Game;
    }
}
