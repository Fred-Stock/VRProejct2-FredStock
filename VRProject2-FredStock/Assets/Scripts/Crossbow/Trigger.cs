using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Trigger : MonoBehaviour
{

    public GameObject curBolt;
    public GameObject crossbow;
    private XRGrabInteractable triggerInteractable;

    public void OnEnable()
    {
        if(gameObject.GetComponentInParent<PlayerCrossbow>() != null)
        {
            triggerInteractable = GetComponent<XRGrabInteractable>();
            triggerInteractable.activated.AddListener(OnShoot);
        }

    }

    public void OnDisable()
    {
        if (gameObject.GetComponentInParent<PlayerCrossbow>() != null)
        {
            triggerInteractable.activated.RemoveListener(OnShoot);

        }
    }

    /// <summary>
    /// Method which is called when the player presses the trigger while holding crossbow
    /// calls Shoot()
    /// </summary>
    /// <param name="arg0"></param>
    private void OnShoot(ActivateEventArgs arg0) { crossbow.GetComponent<Crossbow>().Shoot(); }


}
