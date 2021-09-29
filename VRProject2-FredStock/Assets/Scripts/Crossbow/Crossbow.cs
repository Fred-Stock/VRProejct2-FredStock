using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Crossbow : MonoBehaviour
{
    public GameObject boltPrefab;

    public GameObject crossbowBase;
    public GameObject bowString;
    public Trigger crossbowTrigger;
    protected GameObject curBolt;
    public Transform boltSpawnLocation;

    [SerializeField] protected float stringForce;
    public bool loaded = false;

    public virtual void LoadCrossbow()
    {
        if(loaded) { return; } //make sure the crossbow is not already loaded

        //Turns the crossbow string invisible
        bowString.GetComponent<MeshRenderer>().enabled = false;

        //Creates a bolt and initializes it so it sticks to the base of the crossbow
        curBolt = Instantiate(boltPrefab, boltSpawnLocation.position, transform.rotation);
        curBolt.GetComponent<Bolt>().SetShootForce(stringForce);
        crossbowTrigger.curBolt = curBolt;
        curBolt.GetComponent<Rigidbody>().useGravity = false;
        curBolt.transform.SetParent(crossbowBase.transform);
        curBolt.layer = 20;

        loaded = true;
    }

    /// <summary>
    /// Launches the loaded bolt and makes the crossbow string visible again
    /// </summary>
    public void Shoot()
    {
        if (!loaded) { return; } //make sure crossbow is actually loaded before trying to fire

        // launches bolt and assigns parameters needed for flight 
        curBolt.gameObject.layer = 9;
        curBolt.GetComponent<Rigidbody>().isKinematic = false;
        curBolt.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        curBolt.GetComponent<Rigidbody>().useGravity = true;
        curBolt.GetComponent<Rigidbody>().AddForce(curBolt.GetComponent<Bolt>().shootForce * curBolt.transform.forward, ForceMode.Force);

        curBolt.GetComponent<Bolt>().inAir = true;
        curBolt.transform.SetParent(null);

        // Makes the crossbow string visible
        bowString.GetComponent<MeshRenderer>().enabled = true;

        gameObject.GetComponent<Crossbow>().loaded = false;
    }


}
