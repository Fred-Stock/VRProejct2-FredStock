using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cable : ClimbableObject
{

    private bool setup = false;
    private bool endpt1Set = false;

    private Vector3 firstAnchor;
    private GameObject activeBow;
    private Vector3 secondAnchor;


    public void SetFirstEnd(Vector3 anchor, GameObject activeBow)
    {
        firstAnchor = anchor;
        this.activeBow = activeBow;
        this.activeBow.GetComponent<PlayerCrossbow>().activeCable = true;
        endpt1Set = true;
        transform.position = firstAnchor;
    }

    public void SetSecondEnd(Vector3 anchor)
    {
        setup = true;
        secondAnchor = anchor;
        this.activeBow.GetComponent<PlayerCrossbow>().activeCable = false;


        Vector3 direction = secondAnchor - firstAnchor;
        float dist = direction.magnitude/2;

        transform.LookAt(secondAnchor);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y , dist);

    }

    public void Update()
    {

        if(!setup && endpt1Set)
        {

            if (!activeBow.active)
            {
                Destroy(gameObject);
                return;
            }
            
            float dist = Vector3.Distance(transform.position, activeBow.transform.position)/2;       

            transform.LookAt(activeBow.transform.position);

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist);

        }
    }

}
