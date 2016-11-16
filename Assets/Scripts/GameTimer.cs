using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{

    public float levelSecond = 100f;

    private Slider slider;
    private AudioSource audioSource;
    private bool isLevelEnded = false;
    private LevelManager levelManager;
    private GameObject winMassage;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FİndYouWin();
        winMassage.SetActive(false);
    }

    private void FİndYouWin() {
        winMassage = GameObject.Find("You Win");
        if (!winMassage) {
            Debug.LogError("Please Create You Win GameObject.");
        }
    }

    // Update is called once per frame
    void Update() {
        slider.value = Time.timeSinceLevelLoad/levelSecond;
        if (Time.timeSinceLevelLoad >= levelSecond && !isLevelEnded) {
            WinCondition();
        }
    }

    private void WinCondition() {
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        isLevelEnded = true;
        winMassage.SetActive(true);
    }

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
