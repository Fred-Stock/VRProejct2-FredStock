//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

//public class Rope : MonoBehaviour
//{

//    private GameObject playerBody;
//    private GameObject playerHand;
//    private Transform prevHandPosition;
//    private XRGrabInteractable grabInteractable;
//    private bool playerHolding;

//    private void OnEnable()
//    {
//        playerBody = GameObject.Find("PlayerRig-DirectInteractor");
//        grabInteractable = gameObject.GetComponent<XRGrabInteractable>();
//        grabInteractable.selectEntered.AddListener(PlayerGrab);
//        grabInteractable.selectExited.AddListener(PlayerLetGo);
//    }

//    private void OnDisable()
//    {
//        grabInteractable.selectEntered.RemoveListener(PlayerGrab);
//        grabInteractable.selectExited.RemoveListener(PlayerLetGo);     
//    }

//    private void FixedUpdate()
//    {
//        if (playerHolding)
//        {
//            Debug.Log("Second Here"); 
//            PlayerClimbing();
//        }
//    }

//    private void PlayerGrab(SelectEnterEventArgs arg0)
//    {
//        Debug.Log("Here");
//        playerHand = arg0.interactor.gameObject;
//        prevHandPosition = playerHand.transform;
//        playerHolding = true;
//    }

//    private void PlayerLetGo(SelectExitEventArgs arg0)
//    {
//        playerHand = null;
//        playerHolding = false;
//    }


//}
