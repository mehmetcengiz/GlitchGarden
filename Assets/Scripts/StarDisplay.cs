using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE}

    private Text starText;
    private int stars = 400;

    void Start() {
        starText = GetComponent<Text>();
        UpdateDisplayStars();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplayStars();
    }


    public Status UseStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplayStars();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplayStars() {
        starText.text = stars.ToString();
    }
}
