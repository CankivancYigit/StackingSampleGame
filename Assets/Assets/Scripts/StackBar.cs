using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackBar : MonoBehaviour
{
    public Image stackFill;
    
    void Start()
    {
        stackFill.fillAmount = (float)Player.Instance.characters.Count / (float)Player.Instance.MaxStackAmount;
    }

    public void UpdateStackBar()
    {
        stackFill.fillAmount = (float)Player.Instance.characters.Count / (float)Player.Instance.MaxStackAmount;
    }
}
