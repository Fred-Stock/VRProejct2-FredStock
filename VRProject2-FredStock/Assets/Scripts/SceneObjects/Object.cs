using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// If hit by a bolt the bolt is made to stick into this object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Bolt>() != null)
        {
            collision.collider.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;

            collision.collider.GetComponent<Collider>().enabled = false;
            collision.collider.GetComponent<AudioSource>().Play();
        }
    }



}
