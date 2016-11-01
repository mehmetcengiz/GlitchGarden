﻿using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(-1f,1.5f)]
    public float walkSpeed;

	// Use this for initialization
	void Start () {
	    Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
	    myRigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D() {
        Debug.Log(name + " trigger enter");
    }
}
