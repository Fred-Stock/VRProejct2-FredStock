using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Hand : MonoBehaviour
{

    private bool climbing = false;
    private bool grabbing = false;
    private bool hoveringGrabbable = false;
    private bool holdingXBow = false;

    private CharacterController character;
    private ContinuousMovement continousMovement;
    private XRController hand;

    public Hand otherHand;
    public GameObject crossBow;
    public Material hoverMat;
    public Material defaultMat;

    void OnEnable()
    {
        hand = GetComponent<XRController>();

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

    private void Update()
    {
        bool isPressed;
        if(hand.inputDevice == null) { return; } //does not immediately load so this waits for it

        if (hand.inputDevice.IsPressed(InputHelpers.Button.Grip, out isPressed) && isPressed)
        {
            HoldCrossbow();
        }
        else if (holdingXBow)
        {
            DropCrossbow();
        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(gameObject.GetComponent<XRController>().controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.parent.rotation  * -velocity * Time.deltaTime);
    }

    public bool isClimbing() { return climbing; }
    public bool isGrabbing() { return grabbing; }
    public bool isHovering() { return hoveringGrabbable; }

    public void setHovering(bool hover) {
        hoveringGrabbable = hover;
        if (hover)
        {
            GetComponentInChildren<MeshRenderer>().material = hoverMat;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material = defaultMat;
        }
    }

    /// <summary>
    /// Determines if the player is currently holding onto an object with either hand 
    /// If yes then it sets the player to be climbing and disables controller movement
    /// If no then it set the player to no be climbing and enables controller movement
    /// </summary>
    /// <param name="climbing"></param>
    public void setClimbing(bool climbing)
    {
        if (holdingXBow) { return; }

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

    public void HoldCrossbow()
    {
        if (!grabbing && !hoveringGrabbable)
        {
            holdingXBow = true;
            crossBow.SetActive(true);
            crossBow.transform.position = gameObject.transform.position;

        }
    }

    private void DropCrossbow()
    {
        crossBow.GetComponentInChildren<PlayerCrossbow>().resetCable();
        holdingXBow = false;
        crossBow.SetActive(false);
    }

}
