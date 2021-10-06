using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPoint : MonoBehaviour
{
    public Transform resetPoint; //point to reposition player if they fall into this object

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<XRRig>() != null)
        {
            collision.gameObject.transform.SetPositionAndRotation(resetPoint.position, collision.collider.transform.rotation);
        }
    }
}
