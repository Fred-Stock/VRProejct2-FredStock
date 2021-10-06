using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Hand : MonoBehaviour
{

    private bool climbing = false;
    private bool grabbing = false;

    private CharacterController character;
    private ContinuousMovement continousMovement;
    private InputDevice hand;

    public Hand otherHand;

    void OnEnable()
    {
        //hand = InputDevices.GetDeviceAtXRNode(GetComponent<XRController>().controllerNode);
        
        character = GetComponentInParent<CharacterController>();
        continousMovement = GetComponentInParent<ContinuousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grabbing)
        {
            Climb();
        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(gameObject.GetComponent<XRController>().controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.parent.rotation  * -velocity * Time.deltaTime);
    }

    public bool isClimbing() { return climbing; }
    public bool isGrabbing() { return grabbing; }

    /// <summary>
    /// Determines if the player is currently holding onto an object with either hand 
    /// If yes then it sets the player to be climbing and disables controller movement
    /// If no then it set the player to no be climbing and enables controller movement
    /// </summary>
    /// <param name="climbing"></param>
    public void setClimbing(bool climbing)
    {
        if (!climbing && !otherHand.isGrabbing())
        {
            continousMovement.enabled = true;
            grabbing = false;
        }
        else if (!climbing)
        {
            grabbing = false;
        }
        else
        {
            climbing = true;
            grabbing = true;
            continousMovement.enabled = false;
        }
       
        
    }

}
