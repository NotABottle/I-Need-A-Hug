using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public int numberOfPeopleWhoHaveBeenHugged;
    public int numberOfPeopleWhoNeedHugs;

    public List<PersonStateController> listOfPeople;
    private List<PersonStateController> listOfPeopleWhoNeedHugs;
    private List<PersonStateController> listOfPeopleWhoHaveBeenHugged;

    private void OnEnable(){
        EventManager.StartListening("OnPersonStateChange",CheckForCompletion);
        EventManager.StartListening("OnReachEndOfLevel",UploadLevelStats);
    }

    private void OnDisable(){
        EventManager.StopListening("OnPersonStateChange",CheckForCompletion);
        EventManager.StopListening("OnReachEndOfLevel",UploadLevelStats);
    }

    private void UploadLevelStats(Dictionary<string, object> dictionary)
    {
        PlayerPrefs.SetInt("GotHuggedCount",numberOfPeopleWhoHaveBeenHugged);
        PlayerPrefs.SetInt("NeedHugsCount",numberOfPeopleWhoNeedHugs);
    }

    private void Awake(){
        listOfPeopleWhoNeedHugs = new List<PersonStateController>();
        listOfPeopleWhoHaveBeenHugged = new List<PersonStateController>();

        foreach(PersonStateController person in listOfPeople.ToArray()){
            if(person.personState == PersonState.NeedHug){
                listOfPeopleWhoNeedHugs.Add(person);
            }
        }
    }

    private void CheckForCompletion(Dictionary<string, object> dictionary)
    {
        foreach(PersonStateController person in listOfPeopleWhoNeedHugs.ToArray()){
            if(person.personState != PersonState.NeedHug){
                listOfPeopleWhoHaveBeenHugged.Add(person);
                listOfPeopleWhoNeedHugs.Remove(person);
            }
        }

        numberOfPeopleWhoHaveBeenHugged = listOfPeopleWhoHaveBeenHugged.Count;
        Debug.Log(numberOfPeopleWhoHaveBeenHugged + " people have gotten a hug! :D");

        numberOfPeopleWhoNeedHugs = listOfPeopleWhoNeedHugs.Count;
        Debug.Log(numberOfPeopleWhoNeedHugs + " people need hugs!");

    }
}
