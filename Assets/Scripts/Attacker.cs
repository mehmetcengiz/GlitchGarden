using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private GameObject CurrentTarget;
    private float CurrentSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D() {
        Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float Speed) {
        this.CurrentSpeed = Speed;
    }

    //Called from the animator at the time of actual blow
    public void StrikeCurrentTarget(float damage) {
        Debug.Log(name + " is attacking to target with damage: " + damage);
    }

    public void Attack(GameObject obj) {
        CurrentTarget = obj;
    }
}
