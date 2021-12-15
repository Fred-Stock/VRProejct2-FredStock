using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//after player passes this point it spawns a shortcut
//TODO: Audio/Visual Feedback
public class CheckPoint : MonoBehaviour
{

    public List<GameObject> shortCutPieces;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XRRig>() != null)
        {
            foreach(GameObject piece in shortCutPieces)
            {
                piece.SetActive(true);
            }
        }
    }
}
