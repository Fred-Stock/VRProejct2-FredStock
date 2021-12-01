using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

/// <summary>
/// Script that goes on an object the player can climb
/// Listens for the player grabbing and then sets that hand to be active
/// </summary>
public class ClimbableObject : XRBaseInteractable
{

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("HERE");
        base.OnHoverEntered(args);
        if (args.interactor is XRDirectInteractor)
        {
            args.interactor.GetComponent<Hand>().setHovering(true);
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log("HERE1");
        base.OnHoverExited(args);
        if (args.interactor is XRDirectInteractor)
        {
            args.interactor.GetComponent<Hand>().setHovering(false);
        }

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        
        base.OnSelectEntered(args);
        if(args.interactor is XRDirectInteractor)
        {
            args.interactor.GetComponent<Hand>().setClimbing(true);
        }

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactor is XRDirectInteractor)
        {
            args.interactor.GetComponent<Hand>().setClimbing(false);
        }
    }

}
