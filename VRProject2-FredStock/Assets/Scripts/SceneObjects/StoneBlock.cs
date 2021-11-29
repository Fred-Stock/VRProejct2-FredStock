using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : Object
{
    [SerializeField] private GameObject cablePrefab;
    private GameObject curCable;

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
                //if(curCable != null) { Destroy(curCable); }

                Bolt playerBolt = collision.gameObject.GetComponent<Bolt>();

                if (playerBolt.activeCable)
                {
                    playerBolt.curCable.GetComponent<Cable>().SetSecondEnd(collision.contacts[0].point);
                    playerBolt.SetCable(null);
                }
                else
                {
                    curCable = Instantiate(cablePrefab, collision.contacts[0].point, collision.collider.transform.rotation);
                    curCable.transform.SetParent(null);

                    curCable.GetComponentInChildren<Cable>().SetFirstEnd(collision.contacts[0].point, playerBolt.playerXBow);
                    playerBolt.SetCable(curCable);
                }
            }
        }
    }
}
