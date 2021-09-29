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

        List<XRBaseInteractor> interactors = hoveringInteractors;
        for(int i = 0; i < interactors.Count; i++)
        {
            if(interactors[i].GetComponent<> //check if select is pressed and swap curhand if not cur hand, have some bool that tracks if it is still hovering && holding select after being swapped
        }

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if(args.interactor is XRDirectInteractor)
        {
            if(args.interactor )

            //if(Climber.curHand != null)
            // {
            //    if(Climber.curHand.name == args.interactor.name)
            //    {
            //        return;
            //   }
            //}
            Climber.curHand = args.interactor.GetComponent<XRController>();
            ///args.interactor.GetComponent<Collider>().enabled = false;
            //Debug.Log(Climber.curHand.name);
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
