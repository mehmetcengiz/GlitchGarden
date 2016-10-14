using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusicChangeArray;

    private AudioSource _audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: "+ name);
    }

    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int levelIndex) {
        AudioClip thisLevelMusic = LevelMusicChangeArray[levelIndex];

        Debug.Log("Playing Clip: " + thisLevelMusic);

        if (thisLevelMusic) { // If some music attachted.
            _audioSource.clip = thisLevelMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }

    }
}
