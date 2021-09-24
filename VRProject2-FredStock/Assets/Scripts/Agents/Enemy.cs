using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool alive = true;
    public GameObject arm;
    public GameObject crossbow;

    public GameObject practiceTarget;



    private float testTimer = 0f;
    private float testInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        loadWeapon();
        AimAt(practiceTarget.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        testTimer += Time.deltaTime;

        if (testTimer > testInterval)
        {
            testTimer -= testInterval;
            ShootAt(practiceTarget.transform.position);
        }
    }

    public bool isAlive() { return alive; }

    public void Killed()
    {
        alive = false;

    }

    protected void ShootAt(Vector3 target)
    {
        loadWeapon();
        AimAt(target);
        crossbow.GetComponentInChildren<Crossbow>().Shoot();
    }

    protected void AimAt(Vector3 target)
    {
        Vector3 randomNoise = new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f));
        arm.gameObject.transform.LookAt(target + randomNoise);
    }

    protected void loadWeapon()
    {
        crossbow.GetComponentInChildren<Crossbow>().LoadCrossbow();
    }
}
