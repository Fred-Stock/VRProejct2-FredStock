using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : Object
{
    [SerializeField] private GameObject ropePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bolt>() != null)
        {
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
            collision.collider.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

            collision.collider.GetComponent<Collider>().enabled = false;

            if (collision.gameObject.GetComponent<Bolt>().playerBolt)
            {
                GameObject newRope = Instantiate(ropePrefab, collision.contacts[0].point, collision.collider.transform.rotation);
                newRope.transform.SetParent(null);
                newRope.GetComponent<ConfigurableJoint>().connectedAnchor = new Vector3(0,0,0);
            }
        }
    }
}
