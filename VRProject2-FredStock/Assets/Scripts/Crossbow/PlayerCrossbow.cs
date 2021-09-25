using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCrossbow : Crossbow
{

    public void OnEnable()
    {
        gameObject.GetComponentInChildren<XRSimpleInteractable>().selectEntered.AddListener(OnPlayerGrabEvent);
        gameObject.GetComponentInChildren<XRSimpleInteractable>().selectExited.AddListener(OnPlayerLetGoEvent);

    }

    public void OnDisable()
    {
        gameObject.GetComponentInChildren<XRSimpleInteractable>().selectEntered.RemoveListener(OnPlayerGrabEvent);
        gameObject.GetComponentInChildren<XRSimpleInteractable>().selectExited.RemoveListener(OnPlayerLetGoEvent);
    }

    /// <summary>
    /// Loads crossbow if the player grabs the string
    /// </summary>
    /// <param name="arg0"></param>
    private void OnPlayerGrabEvent(SelectEnterEventArgs arg0)
    {

        //Makes sure that it is not possible to load multiple bolts 
        if (!loaded)
        {
            OnPlayerGrab();
        }
    }

    /// <summary>
    /// Creates a bolt that is attached to the base of the crossbow
    /// When the trigger is pressed the bolt gets lauched has gravity turned back on
    /// </summary>
    private void OnPlayerGrab()
    {
        LoadCrossbow();
    }

    //Assigns the magnititude of the force that will launch the bolt
    private void OnPlayerLetGoEvent(SelectExitEventArgs arg0)
    {
        crossbowTrigger.held = false;

        curBolt.GetComponent<Bolt>().shootForce = stringForce;
    }

    public override void LoadCrossbow()
    {
        base.LoadCrossbow();
        curBolt.GetComponent<Bolt>().playerBolt = true;
    }
}
