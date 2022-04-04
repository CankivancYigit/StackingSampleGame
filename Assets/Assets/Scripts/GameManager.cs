using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum States
    {
        TapToPlay,
        Game,
        GameEnd
    }
    
    private States _states;


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

                for (int i = 0; i < Player.Instance.characters.Count; i++)
                {
                    if (Player.Instance.characters[i].GetComponent<Animator>().GetBool("Run 1") != true)
                    {
                        Player.Instance.characters[i].GetComponent<Animator>().SetBool("Run 1",true);
                    }
                }
               
                return;
            case States.GameEnd:
                
                return;
        }
    }
    
    private void OnGameStarted()
    {
        _states = States.Game;
    }
}
