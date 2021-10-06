using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : Object
{
    [SerializeField] private GameObject ropePrefab;
    private GameObject curRope;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// If hit by a bolt it sets the bolt to stick into the target
    /// If the bolt was shot by a player a rope is generated
    /// If a rope already exists it is deleted and a new one is made
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bolt>() != null)
        {
            collision.collider.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;


            collision.collider.GetComponent<Collider>().enabled = false;

            collision.collider.GetComponent<AudioSource>().Play();

            if (collision.gameObject.GetComponent<Bolt>().playerBolt)
            {
                if(curRope != null) { Destroy(curRope); }

                curRope = Instantiate(ropePrefab, collision.contacts[0].point, collision.collider.transform.rotation);
                curRope.transform.SetParent(null);
                curRope.GetComponent<ConfigurableJoint>().connectedAnchor = new Vector3(0,0,0);
            }
        }
    }
}
