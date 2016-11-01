using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(-1f,1.5f)]
    public float CurrentSpeed;

	// Use this for initialization
	void Start () {
	    Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
	    myRigidbody2D.isKinematic = true;
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

    public void StrikeCurrentTarget(float damage) {
        Debug.Log(name + " is attacking to target with damage: " + damage);
    }
}
