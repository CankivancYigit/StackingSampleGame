using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    public static bool ReachedLastLevel = false;

    private string SavedLevel = "SavedLevel";
    private int _currentSceneIndex;
    private static int _levelNumber;

    public int LevelNumber => _levelNumber;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (!ReachedLastLevel)
        {
            _levelNumber = _currentSceneIndex + 1;
        }
        
        if (PlayerPrefs.HasKey(SavedLevel))
        {
            _levelNumber = PlayerPrefs.GetInt(SavedLevel);
        }
    }
    
    private void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
        
    public void ReloadLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        _levelNumber++;
        
        int nextSceneIndex = _currentSceneIndex + 1;

        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        if (nextSceneIndex == totalSceneCount)
        {
            ReachedLastLevel = true;
        }

        if (ReachedLastLevel)
        {
            nextSceneIndex = 0;
        }

        LoadLevel(nextSceneIndex);
        SaveLevel();
    }
    
    public void SaveLevel()
    {
        PlayerPrefs.SetInt(SavedLevel,_levelNumber);
    }
}
