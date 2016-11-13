using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starText;
    private int stars = 0;

    void Start() {
        starText = GetComponent<Text>();
    }

    public void AddStars(int amount) {
        stars += amount;
        DisplayStars();
    }


    private void UseStars(int amount) {
        stars -= amount;
        DisplayStars();
    }

    private void DisplayStars() {
        starText.text = stars.ToString();
    }
}
