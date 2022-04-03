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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_states)
        {
            case States.TapToPlay:
                if (Input.GetMouseButtonDown(0))
                {
                    _states = States.Game;
                }
                return;
            case States.Game:
                if (Player.Instance.characters[0].GetComponent<Animator>().GetBool("Run 1") != true)
                {
                    Player.Instance.characters[0].GetComponent<Animator>().SetBool("Run 1",true);
                }
                return;
            case States.GameEnd:
                return;
        }
    }
}
