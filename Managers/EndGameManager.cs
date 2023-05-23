using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public string nameOfMainMenu;

    public void MainMenu(){
        SceneManager.LoadScene(nameOfMainMenu);
    }
}
