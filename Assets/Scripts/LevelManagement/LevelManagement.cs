using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    [SerializeField] private int level1_SceneBuildIndex;
    [SerializeField] private int menuSceneBuildIndex;
    [SerializeField] private int winSceneBuildIndex;

    public void RestartCurrentLevel()
    {
        LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadStartLevel()
    {
        LoadSceneWithIndex(level1_SceneBuildIndex);
    }

    public void LoadNextLevel()
    {
        LoadSceneWithIndex(GetNextLevelIndex());
    }

    public void LoadMenu()
    {
        LoadSceneWithIndex(menuSceneBuildIndex);
    }

    public void LoadWinScene()
    {
        LoadSceneWithIndex(winSceneBuildIndex);
    }

    private int GetNextLevelIndex()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index < SceneManager.sceneCountInBuildSettings)
            return index;
        else
            return winSceneBuildIndex;
    }

    private void LoadSceneWithIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
