using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Crossbow : MonoBehaviour
{
    public GameObject boltPrefab;

    public GameObject crossbowBase;
    public GameObject crossbowTrigger;
    protected GameObject curBolt;

    [SerializeField] protected float stringForce;
    public bool loaded = false;

    public void LoadCrossbow()
    {
        //Turns the crossbow string invisible
        GetComponent<MeshRenderer>().enabled = false;

        //Creates a bolt and initializes it so it sticks to the base of the crossbow
        curBolt = Instantiate(boltPrefab, transform.position + -.25f * transform.forward, transform.rotation);
        crossbowTrigger.GetComponent<Trigger>().curBolt = curBolt;
        curBolt.GetComponent<Rigidbody>().useGravity = false;
        curBolt.transform.SetParent(crossbowBase.transform);

        loaded = true;
    }

    

}
