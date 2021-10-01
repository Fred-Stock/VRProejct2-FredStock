using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class ClimbableObject : XRBaseInteractable
{

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
