using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private GameObject SavedPlayer;
    
    public List<GameObject> characters = new List<GameObject>();

    [SerializeField] private GameObject stackCharacterPrefab;
    [SerializeField] private int maxStackAmount = 10;
    [SerializeField] private float stackGap;
    [SerializeField] private GameObject stackBar;
    
    [SerializeField] private float objectStackAnimDelay = 0.2f;
    [SerializeField] private float horizontalMoveDelay = 0.1f;
    
    private Vector3 objectScale;
    
    public int MaxStackAmount => maxStackAmount;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        if (ES3.KeyExists("SavedCharacter"))
        { 
            ES3.Load("SavedCharacter",gameObject);
        }
    }

    private void Start()
    {
       objectScale  = characters[0].transform.localScale;
       stackBar.SetActive(false);
    }

    private void OnEnable()
    {
        UiManager.GameStartedEvent += OnGameStarted;
        UpgradeButton.upgradeButtonClickedEvent += OnUpgradeButtonClicked;

        for (int i = 1; i < characters.Count; i++) //For Easy Save 3 RuntimeAnimController Loading Problem ??
        {
            if (characters[i].GetComponent<Animator>().runtimeAnimatorController == null)
            {
                characters[i].GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Resources/Character") as RuntimeAnimatorController;
            }
        }
    }

    private void OnDisable()
    {
        UiManager.GameStartedEvent -= OnGameStarted;
        UpgradeButton.upgradeButtonClickedEvent -= OnUpgradeButtonClicked;
    }
    
    private void Update()
    {
        HorizontalMoveObjectsWithDelay();
    }

    public void StackObjects(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = characters[index].transform.localPosition;
        Quaternion newRotation = characters[index].transform.localRotation;
        newPos.z += stackGap;
        other.transform.localPosition = newPos;
        other.transform.localRotation = newRotation;
        StartCoroutine(ObjectStackingAnim());
    }

    public IEnumerator ObjectStackingAnim()
    {
        for (int i = characters.Count - 1; i >= 0; i--)
        {
            Vector3 animObjectScale = objectScale * 1.5f;

            characters[i].transform.DOScale(animObjectScale, 0.1f);
                yield return new WaitForSeconds(objectStackAnimDelay);
                characters[i].transform.DOScale(objectScale, 0.1f);
        }
    }

    public void HorizontalMoveObjectsWithDelay()
    {
        for (int i = 1; i < characters.Count; i++)
        {
            Vector3 pos = characters[i].transform.position;
            pos.x = characters[i - 1].transform.position.x;
            characters[i].transform.DOMoveX(pos.x, horizontalMoveDelay);
        }
    }
    
    private void OnGameStarted()
    {
        stackBar.SetActive(true);

        if (characters.Count == maxStackAmount)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].GetComponent<Animator>().GetBool("Run 2") != true)
                {
                    characters[i].GetComponent<Animator>().SetBool("Run 2",true);
                }
            }
        }
        else
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].GetComponent<Animator>().GetBool("Run 1") != true)
                {
                    characters[i].GetComponent<Animator>().SetBool("Run 1",true);
                }
            } 
        }
    }
    
    private void OnUpgradeButtonClicked()
    {
        if (characters.Count < maxStackAmount)
        {
            var newStackCharacter = Instantiate(stackCharacterPrefab, characters[characters.Count - 1].transform.localPosition,characters[characters.Count - 1].transform.localRotation);
            StackObjects(newStackCharacter,characters.Count - 1);
            newStackCharacter.tag = "Untagged";
            characters.Add(newStackCharacter);
            SaveCharacter();
        }
    }
    
    public void SaveCharacter()
    {
        ES3.Save("SavedCharacter", gameObject);
    }
}
