using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class ClimbableObject : XRBaseInteractable
{

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactor is XRDirectInteractor)
        {
            Climber.curHand = args.interactor.GetComponent<XRController>();
            //args.interactor.GetComponentInParent<XRController>();

        }

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactor is XRDirectInteractor)
        {
            if(Climber.curHand != null && Climber.curHand.name == args.interactor.name)
            {
                Climber.curHand = null;
            }
        }
    }
}
