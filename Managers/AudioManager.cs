using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] Sounds;

    private void OnEnable() => EventManager.StartListening("playSound",Play);

    private void OnDisable() => EventManager.StopListening("playSound",Play);

    void Awake(){
        if(instance != null && instance != this){
            Destroy(this);
        }else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        InitializeAudioSources();        
    }

    private void InitializeAudioSources(){
        foreach(Sound s in Sounds){
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
        }
    }

    private void Play(Dictionary<string, object> message){
        var soundToPlay = (string) message["soundName"];
        foreach(Sound s in Sounds){
            if(s.name.Equals(soundToPlay)){
                s.audioSource.Play();
            }
        }
    }
}

[System.Serializable]
public class Sound{
    public string name;
    public AudioClip clip;
    public float volume;
    public AudioSource audioSource;
}

