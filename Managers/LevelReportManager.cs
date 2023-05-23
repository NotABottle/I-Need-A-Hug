using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReportManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI gotHuggedText;
    public TMPro.TextMeshProUGUI needHugsText;
    private string nameOfNextScene;

    private void Start(){
        var gotHuggedCount = PlayerPrefs.GetInt("GotHuggedCount");
        var needHugsCount = PlayerPrefs.GetInt("NeedHugsCount");
        nameOfNextScene = PlayerPrefs.GetString("NameOfNextScene");

        gotHuggedText.text = gotHuggedCount + " PEOPLE GOT HUGS";
        needHugsText.text = needHugsCount + " PEOPLE STILL NEED HUGS";
    }

    public void ContinueToNextLevel(){
        SceneManager.LoadScene(nameOfNextScene);
    }
}
