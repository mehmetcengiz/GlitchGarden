using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile,gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start() {
        animator = GameObject.FindObjectOfType<Animator>();
        
        //Creates a parent if necessary
        SetProjectileParent();
        SetMyLaneSpawner();
    }

    void Update() {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);   
        }
    }

    //Look through all spawners, and set myLaneSpanwer if found.
    void SetMyLaneSpawner() {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "can't find spawner in lane");

    }

    bool IsAttackerAheadInLane() {
        //if there is no child.
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        //if there is attacker, are they ahead?
        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        //There is attacker but behind us.
        return false;
    }

    void SetProjectileParent() {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }
    private void Fire() {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
