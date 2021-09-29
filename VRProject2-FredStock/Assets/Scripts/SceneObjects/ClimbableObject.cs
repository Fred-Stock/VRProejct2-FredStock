using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class ClimbableObject : XRBaseInteractable
{

    private void Update()
    {

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(args.interactor is XRDirectInteractor)
        {
            if(Climber.curHand != null)
            {
                if(Climber.curHand.name == args.interactor.name)
                {
                    return;
                }
            }
            Climber.curHand = args.interactor.GetComponent<XRController>();
            args.interactor.GetComponent<Collider>().enabled = false;
            Debug.Log(Climber.curHand.name);
        }

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactor is XRDirectInteractor && Climber.curHand != null)
        {
            if ( Climber.curHand.name == args.interactor.name)
            {
                args.interactor.GetComponent<Collider>().enabled = true;
                Climber.curHand = null;
            }

        }
    }
}
