using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform start;
    public String nameOfNextScene;

    private Transform player;

    private void OnEnable(){
        EventManager.StartListening("OnResetLevel",ResetLevel);
        EventManager.StartListening("OnReachEndOfLevel",EndLevel);
    }
    private void OnDisable(){
        EventManager.StopListening("OnResetLevel",ResetLevel);
        EventManager.StopListening("OnReachEndOfLevel",EndLevel);
    }

    private void Awake(){
        player = GameObject.Find("Monkey").transform;
        InitializeLevel();
    }

    private void InitializeLevel(){
        player.position = start.position;
        PlayerPrefs.SetString("NameOfNextScene", nameOfNextScene);
    }

    private void ResetLevel(Dictionary<string, object> dictionary)
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    private void EndLevel(Dictionary<string, object> dictionary)
    {
        SceneManager.LoadScene("LevelReport");
    }
}
