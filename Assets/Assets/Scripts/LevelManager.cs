using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    public static bool ReachedLastLevel = false;

    private const string SavedLevel = "SavedLevel";
    private int _currentSceneIndex;

    public int CurrentSceneIndex => _currentSceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        // Scene currentScene = SceneManager.GetActiveScene();
        // _currentSceneIndex = currentScene.buildIndex;
            
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
    }
}
