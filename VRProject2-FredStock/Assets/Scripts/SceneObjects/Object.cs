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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Bolt>() != null)
        {
            //collision.collider.transform.parent = gameObject.transform;
           
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
            collision.collider.GetComponent<Collider>().enabled = false;
            //collision.collider.GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

}
